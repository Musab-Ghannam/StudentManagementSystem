
namespace StudentManagementSystem.Repository.Interface
{
    public interface IAccountRepository
    {
        bool LogIn(Users users);
        bool Register(Users users);
        Users GetUserById(Users users);
    }
}
