
using StudentManagementSystem.Service.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentModelUpdate
    {
        [Required]
        public Guid StudentNumber { get; set; }
        [Required]
        public string StudentName { get; set; }
        [Required]
        public DateTime DateofBirth { get; set; }
        [Required]
        [Range(0, 100)]
        public decimal TawjehiAverage { get; set; }
        public string SchoolName { get; set; }

        public static StudentDTO Updated(StudentDTO studentDTO, StudentModelUpdate student)
        {
            studentDTO.DateofBirth = student.DateofBirth;
            studentDTO.SchoolName = student.SchoolName;
            studentDTO.StudentName = student.StudentName;
            studentDTO.TawjehiAverage = student.TawjehiAverage;
            studentDTO.UpdatedAt = DateTime.UtcNow;
            return studentDTO; 
        }
    }
}
