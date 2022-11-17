using SchoolManagement.Domain;

namespace SchoolManagement.Entities
{
    public class ClassroomEntity : DomainObject
    {
        public string? Name { get; set; } 
        public virtual ICollection<StudentEntity>? StudentEntities { get; set; }      //Student(1-M)
        public virtual ICollection<TeacherEntity>? TeacherEntities { get; set; }      //Teacher(1-M)

    }
}
