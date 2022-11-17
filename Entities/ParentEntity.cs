using SchoolManagement.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagement.Entities
{
    public class ParentEntity : DomainObject
    {
        public string? fName { get; set; } 
        public string? mName { get; set; }  

        //[ForeignKey("student")]                           //Parent -> Student (1-1)
        //public Guid StudentId { get; set; }
       // public StudentEntity? student { get; set; }
    }
}
