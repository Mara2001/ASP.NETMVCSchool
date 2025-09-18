namespace ASP.NETMVCSchool.Services
{
    public class StudentService
    {
        private SchoolDbContext _dbContext;
        public StudentService(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
