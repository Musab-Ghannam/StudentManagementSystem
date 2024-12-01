

using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class UserLogIn
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

}
