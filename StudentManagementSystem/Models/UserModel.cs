using StudentManagementSystem.Service.DTO;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

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
                Password = userModel.Password,
                UserName = userModel.UserName
            };
        }

        public static UserLogIn ToLogIn(UserModel userModel)
        {
            return new UserLogIn
            {
                Email = userModel?.Email,
                Password = userModel?.Password,
            };

        }

    }
}