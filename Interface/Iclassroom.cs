using SchoolManagement.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.Interface
{
    public interface Iclassroom
    {
        Task<List<ClassroomEntity>> GetAllClassroomAsync();
        Task<Classroom> GetClassByIdAsync(Guid id);
        Task<string> AddClassAsync(Classroom classObj);
        Task<Guid> UpdateClassAsync(Guid id, Classroom classObj);
        Task DeleteClassAsync(Guid id);
    }
}
