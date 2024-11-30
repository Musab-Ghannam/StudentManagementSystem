
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Service.DTO
{
    public class UserDTO
    {   
        public string UserName { get; set; } 
        public string Email { get; set; }  
        public string Password { get; set; }
        public string FullName { get; set; }

        public static User ToEntity(UserDTO userDTO)
        {
            return new User
            {
                FullName = userDTO.FullName,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                Username = userDTO.UserName
            };
        }
    }
}
