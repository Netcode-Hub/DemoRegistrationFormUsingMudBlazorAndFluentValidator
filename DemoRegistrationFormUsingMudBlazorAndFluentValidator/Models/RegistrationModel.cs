using System.ComponentModel.DataAnnotations;

namespace DemoRegistrationFormUsingMudBlazorAndFluentValidator.Models
{
    public class RegistrationModel
    {
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
       
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        
        public int PhoneNumber { get; set; }
    }
}
