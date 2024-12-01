

using StudentManagementSystem.Service.DTO;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class StudentModelCreate
    {
        public Guid? StudentNumber {  get; set; }

        [Required]
        public string StudentName { get; set; }
        public DateTime DateofBirth { get; set; }
        public decimal TawjehiAverage { get; set; }
        [Required]
        public string SchoolName { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        [Required]
        [Range(0,100)]
        public int PhysicsGrade { get; set; }
        [Required]
        [Range(0, 100)]
        public int MathGrade { get; set; }
        [Required]
        public string NationalNum { get; set; }
        [Required]
        public string StudentNameArabic { get; set; }
        public byte[] pic { get; set; }

        public static StudentDTO ToDTO(StudentModelCreate student)
        {
            return new StudentDTO
            {
                StudentName = student.StudentName,
                TawjehiAverage = student.TawjehiAverage,
                SchoolName = student.SchoolName,
                DateofBirth = student.DateofBirth,
                StudentNumber = student.StudentNumber,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                NationalNum = student.NationalNum,
                PhysicsGrade = student.PhysicsGrade,
                MathGrade = student.MathGrade,
                StudentNameArabic = student.StudentNameArabic,
            };

        }
    }
}
