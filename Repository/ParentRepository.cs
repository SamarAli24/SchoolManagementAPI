using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.DBContext;
using SchoolManagement.Dto;
using SchoolManagement.Entities;
using SchoolManagement.Interface;

namespace SchoolManagement.Repository
{
    public class ParentRepository:IParent
    {
           private readonly SchoolContext _context;
            private readonly IMapper mapper;

            public ParentRepository(SchoolContext context, IMapper Map)
            {
                _context = context;
                mapper = Map;
            }

            public async Task<List<ParentEntity>> GetAllParentAsync()
            {
            var data = await _context!.Parent!.ToListAsync();
                return data;
            }

            public async Task<Parents> GetParentsByIdAsync(Guid id)
            {
                var Id = await _context!.Parent!.FindAsync(id);
                return mapper.Map<Parents>(Id);

            }

            public async Task<string> AddParentsAsync(Parents parentObj)
            {
                var data = new ParentEntity()
                {
                    fName = parentObj.fName,
                    mName=parentObj.mName,
                };

                _context.Add(data);
                await _context.SaveChangesAsync();
                return parentObj.fName;
            }

            public async Task<Guid> UpdateParentsAsync(Guid id, Parents parentObj)
            {
                var data = new ParentEntity()
                {
                    Id = id,
                    fName = parentObj.fName,
                    mName = parentObj.mName,
                };

                _context.Update(data);
                await _context.SaveChangesAsync();
                return id;

            }

            public async Task DeleteParentsAsync(Guid id)
            {
                var data = new ParentEntity()
                {
                    Id = id,
                };
                _context.Remove(data);
                await _context.SaveChangesAsync();
            }



        
    }
}
