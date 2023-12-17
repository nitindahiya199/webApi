using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;  // Add this line for List<T>

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>();

        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public ActionResult<Student> Get(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();  // Return 404 if the student is not found
            }
            return student;
        }

        // POST api/<StudentController>
        [HttpPost]
        public ActionResult Post([FromBody] Student value)
        {
            students.Add(value);
            return CreatedAtAction(nameof(Get), new { id = value.Id }, value);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student value)
        {
            int i = students.FindIndex(s => s.Id == id);
            if (i == -1)
            {
                return NotFound();  // Return 404 if the student is not found
            }
            students[i] = value;
            return NoContent();  // Return 204 for successful update
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int removedCount = students.RemoveAll(s => s.Id == id);
            if (removedCount == 0)
            {
                return NotFound();  // Return 404 if the student is not found
            }
            return NoContent();  // Return 204 for successful deletion
        }
    }
}
