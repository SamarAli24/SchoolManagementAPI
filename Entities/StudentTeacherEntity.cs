using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Entities
{
    public class StudentTeacherEntity : DomainObject
    {
        public Guid TeacherId { get; set; }                              //Teacher <-> Student (M-M)
        public Guid StudentId { get; set; }

        [ForeignKey("TeacherId")]
        public TeacherEntity? Teacher { get; set; }
        [ForeignKey("StudentId")]
        public StudentEntity? Student { get; set; }

    }
}
