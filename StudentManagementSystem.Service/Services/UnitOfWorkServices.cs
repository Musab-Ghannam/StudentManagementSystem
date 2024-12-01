
using StudentManagementSystem.Repository;
using StudentManagementSystem.Repository.Interface;
using System;

namespace StudentManagementSystem.Service.Services
{
    public class UnitOfWorkServices
    {
        #region Properties
        private HomeService _homeService;
        private AccountService _accountService;

        private readonly IHomeRepository _homeRepository;
        private readonly IAccountRepository _accountRepository;
        #endregion

        #region Ctors
        public UnitOfWorkServices(IHomeRepository homeRepository, IAccountRepository accountRepository)
        {
            _homeRepository = homeRepository ?? throw new ArgumentNullException(nameof(homeRepository));
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }
        #endregion

        #region Services

        public HomeService HomeService
        {
            get
            {
                if (_homeService == null)
                {
                    _homeService = new HomeService(_homeRepository);
                }
                return _homeService;
            }
        }

        public AccountService AccountService
        {
            get
            {
                if (_accountService == null)
                {
                    _accountService = new AccountService(_accountRepository);
                }
                return _accountService;
            }

            #endregion
        }
    }
}
