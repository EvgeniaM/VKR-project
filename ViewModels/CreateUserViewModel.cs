using System.ComponentModel.DataAnnotations;
 
namespace ServerVKR.ViewModels
{
    public class CreateUserViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}