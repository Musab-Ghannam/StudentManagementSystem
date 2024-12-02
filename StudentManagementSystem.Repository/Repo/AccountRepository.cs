
using StudentManagementSystem.Repository.Interface;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace StudentManagementSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private StudentManagementSystemEntities1 _context;

        public AccountRepository()
        {
            _context = new StudentManagementSystemEntities1();
        }

        public Users GetUserById(Users users)
        {
            if (string.IsNullOrEmpty(users.PasswordHash) || string.IsNullOrEmpty(users.Username))
            {
                return null;
            }
            string hashedPassword = HashPassword(users.PasswordHash);
            var usernameParam = new SqlParameter("@Username", users.Username ?? (object)DBNull.Value);
            var passwordParam = new SqlParameter("@PasswordHash", hashedPassword ?? (object)DBNull.Value);

            var userExist = _context.Database.SqlQuery<Users>(
                "EXEC dbo.AuthenticatedUser @Username, @PasswordHash",
                usernameParam,
                passwordParam
            ).FirstOrDefault();
            return userExist;
        }


        public bool LogIn(Users users)
        {
            throw new System.NotImplementedException();
        }


        public bool Register(Users users)
        {
            if (_context.Users.Any(u => u.Email == users.Email || u.Username == users.Username))
            {
                return false;
            }

            users.PasswordHash = HashPassword(users.PasswordHash);
            _context.Users.Add(users);
            _context.SaveChanges();
            return true;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }
    }
}
