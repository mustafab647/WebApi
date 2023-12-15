using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Token
{
    public class RegisterRequest
    {
        [Required(ErrorMessage ="Required UserName")]
        public string UserName { get; set; }

        public string Email { get; set; }
        [Required(ErrorMessage ="Required Password")]
        public string Password { get; set; }
    }
}
