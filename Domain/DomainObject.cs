using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain
{
    public class DomainObject
    {
        public DomainObject()
        {          
            Created_Date = DateTime.UtcNow;
            Created_By = "system";
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime Created_Date { get; set; }
        [StringLength(30)]
        public string Created_By { get; set; } = "";
    }
}

