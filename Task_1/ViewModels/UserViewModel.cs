using System.ComponentModel.DataAnnotations;

namespace Task_1.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Username required")]
        [Display(Name = "Please, input your username")]
        public string Username { get; set; }

        public string Greetings { get; set; }
    }
}
