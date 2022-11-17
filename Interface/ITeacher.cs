using SchoolManagement.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.Interface
{
    public interface ITeacher
    {
        Task<List<TeacherEntity>> GetAllTeachersAsync();
        Task<Teacher> GetTeachersByIdAsync(Guid id);
        Task<Guid> AddTeachersAsync(Guid idm, Teacher teacherObj);
        Task<Guid> UpdateTeachersAsync(Guid id, Teacher teacherObj);
        Task DeleteTeacherAsync(Guid id);
    }
}
