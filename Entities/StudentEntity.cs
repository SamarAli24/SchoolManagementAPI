using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Entities
{
    public class StudentEntity : DomainObject
    {

        public string? Name { get; set; }  

        [ForeignKey("Class")]                                                   //Student -> Class(1-M)
        public Guid ClassId { get; set; }
        public ClassroomEntity? Class { get; set; }


        [ForeignKey("School")]                                                  //Student -> School(1-M)
        public Guid SchoolId { get; set; }
        public SchoolEntity? School { get; set; }

        
        [ForeignKey("Parent")]                                                  //Student -> Parent (1-1)
        public Guid ParentId { get; set; }    
        public ParentEntity? Parent { get; set; }

                                                    
        public virtual ICollection<StudentTeacherEntity>? StudentTeachers { get; set; }    //Student -> Teacher(M-M)
    }
}
