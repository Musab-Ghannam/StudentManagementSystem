using StudentManagementSystem.Repository.Interface;
using System.Collections.Generic;

namespace StudentManagementSystem.Repository.Repo
{
    public class HomeRepository : IHomeRepository
    {
        private StudentManagementSystemEntities _context;

        public HomeRepository()
        {
            _context = new StudentManagementSystemEntities();
        }

        public IEnumerable<Students> GetListOfStudents()
        {
            var student = _context.Students;
            return student;
        }
    }
    }
