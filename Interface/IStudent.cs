using SchoolManagement.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.Interface
{
    public interface IStudent
    {
        Task<List<StudentEntity>> GetAllStudentsAsync();
        Task<Student> GetStudentsByIdAsync(Guid id);
        Task<string> AddStudentAsync(Student studentObj);
        Task<Guid> UpdateStudentAsync(Guid id, Student studentObj);
        Task DeleteStudentAsync(Guid id);
    }
}
