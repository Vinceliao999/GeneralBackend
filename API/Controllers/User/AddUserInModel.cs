using System.ComponentModel.DataAnnotations;

namespace API.Controllers.User
{
    public class AddUserInModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Height { get; set; }
        [Required]
        public int? Weight { get; set; }
        [Required]
        public int UserID { get; set; }

    }
}
