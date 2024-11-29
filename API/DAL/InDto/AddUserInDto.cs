using System.ComponentModel.DataAnnotations;

namespace API.DAL.InDto
{
    public class AddUserInDto
    {
        public string Name { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
    }
}
