using ASPCoreWebAPICRUD.DAL;
using ASPCoreWebAPICRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ASPCoreWebAPICRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly MyAppDbContext _context;

        public StudentAPIController(MyAppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var students = _context.students.ToList();
                if (students == null)
                {
                    return NotFound("Students not found");
                }
                return Ok(students);
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var student
                        = _context.students.Find(id);
                if (student == null)
                {
                    return NotFound($"Student details not found with id {id}");
                }
                return Ok(student);
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Student model)
        {
            try
            {
                _context.Add(model);
                _context.SaveChanges();
                return Ok("Products created");
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(Student model)
        {
            if (model == null || model.Id == 0)
            {
                if (model == null)
                {
                    return BadRequest("Model data is invalid.");
                }
                else if (model.Id == 0)
                {
                    return BadRequest($"Student Id {model.Id} is invalid.");
                }

            }
            try
            {
                var student = _context.students.Find(model.Id);
                if (student == null)
                {
                    return NotFound($"Student not found with Id {model.Id}");
                }
                student.Id = model.Id;
                student.StudentName = model.StudentName;
                student.StudentGender = model.StudentGender;
                student.Age = model.Age;
                student.Standard = model.Standard;
                student.FatherName = model.FatherName;
                _context.SaveChanges();
                return Ok("Student details updated");
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var student
                                = _context.students.Find(id);
                if (student == null)
                {
                    return NotFound($"Student details not found with id {id}");
                }
                _context.students.Remove(student);
                _context.SaveChanges();
                return Ok("Student details deleted");
            }
            catch (Exception Ex)
            {

                return BadRequest(Ex.Message);
            }

        }
    }
}
