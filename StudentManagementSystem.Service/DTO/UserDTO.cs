
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Service.DTO
{
    public class UserDTO
    {   
        public string UserName { get; set; } 
        public string Email { get; set; }  
        public string Password { get; set; }
        public string FullName { get; set; }

        public static Users ToEntity(UserDTO userDTO)
        {
            return new Users
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                Username = userDTO.UserName
            };
        }
    }
}
