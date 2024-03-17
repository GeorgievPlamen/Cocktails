using System.ComponentModel.DataAnnotations;

namespace Cocktails.Application.AuthenticationFeature
{
    public class RegisterDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$",
        ErrorMessage = "Password must have atleast 8 charecters, one lower case letter, one upper case letter and one digit.")]
        public string? Password { get; set; }
        [Required]
        [MinLength(4)]
        public string? Name { get; set; }
    }
}