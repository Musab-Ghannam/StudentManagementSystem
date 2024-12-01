
using System;
using System.Collections.Generic;

namespace StudentManagementSystem.Repository.Interface
{
    public interface IHomeRepository
    {
        IEnumerable<Students> GetListOfStudents();
        int GetTotalStudentsCount();

        Students GetStudentById(Guid? id);
        bool UpdateStudent(Students students);
        bool CreateStudent(Students students);
    }
}
