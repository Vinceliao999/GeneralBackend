using API.Controllers.User;
using API.DAL;
using API.DAL.Context;
using API.DAL.InDto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.SampleCode
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SampleCodeController : Controller
    {
        private readonly UserDAL _userDAL;
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private readonly DatabaseContext _db;
        public SampleCodeController(
            UserDAL userDAL,
            IMapper mappper,
            IServiceScopeFactory serviceScopeFactory)
        {
            _userDAL = userDAL;
            _mapper = mappper;
            _serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Fire And Forget
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> FireAndForget(AddUserInModel userModel)
        {
            try
            {
                //Below could be extrace into a service class
                Task.Run(async () =>
                {
                    try
                    {
                        AddUserInDto user = _mapper.Map<AddUserInDto>(userModel);

                        await Task.Delay(5000);
                        Console.WriteLine("Delay 5000 complete");

                        using var scope = _serviceScopeFactory.CreateScope();
                        var repository = scope.ServiceProvider.GetRequiredService<UserDAL>();
                        await repository.AddUserAsync(user);

                        throw new Exception("test exeception");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }
    }
}
