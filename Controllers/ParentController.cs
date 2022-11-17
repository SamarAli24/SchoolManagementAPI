using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Dto;
using SchoolManagement.Interface;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        
            private readonly IParent parent;
            private readonly IMapper mapper;
            public ParentController(IParent _parent, IMapper map)
            {
                parent = _parent;
                mapper = map;

            }

            [HttpGet]
            public async Task<IActionResult> GetAllParents()
            {
                var list = await parent.GetAllParentAsync();
                var data = mapper.Map<List<Parents>>(list);
                return Ok(data);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetParentsById(Guid id)
            {
                var record = await parent.GetParentsByIdAsync(id);
                if (record == null)
                {
                    return NotFound();
                }
                return Ok(record);
            }

            [HttpPost]

            public async Task<IActionResult> AddParents(Parents parentObj)
            {
                var data = await parent.AddParentsAsync(parentObj);
                return Ok(data);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateParents(Guid id, Parents parentObj)
            {
                var data = await parent.UpdateParentsAsync(id, parentObj);
                return Ok(data);
            }

            [HttpDelete]
            public async Task<IActionResult> DeleteParents(Guid id)
            {
                await parent.DeleteParentsAsync(id);
                return Ok();
            }


    }
}
