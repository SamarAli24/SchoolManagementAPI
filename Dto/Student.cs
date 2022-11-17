namespace SchoolManagement.Dto
{
    public class Student
    {
        //public Guid StudentId { get; set; }
        public string? Name { get; set; }
        public Guid ClassId { get; set; }
        public Guid SchoolId { get; set; }
        public Guid ParentId { get; set; }
   
    }
}
