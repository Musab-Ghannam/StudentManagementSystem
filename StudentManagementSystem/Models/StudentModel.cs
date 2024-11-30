using StudentManagementSystem.Service.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentModel
    {
        [Required]
        public Guid StudentNumber;
        [Required]
        public string StudentName;
        [Required]
        public DateTime DateofBirth;
        [Required]
        [Range(0,100)]
        public decimal TawjehiAverage;
        [Required]
        public string SchoolName;

        public static StudentModel ToModel(StudentDTO student)
        {
            return new StudentModel
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