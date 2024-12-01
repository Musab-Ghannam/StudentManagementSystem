﻿using StudentManagementSystem.Repository.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace StudentManagementSystem.Repository.Repo
{
    public class HomeRepository : IHomeRepository
    {
        private StudentManagementSystemEntities _context;

        public HomeRepository()
        {
            _context = new StudentManagementSystemEntities();
        }

        public IEnumerable<Students> GetListOfStudents(int page = 1, int pageSize = 5)
        {
            var students = _context.Students
                           .OrderBy(c => c.StudentNumber)
                           .Skip((page - 1) * pageSize)  
                           .Take(pageSize)               
                           .ToList();
            return students;
        }
    }
}
