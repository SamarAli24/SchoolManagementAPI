using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext;
using SchoolManagement.Dto;
using SchoolManagement.Entities;
using SchoolManagement.Interface;

namespace SchoolManagement.Repository
{
    public class StudentRepository:IStudent
    {
            private readonly SchoolContext _context;
            private readonly IMapper mapper;

            public StudentRepository(SchoolContext context, IMapper Map)
            {
                _context = context;
                mapper = Map;
            }

            public async Task<List<StudentEntity>> GetAllStudentsAsync()
            {
                var data = await _context!.Student!.Include(x => x.Parent).Include(y=>y.School)
                .Include(z=>z.Class).ToListAsync();
                return data;
            }
       
            public async Task<Student> GetStudentsByIdAsync(Guid id)
            {
                var Id = await _context!.Student!.FindAsync(id);
                return mapper.Map<Student>(Id);

            }

            public async Task<string> AddStudentAsync(Student studentObj)
            {
                var data = new StudentEntity()
                {
                    Name = studentObj.Name,
                    ClassId=studentObj.ClassId,
                    SchoolId=studentObj.SchoolId,
                    ParentId=studentObj.ParentId,

 
                };

                _context.Student.Add(data);
                await _context.SaveChangesAsync();
                return studentObj.Name;
            }

            public async Task<Guid> UpdateStudentAsync(Guid id, Student studentObj)
            {
            var data = new StudentEntity()
            {
                Id = id,
                Name = studentObj.Name,
                ClassId = studentObj.ClassId,
                SchoolId=studentObj.SchoolId,
                ParentId= studentObj.ParentId,

            };

                _context.Update(data);
                await _context.SaveChangesAsync();
                return id;

            }

            public async Task DeleteStudentAsync(Guid id)
            {
                var data = new StudentEntity()
                {
                    Id = id,
                };
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }
        
    }
}
