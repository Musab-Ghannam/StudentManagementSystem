using StudentManagementSystem.Service.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentModel
    {
        [Required]
        public Guid StudentNumber { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        [Range(0,100)]
        public decimal TawjehiAverage { get; set; }
        [Required]
        public string SchoolName { get; set; }

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