using API.DAL.InDto;
using AutoMapper;

namespace API.Controllers.User
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<AddUserInModel, AddUserInDto>();
        }
    }
}
