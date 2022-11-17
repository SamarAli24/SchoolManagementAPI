using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain
{
    public class ModifiedObject:DomainObject
    {
        public ModifiedObject()
        {
            Modified_Date = DateTime.UtcNow;
            Modified_By = "system";
            Active = true;
            Delete = false;
        }
        public DateTime Modified_Date { get; set; }

        [StringLength(30)]
        public string Modified_By { get; set; } = "";
        public bool Active { get; set; }
        public bool Delete { get; set; }

    }
}
