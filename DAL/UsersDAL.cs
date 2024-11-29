using DAL.Context;
using DAL.Dto;
using DAL.InDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsersDAL
    {
        public IEnumerable<GetAllUsersResult> GetAllUsersAsync()
        {
            using (var db = new DatabaseContext())
            {
                var users =  db.GetProcedures().GetAllUsersAsync().Result;
                return users;
            }
        }

        public void AddUser(AddUserInDto dto)
        {
            using (var db = new DatabaseContext())
            {
                var result = db.GetProcedures().AddUserAsync(
                    dto.Name,
                    dto.Height,
                    dto.Weight
                ).Result;
            }
        }
    }
}
