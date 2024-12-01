
using StudentManagementSystem.Repository;
using StudentManagementSystem.Repository.Interface;
using StudentManagementSystem.Repository.Repo;
using StudentManagementSystem.Service.DTO;
using System;

namespace StudentManagementSystem.Service.Services
{
    public class AccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(_accountRepository));
        }

        public bool Register(UserDTO user)
        {
            var userEntity = UserDTO.ToEntity(user);
            bool isRegistered = _accountRepository.Register(userEntity);
            return isRegistered;
        }

        public bool LogIn(string username, string password)
        {
            var user = new Users
            {
                PasswordHash = password,
                Username = username,
            };
            var isUserExist = _accountRepository.GetUserById(user);
            if (isUserExist)
            {
                return true;
            }

            return false;
        }



    }
}
