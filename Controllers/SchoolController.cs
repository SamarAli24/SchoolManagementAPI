using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Dto;
using SchoolManagement.Interface;

namespace SchoolManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchool school;
        private readonly IMapper mapper;
        public SchoolController(ISchool _school, IMapper map)
        {
            school = _school;
            mapper = map;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchool()
        {
            var list = await school.GetAllSchoolAsync();
            var data = mapper.Map<List<School>>(list);
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolById(Guid id)
        {
            var record = await school.GetSchoolByIdAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            return Ok(record);
        }

        [HttpPost]

        public async Task<IActionResult> AddSchool(School schoolObj)
        {
            var data = await school.AddSchoolAsync(schoolObj);
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchool(Guid id, School schoolObj)
        {
            var data = await school.UpdateSchoolAsync(id, schoolObj);
            return Ok(data);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchool(Guid id)
        {
            await school.DeleteSchoolAsync(id);
            return Ok();
        }

    }
}
