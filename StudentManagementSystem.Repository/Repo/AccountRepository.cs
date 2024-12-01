
using StudentManagementSystem.Repository.Interface;
using System;
using System.Linq;

namespace StudentManagementSystem.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private StudentManagementSystemEntities _context;

        public AccountRepository()
        {
            _context = new StudentManagementSystemEntities();
        }

        public bool GetUserById(Users users)
        {
            string hashedPassword = HashPassword(users.PasswordHash);
            var isUserExist = _context.Users.Any(c => c.UserID == users.UserID 
                                                      && c.PasswordHash == hashedPassword);
            return isUserExist ? true : false;
        }

        public bool LogIn(Users users)
        {
            throw new System.NotImplementedException();
        }

    
        public bool Register(Users users)
        {
            if (_context.Users.Any(u => u.Username == users.Username))
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
