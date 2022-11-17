using SchoolManagement.Domain;

namespace SchoolManagement.Entities
{
    public class SchoolEntity : DomainObject
    {
        public string? Name { get; set; } 
        public virtual ICollection<StudentEntity>? StudentEntities { get; set; }     //School -> Student (1-M)
        public virtual ICollection<TeacherEntity>? TeacherEntities { get; set; }    //School -> Teacher (1-M)

    }
}
