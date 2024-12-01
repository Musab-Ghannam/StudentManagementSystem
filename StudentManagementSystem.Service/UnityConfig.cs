using StudentManagementSystem.Repository;
using StudentManagementSystem.Repository.Interface;
using StudentManagementSystem.Repository.Repo;
using StudentManagementSystem.Service.Services;
using Unity;

namespace StudentManagementSystem.Service
{
    public class UnityConfig
    {
        public static void RegisterComponents(IUnityContainer container)
        {
            container.RegisterType<IHomeRepository, HomeRepository>();
            container.RegisterType<HomeService>();
            container.RegisterType<IAccountRepository, AccountRepository>();
            container.RegisterType<AccountService>();

        }
    }


}
