
using System.Collections.Generic;

namespace StudentManagementSystem.Repository.Interface
{
    public interface IHomeRepository
    {
        IEnumerable<Students> GetListOfStudents(int page = 1, int pageSize = 5);
    }
}
