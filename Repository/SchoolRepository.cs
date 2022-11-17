using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext;
using SchoolManagement.Dto;
using SchoolManagement.Entities;
using SchoolManagement.Interface;

namespace SchoolManagement.Repository
{
   
        public class SchoolRepository : ISchool
        {
            private readonly SchoolContext _context;
            private readonly IMapper mapper;

            public SchoolRepository(SchoolContext context, IMapper Map)
            {
                _context = context;
                mapper = Map;
            }

            public async Task<List<SchoolEntity>> GetAllSchoolAsync()
            {
            var data = await _context!.School!.ToListAsync();
                return data;
            }

            public async Task<School> GetSchoolByIdAsync(Guid id)
            {
                var Id = await _context!.School!.FindAsync(id);
                return mapper.Map<School>(Id);

            }

        public async Task<string> AddSchoolAsync(School schoolObj)
            {
                var data = new SchoolEntity()
                {
                    Name = schoolObj.Name,
                };

                _context.Add(data);
                await _context.SaveChangesAsync();
                return schoolObj.Name;
            }

            public async Task<Guid> UpdateSchoolAsync(Guid id, School schoolObj)
            {
                var data = new SchoolEntity()
                {
                    Id = id,
                    Name = schoolObj.Name,
                };

                _context.Update(data);
                await _context.SaveChangesAsync();
                return id;

            }

            public async Task DeleteSchoolAsync(Guid id)
            {
                var data = new SchoolEntity()
                {
                    Id = id,
                };
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }







        }


   
}
