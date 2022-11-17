using SchoolManagement.DBContext.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.Interface
{
    public interface IStudentTeacher
    {
        Task<List<StudentTeacherEntity>> GetAllStudents_And_TeachersAync();
        Task<StudentTeacherEntity> GetAllStudents_And_TeachersByIdAsync(Guid id);
        Task<Guid> AddStudents_And_TeachersAsync(StudentTeacherEntity obj);
        Task<Guid> UpdateStudent_And_TeachersAsync(StudentTeacherEntity obj);
         Task<Guid> DeleteStudents_And_TeachersAsync(Guid id);
    }
}
