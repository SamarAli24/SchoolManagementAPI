using SchoolManagement.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.Interface
{
    public interface ISchool
    {
        Task<List<SchoolEntity>> GetAllSchoolAsync();
        Task<School> GetSchoolByIdAsync(Guid id);
        Task<string> AddSchoolAsync(School schoolObj);
        Task<Guid> UpdateSchoolAsync(Guid id, School schoolObj);
        Task DeleteSchoolAsync(Guid id);
    }
}
