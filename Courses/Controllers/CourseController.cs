using Courses.Models;
using Microsoft.AspNetCore.Mvc;
namespace Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        public ITIContext Db { get; }
        public CourseController(ITIContext db)
        {
            Db = db;
        }
        [HttpGet]
        public ActionResult Get()
        {
            var allCourses = Db.Courses.ToList();
            if (allCourses == null) { return NotFound();}
            else {return Ok(allCourses);}
        }
        [HttpGet("{id}")]
        public ActionResult GetById(int id) { 
            var course = Db.Courses.SingleOrDefault(c => c.Id == id);

            if (course == null) { return NotFound(); }
            else { return Ok(course); }
        }
        [HttpGet("/api/crs/{name}")]
        public ActionResult GetByName(string name) {
            var course = Db.Courses.SingleOrDefault(c => c.Crs_name == name);
            if (course == null) { return NotFound(); }
            else { return Ok(course); }
        }
        [HttpPost]
        public ActionResult Add(Course course) { 
            if (course == null) { return BadRequest(); }
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            else
            {
                Db.Add(course);
                Db.SaveChanges();
                return CreatedAtAction("GetById", new {id = course.Id},course);
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id) {
            var course = Db.Courses.Find(id);
            if (course == null) { return NotFound(); }
            else
            {
                Db.Courses.Remove(course);
                Db.SaveChanges();
                var allCourses = Db.Courses.ToList();
                return Ok(allCourses);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Put(Course course, int id)
        {
            if (course == null) { return NotFound(); }
            if (course.Id != id) { return BadRequest(); }
            Db.Entry(course).State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            Db.SaveChanges();
            return NoContent();
        }
    }

}
