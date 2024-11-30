
using StudentManagementSystem.Repository.Interface;
using System;

namespace StudentManagementSystem.Service.Services
{
    public class UnitOfWorkServices
    {
        #region Properties
        private HomeService _homeService;
        //private readonly AccountService _accountService;

        private readonly IHomeRepository _homeRepository;
        #endregion

        #region Ctors
        public UnitOfWorkServices(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository ?? throw new ArgumentNullException(nameof(homeRepository));

        }

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


        #endregion
    }
}
