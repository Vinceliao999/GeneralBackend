using API.DAL.Context;
using API.DAL.OutDto;
using API.DAL.InDto;

namespace API.DAL
{
    public class UserDAL
    {
        private readonly DatabaseContext _db;
        public UserDAL(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<GetAllUsersResult>> GetAllUsersAsync()
        {

                var users = await _db.GetProcedures().GetAllUsersAsync();
                return users;
            
        }

        public async Task<int> AddUserAsync(AddUserInDto dto)
        {

                var result = await _db.GetProcedures().AddUserAsync(
                    dto.Name,
                    dto.Height,
                    dto.Weight
                );
                return result;
            
        }
    }
}
