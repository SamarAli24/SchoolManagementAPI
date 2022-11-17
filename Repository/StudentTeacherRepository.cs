using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext;
using SchoolManagement.DBContext.Dto;
using SchoolManagement.Dto;
using SchoolManagement.Entities;
using SchoolManagement.Interface;

namespace SchoolManagement.Repository
{
    public class StudentTeacherRepository:IStudentTeacher
    {
        private readonly SchoolContext _context;
        private readonly IMapper mapper;


        public StudentTeacherRepository(SchoolContext context, IMapper Map)
        {
                _context = context;
                mapper = Map;
        }


        public async Task<List<StudentTeacherEntity>> GetAllStudents_And_TeachersAync()
        {
          var data = await _context!.StudentAndTeacher.Include(x => x.Teacher).Include(y => y.Student).ToListAsync();
           return data;
        }

  
            public async Task<StudentTeacherEntity> GetAllStudents_And_TeachersByIdAsync(Guid id)
            {
                var data = await _context!.StudentAndTeacher!.FindAsync(id);
                return mapper.Map<StudentTeacherEntity>(data);
            }
     
            public async Task<Guid> AddStudents_And_TeachersAsync(StudentTeacherEntity obj)
            {
 
                _context.Add(obj);
                await _context.SaveChangesAsync();
                 return obj.StudentId;

            }

            
            public async Task<Guid> UpdateStudent_And_TeachersAsync(StudentTeacherEntity obj)
            {
 
                _context.Update(obj);
                await _context.SaveChangesAsync();
                 return obj.StudentId;

        }
            public async Task<Guid> DeleteStudents_And_TeachersAsync(Guid id)
            {
                var data = new StudentTeacherEntity()
                {
                    Id = id,
                };
                _context.Remove(data);
                await _context.SaveChangesAsync();
                    return id;


            }





        
    }
}
