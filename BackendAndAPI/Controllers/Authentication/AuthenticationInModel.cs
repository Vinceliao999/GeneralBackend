using System.ComponentModel.DataAnnotations;

namespace API.Controllers.Authentication
{
    public class AuthenticationInModel
    {
        [Required]
        public string Key { get; set; }
    }
}
