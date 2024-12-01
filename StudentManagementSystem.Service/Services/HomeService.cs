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

        public IEnumerable<StudentDTO> GetStudents(int page, int pageSize)
        {
            var studentList = _homeRepository.GetListOfStudents(page, pageSize);
            var studentDtoList = studentList.Select(StudentDTO.ToDTO).ToList();
            return studentDtoList;
        }
    }
}
