namespace ASP.NETMVCSchool.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }        
    }
}
