using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext;
using SchoolManagement.Dto;
using SchoolManagement.Entities;
using SchoolManagement.Interface;

namespace SchoolManagement.Repository
{
    public class TeacherRepository: ITeacher
    {
        private readonly SchoolContext _context;
        private readonly IMapper mapper;

        public TeacherRepository(SchoolContext context, IMapper Map)
        {
            _context = context;
            mapper = Map;
        }


        public async Task<List<TeacherEntity>> GetAllTeachersAsync()
        {
            var data = await _context!.Teacher.Include(x => x.School).Include(y => y.Classroom).ToListAsync();
            return data;
        }


        public async Task<Teacher> GetTeachersByIdAsync(Guid id)
        {
            var data = await _context!.Teacher!.FindAsync(id);
            return mapper.Map<Teacher>(data);
        }

        public async Task<Guid> AddTeachersAsync(Guid id,Teacher teacherObj)
        {
            var data = new TeacherEntity()
            {
                Name= teacherObj.Name,
                ClassId=teacherObj.ClassId,
                SchoolId=teacherObj.SchoolId,
            };

            _context.Teacher.Add(data);
            await _context.SaveChangesAsync();
            return id;

        }

        public async Task<Guid> UpdateTeachersAsync(Guid id, Teacher teacherObj)
        {
            var data = new StudentEntity()
            {
                Id = id,
                Name = teacherObj.Name,
                ClassId = teacherObj.ClassId,
                SchoolId = teacherObj.SchoolId,

            };

            _context.Update(data);
            await _context.SaveChangesAsync();
            return id;

        }
        public async Task DeleteTeacherAsync(Guid id)
        {
            var data = new TeacherEntity()
            {
                Id=id,
            };
            _context.Remove(data);
            await _context.SaveChangesAsync();
            

        }





    }
}
