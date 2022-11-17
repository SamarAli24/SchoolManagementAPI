using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Entities
{
    public class TeacherEntity : DomainObject
    {
        public string? Name { get; set; }  

        [ForeignKey("Classroom")]                                                //Teacher -> class (1-M)
        public Guid ClassId { get; set; }
        public ClassroomEntity? Classroom { get; set; }

        [ForeignKey("school")]                                                   //Teacher -> School (1-M)
        public Guid SchoolId { get; set; }
        public SchoolEntity? School { get; set; }

                                                   
        public virtual ICollection<StudentTeacherEntity>? StudentTeachers { get; set; }    //Teacher -> Student (M-M)
    }
}
