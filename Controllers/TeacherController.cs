using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Dto;
using SchoolManagement.Interface;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacher teacher;
        private readonly IMapper mapper;


        public TeacherController(ITeacher _teacher, IMapper map)
        {
            teacher=_teacher;
            mapper = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var list = await teacher.GetAllTeachersAsync();
            var data = mapper.Map<List<Teacher>>(list);
            return Ok(data);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeachersById(Guid id)
        {
            var list = await teacher.GetTeachersByIdAsync(id);
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeachers(Guid id,Teacher teacherObj)
        {
            var data = await teacher.AddTeachersAsync(id,teacherObj);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeachers(Guid id,Teacher teacherObj)
        {
            var data = await teacher.UpdateTeachersAsync(id, teacherObj);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParents(Guid id)
        {
            await teacher.DeleteTeacherAsync(id);
            return Ok();
        }



    }
}
