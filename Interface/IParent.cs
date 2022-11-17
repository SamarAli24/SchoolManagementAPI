using SchoolManagement.Dto;
using SchoolManagement.Entities;

namespace SchoolManagement.Interface
{
    public interface IParent
    {
        Task<List<ParentEntity>> GetAllParentAsync();
        Task<Parents> GetParentsByIdAsync(Guid id);
        Task<string> AddParentsAsync(Parents parentObj);
        Task<Guid> UpdateParentsAsync(Guid id, Parents parentObj);
        Task DeleteParentsAsync(Guid id);
    }
}
