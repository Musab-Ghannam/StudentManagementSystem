
using StudentManagementSystem.Service.DTO;
using System.ComponentModel.DataAnnotations;
using System;

namespace StudentManagementSystem.Models
{
    public class StudentModelDelete
    {
       
        public Guid StudentNumber;
        public string StudentName;
        public DateTime DateofBirth;
        public decimal TawjehiAverage;
        public string SchoolName;
        public bool IsDelted;

        public static StudentDTO ToDTO(StudentModelDelete student)
        {
            return new StudentDTO
            {
                StudentName = student.StudentName,
                TawjehiAverage = student.TawjehiAverage,
                SchoolName = student.SchoolName,
                DateofBirth = student.DateofBirth,
                StudentNumber = student.StudentNumber,
                IsDeleted = true
            };

        }
    }
}
