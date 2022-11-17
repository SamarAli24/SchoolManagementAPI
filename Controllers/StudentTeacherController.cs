using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.DBContext.Dto;
using SchoolManagement.Entities;
using SchoolManagement.Interface;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentTeacherController : ControllerBase
    {
        private readonly IStudentTeacher schoolTeacher;
        private readonly IMapper mapper;
        public StudentTeacherController(IStudentTeacher _schoolTeacher, IMapper map)
        {
            schoolTeacher = _schoolTeacher;
            mapper = map;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent_And_Teacher()
        {
            var list = await schoolTeacher.GetAllStudents_And_TeachersAync();
            var data = mapper.Map<List<StudentAndTeacher>>(list);
            return Ok(data);

        }
        public async Task<IActionResult> GetAllStudent_And_TeacherById(Guid id)
        {
            var list = await schoolTeacher.GetAllStudents_And_TeachersByIdAsync(id);
            var data = mapper.Map<List<StudentAndTeacher>>(list);
            return Ok(data);

        }



        [HttpPost]
        public async Task<IActionResult> AddStudent_And_Teacher(StudentAndTeacher obj)
        {
            var map = mapper.Map<StudentTeacherEntity>(obj);
            var data = await schoolTeacher.AddStudents_And_TeachersAsync(map);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent_And_Teacher(StudentAndTeacher obj)
        {

            var map = mapper.Map<StudentTeacherEntity>(obj);
            var data = await schoolTeacher.UpdateStudent_And_TeachersAsync(map);
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent_And_Teacher(Guid id)
        {

            var data = await schoolTeacher.DeleteStudents_And_TeachersAsync(id);
            return Ok(data);
        }



    }
}

