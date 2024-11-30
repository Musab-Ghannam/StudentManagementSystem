
namespace StudentManagementSystem.Repository
{
   public class AccountRepository
    {
        private StudentManagementSystemEntities _context;

        public AccountRepository()
        {
            _context = new StudentManagementSystemEntities();
        }


    }
}
