using ASP.NETMVCSchool.DTOs;
using ASP.NETMVCSchool.Models;

namespace ASP.NETMVCSchool.Services
{
    public class SubjectsService
    {
        private SchoolDbContext _dbContext;
        public SubjectsService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // najde předmět podle Id
        public SubjectDTO? FindSubjectById(int id)
        {
            var subject = _dbContext.Subjects.Find(id);
            if (subject == null) return null;
            return modelToDTO(subject);
        }

        // vypiše všechny předměty
        public IEnumerable<SubjectDTO> GetAllSubjects()
        {
            var allSubjects = _dbContext.Subjects;
            var allDTOs = new List<SubjectDTO>();
            foreach (var s in allSubjects)
            {
                allDTOs.Add(modelToDTO(s));
            }
            return allDTOs;
        }

        // uloží nový předmět
        public void CreateSubject(SubjectDTO subjectDTO)
        {            
            _dbContext.Subjects.Add(dtoToModel(subjectDTO));
            _dbContext.SaveChanges();
        }

        // smaže předmět
        public void DeleteSubject(int id)
        {
            var subject = _dbContext.Subjects.Find(id);
            if (subject == null) return;
            _dbContext.Subjects.Remove(subject);
            _dbContext.SaveChanges();
        }

        // aktualizuje předmět
        public void UpdateSubject(int id, SubjectDTO subjectDTO)
        {
            var subject = _dbContext.Subjects.Find(id);
            if (subject == null) return;
            subject.Name = subjectDTO.Name;            
            _dbContext.SaveChanges();
        }


        // transformace DTO na model
        private SubjectDTO modelToDTO(Subject subject)
        {
            return new SubjectDTO
            {
                Id = subject.Id,
                Name = subject.Name
            };
        }
        // transformace model na DTO
        private Subject dtoToModel(SubjectDTO subjectDTO)
        {
            return new Subject
            {
                Id = subjectDTO.Id,
                Name = subjectDTO.Name
            };
        }
    }
}
