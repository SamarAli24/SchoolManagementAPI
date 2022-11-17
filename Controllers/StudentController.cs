using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Dto;
using SchoolManagement.Interface;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase 
    {
        private readonly IStudent student;
        private readonly IMapper mapper;

        public StudentController(IStudent _student,IMapper map)
        {
            student = _student;
            mapper = map;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var list = await student.GetAllStudentsAsync();
            var data= mapper.Map<List<Student>>(list);
            return Ok(data);
             
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentsById(Guid id)
        {
            var record = await student.GetStudentsByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]

        public async Task<IActionResult> AddParents(Student studentObj)
        {
            var data = await student.AddStudentAsync(studentObj);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudents(Guid id, Student studentObj)
        {
            var data = await student.UpdateStudentAsync(id,studentObj);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteParents(Guid id)
        {
            await student.DeleteStudentAsync(id);
            return Ok();
        }






    }
}
