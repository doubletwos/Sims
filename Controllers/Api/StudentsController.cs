using AutoMapper;
using SchoolPortal.Dtos;
using SchoolPortal.Models;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;

namespace SchoolPortal.Controllers.Api
{
    public class StudentsController : ApiController
    {
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
        }

        // GET: api/Students
        public IHttpActionResult GetStudents()
        {
            var studentDtos = _context.Students
                .Include(g => g.Gender)
                .Include(y => y.Year)
                .Include(r => r.Religion)
                .Include(t => t.Tribe)
                .ToList()
                .Select(Mapper.Map<Student, StudentDto>);
            return Ok(studentDtos);
        }

        // GET: api/Students/5
        //[ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            return Ok(Mapper.Map<Student, StudentDto>(student));
        }

        // PUT: api/Students/5
        [HttpPut]
        //[ResponseType(typeof(void))]
        public IHttpActionResult UpdateStudent(int id, StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                return NotFound();

            Mapper.Map(studentDto, studentInDb);

            _context.SaveChanges();

            return Ok();
        }

        // POST: api/Students
        [HttpPost]
        //[ResponseType(typeof(Student))]
        public IHttpActionResult CreateStudent(StudentDto studentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var student = Mapper.Map<StudentDto, Student>(studentDto);

            _context.Students.Add(student);
            _context.SaveChanges();

            studentDto.Id = student.Id;

            return Created(new Uri(Request.RequestUri + "/" + student.Id), studentDto);
        }

        [HttpDelete]
        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            var studentInDb = _context.Students.SingleOrDefault(s => s.Id == id);

            if (studentInDb == null)
                return NotFound();

            _context.Students.Remove(studentInDb);
            _context.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}