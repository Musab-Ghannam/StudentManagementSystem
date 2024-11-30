using StudentManagementSystem.Repository;
using System;

namespace StudentManagementSystem.Service.DTO
{
    public class StudentDTO
    {
        public Guid StudentNumber;
        public string StudentName;
        public DateTime DateofBirth;
        public decimal TawjehiAverage;
        public string SchoolName;

        public static StudentDTO ToDTO(Students student)
        {
            return new StudentDTO
            {
                StudentName = student.StudentNameEnglish,
                TawjehiAverage = student.TawjehiAverage,
                SchoolName = student.SchoolName,
                DateofBirth = student.DateOfBirth,
                StudentNumber = student.StudentNumber

            };
        }
    }
}
