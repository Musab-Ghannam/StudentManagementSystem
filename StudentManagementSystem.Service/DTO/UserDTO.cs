
using StudentManagementSystem.Repository;
using System;

namespace StudentManagementSystem.Service.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public static Users ToEntity(UserDTO userDTO)
        {
            return new Users
            {
                UserID = Guid.NewGuid(),
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                Username = userDTO.UserName,
                CreatedAt = DateTime.UtcNow,
                IsActive = true,
                LastLoginAt = DateTime.UtcNow,
            };
        }

        public static UserDTO ToDTO(Users user)
        {
            return new UserDTO
            {
                Id = user.UserID,
                FullName = user.FullName,
                Email = user.Email,
                Password = user.PasswordHash,
                UserName = user.Username
            };
        }
    }
}
