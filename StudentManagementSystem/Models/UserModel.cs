using StudentManagementSystem.Service.DTO;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class UserModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FullName { get; set; }

        public static UserDTO ToDTO(UserModel userModel)
        {
            return new UserDTO
            {
                FullName = userModel.FullName,
                Email = userModel.Email,
                Password = HashPassword(userModel.Password),
                UserName = userModel.UserName
            };
        }

        private static string HashPassword(string password)
        {

            return password;
        }
    }
}