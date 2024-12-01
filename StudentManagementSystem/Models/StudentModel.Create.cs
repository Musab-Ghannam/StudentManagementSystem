

using StudentManagementSystem.Service.DTO;
using System;

namespace StudentManagementSystem.Models
{
    public class StudentModelCreate
    {
        public Guid StudentNumber;
        public string StudentName;
        public DateTime DateofBirth;
        public decimal TawjehiAverage;
        public string SchoolName;

        public static StudentDTO ToDTO(StudentModelCreate student)
        {
            return new StudentDTO
            {
                StudentName = student.StudentName,
                TawjehiAverage = student.TawjehiAverage,
                SchoolName = student.SchoolName,
                DateofBirth = student.DateofBirth,
                StudentNumber = student.StudentNumber

            };

        }
    }
}
