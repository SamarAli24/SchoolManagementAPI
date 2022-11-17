using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Dto;
using SchoolManagement.Interface;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly Iclassroom classroom;
        private readonly IMapper mapper;
        public ClassroomController(Iclassroom _classroom , IMapper map)
        {
            classroom = _classroom; 
            mapper = map;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllClassroom()
        {
            var list = await classroom.GetAllClassroomAsync();
            var data= mapper.Map<List<Classroom>>(list);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetClassroomById(Guid id)
        {
            var record = await classroom.GetClassByIdAsync(id);
            if(record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]

        public async Task<IActionResult> AddClassroom(Classroom classObj)
        {
            var data = await classroom.AddClassAsync(classObj);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClassroom(Guid id,Classroom classObj)
        {
            var data = await classroom.UpdateClassAsync(id,classObj);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteClassroom(Guid id)
        {
            await classroom.DeleteClassAsync(id);
            return Ok();
        }






    }
}
