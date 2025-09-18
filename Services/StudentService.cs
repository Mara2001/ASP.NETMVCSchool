using ASP.NETMVCSchool.DTOs;
using ASP.NETMVCSchool.Models;

namespace ASP.NETMVCSchool.Services
{    
    public class StudentService
    {
        private SchoolDbContext _dbContext;
        public StudentService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // vypiše všechny studenty
        public IEnumerable<StudentDTO> GetAllStudents()
        {
            var allStudents = _dbContext.Students;
            var allDTOs = new List<StudentDTO>();
            foreach (var student in allStudents)
            {
                allDTOs.Add(modelToDTO(student));
            }
            return allDTOs;
        }

        // transformační metoda z entity na DTO
        private StudentDTO modelToDTO(Student student)
        {
            return new StudentDTO
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth
            };
        }
    }
}
