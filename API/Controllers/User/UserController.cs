using API.DAL;
using API.DAL.OutDto;
using API.DAL.InDto;
using API.Services;
using Microsoft.AspNetCore.Mvc;
using API.Controllers.User;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [ApiController]
    [EnableCors("OpenToAllPolicy")]
    [Authorize(Policy = "Authenticated")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;
        private readonly UserDAL _userDAL;

        public UserController(ILogger<UserController> logger,
            IMailService mailService,
            UserDAL userDAL,
            IMapper mappper)
        {
            _logger = logger;
            _mailService = mailService;
            _userDAL = userDAL;
            _mapper = mappper;
        }

        /// <summary>
        /// GetAllUsersAsync
        /// </summary>
        /// <remarks>
        /// Sample remarks
        /// Sample remarks2
        /// </remarks>
        /// <returns>An ActionResult</returns>
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<GetAllUsersResult>>> GetAllUsersAsync()
        {
            try
            {
                var users = await _userDAL.GetAllUsersAsync();
                _logger.LogInformation("");
                return Ok(users);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error Message", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        /// <summary>
        /// AddUserAsync
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddUserAsync(AddUserInModel userModel)
        {
            try
            {
                var userID = User.Claims.FirstOrDefault(x => x.Type == "userid")?.Value;

                Console.WriteLine($"User ID: {userID}");

                AddUserInDto user = _mapper.Map<AddUserInDto>(userModel);

                var result = await _userDAL.AddUserAsync(user);

                _mailService.Send("Add User", userModel.Name);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Error Message", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }
    }
}