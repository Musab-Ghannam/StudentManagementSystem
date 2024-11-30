
using System.Collections.Generic;

namespace StudentManagementSystem.Repository.Interface
{
    public interface IHomeRepository
    {
        IEnumerable<Students> GetListOfStudents();
    }
}
