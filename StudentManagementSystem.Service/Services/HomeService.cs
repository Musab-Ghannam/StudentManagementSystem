using StudentManagementSystem.Repository.Interface;
using StudentManagementSystem.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagementSystem.Service.Services
{
    public class HomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository ?? throw new ArgumentNullException(nameof(homeRepository));
        }

        public IEnumerable<StudentDTO> GetStudents()
        {
            var studentList = _homeRepository.GetListOfStudents();
            var studentDtoList = studentList.Select(StudentDTO.ToDTO).ToList();
            return studentDtoList;
        }

        public int TotalCount()
        {
            int totalCount = _homeRepository.GetTotalStudentsCount();
            return totalCount;
        }

        public StudentDTO GetStudentById(Guid? id)
        {
            var studentEntity = _homeRepository.GetStudentById(id);
            var studentDTO = StudentDTO.ToDTO(studentEntity);
            return studentDTO;
        }

        public bool UpdateStudent(StudentDTO studentDto)
        {
            var studentEntity = StudentDTO.ToEntity(studentDto);
            bool isUpdated = _homeRepository.UpdateStudent(studentEntity);
            return isUpdated ? true : false;
        }

        public bool Delete(StudentDTO studentDto)
        {
            var studentEntity = StudentDTO.ToEntity(studentDto);
            bool isUpdated = _homeRepository.UpdateStudent(studentEntity);
            return isUpdated ? true : false;
        }

        public bool CraeteStudent(StudentDTO studentDto)
        {
            var studentEntity = StudentDTO.ToEntity(studentDto);
            bool isUpdated = _homeRepository.CreateStudent(studentEntity);
            return isUpdated ? true : false;
        }

    }
}
