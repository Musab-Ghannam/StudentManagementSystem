using StudentManagementSystem.Repository;
using System;

namespace StudentManagementSystem.Service.DTO
{
    public class StudentDTO
    {
        public Guid? StudentNumber { get; set; }
        public string StudentName { get; set; }
        public DateTime DateofBirth { get; set; }
        public decimal TawjehiAverage { get; set; }
        public string SchoolName { get; set; }
        public string StudentNameArabic { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int PhysicsGrade { get; set; }
        public int MathGrade { get; set; }
        public string NationalNum { get; set; }
        public byte[] pic { get; set; }

        public static StudentDTO ToDTO(Students student)
        {
            return new StudentDTO
            {
                StudentName = student.StudentNameEnglish,
                TawjehiAverage = student.TawjehiAverage,
                SchoolName = student.SchoolName,
                DateofBirth = student.DateOfBirth,
                StudentNumber = student.StudentNumber,
                StudentNameArabic = student.StudentNameArabic,
                UpdatedAt = student.UpdatedAt,
                CreatedAt = student.CreatedAt,
                PhysicsGrade = student.PhysicsGrade,
                MathGrade = student.MathGrade,
                NationalNum = student.NationalNumber,
                pic = student.StudentPicture,
            };
        }

        public static Students ToEntity(StudentDTO student)
        {
            return new Students
            {
                StudentNameEnglish = student.StudentName,
                TawjehiAverage = student.TawjehiAverage,
                SchoolName = student.SchoolName,
                DateOfBirth = student.DateofBirth,
                StudentNumber = student.StudentNumber ?? Guid.NewGuid(),
                IsDeleted = student.IsDeleted,
                UpdatedAt = student.UpdatedAt,
                CreatedAt = student.CreatedAt,
                PhysicsGrade = student.PhysicsGrade,
                MathGrade = student.MathGrade,
                NationalNumber = student.NationalNum,
                StudentPicture = student.pic,
                StudentNameArabic = student.StudentNameArabic
            };

        }
    }
}
