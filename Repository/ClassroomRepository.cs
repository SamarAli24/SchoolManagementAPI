using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext;
using SchoolManagement.Dto;
using SchoolManagement.Entities;
using SchoolManagement.Interface;
using System.Collections.Generic;

namespace SchoolManagement.Repository
{
    public class ClassroomRepository:Iclassroom
    {
        private readonly SchoolContext _context;
        private readonly IMapper mapper;

        public ClassroomRepository(SchoolContext context,IMapper Map)
        {
            _context = context;
            mapper = Map;
        }

        public async Task<List<ClassroomEntity>> GetAllClassroomAsync()
        {
            var data = await _context!.Class!.ToListAsync();
            return data;
        }

        public async Task<Classroom> GetClassByIdAsync(Guid id)
        {
            var Id = await _context!.Class!.FindAsync(id);
            return mapper.Map<Classroom>(Id);   

        }

        public async Task<string> AddClassAsync(Classroom classObj)
        {
            var data = new ClassroomEntity()
            {
                Name = classObj.Name,
            };

            _context.Add(data);
            await _context.SaveChangesAsync();
            return classObj.Name;
        }

        public async Task<Guid> UpdateClassAsync(Guid id, Classroom classObj)
        {
            var data = new ClassroomEntity()
            {
                Id = id,
                Name = classObj.Name,
            };

            _context.Update(data);
            await _context.SaveChangesAsync();
            return id;

        }

        public async Task DeleteClassAsync(Guid id)
        {
            var data = new ClassroomEntity()
            {
                Id=id,
            };
            _context.Remove(data);
            await _context.SaveChangesAsync();
        }



    }
}
