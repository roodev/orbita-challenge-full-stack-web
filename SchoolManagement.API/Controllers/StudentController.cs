using Microsoft.AspNetCore.Mvc;
using SchoolManagement.API.Models;
using SchoolManagement.API.Repository;
using SchoolManagement.API.Services;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        SchoolManagementContext _ctx;
        private readonly IService<Student> _service;
        public StudentController(IRepository repository)
        {
            _service = new StudentServices(repository);
        }

        [HttpGet("getstudents")]
        public IActionResult GetAllStudents() 
        {
            var studentService =  _service.List();
            return Ok(studentService);
        }
        
        [HttpGet("getstudentbyid/{id}")]
        public IActionResult GetStudentById(int id) 
        {
            var studentService =  _service.GetStudentById(id);
            return Ok(studentService);
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student) 
        {
            return Ok(_service.Add(student));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id) 
        {
            return Ok(_service.Delete(id));
        }
        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student student) 
        {
            return Ok(_service.Update(student));
        }

    }
}
