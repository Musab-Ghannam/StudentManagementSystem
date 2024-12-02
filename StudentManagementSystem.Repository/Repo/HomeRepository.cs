using StudentManagementSystem.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StudentManagementSystem.Repository.Repo
{
    public class HomeRepository : IHomeRepository
    {
        private StudentManagementSystemEntities1 _context;

        public HomeRepository()
        {
            _context = new StudentManagementSystemEntities1();
        }

        public IEnumerable<Students> GetListOfStudents()
        {
            var students = _context.Students
                                   .Where(c=>c.IsDeleted == false)
                                   .OrderByDescending(c=>c.CreatedAt);
            return students;
        }

        public int GetTotalStudentsCount()
        {
            return _context.Students
                           .Where(c=>c.IsDeleted == false)
                           .Count();
        }

        public Students GetStudentById(Guid? id)
        {
            return _context.Students
                           .AsNoTracking()
                           .FirstOrDefault(c => c.StudentNumber == id);

        }

        public bool UpdateStudent(Students students)
        {
            _context.Entry(students).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public bool CreateStudent(Students students)
        {
            _context.Students.Add(students);
            _context.SaveChanges();
            return true;
        }
    }
}