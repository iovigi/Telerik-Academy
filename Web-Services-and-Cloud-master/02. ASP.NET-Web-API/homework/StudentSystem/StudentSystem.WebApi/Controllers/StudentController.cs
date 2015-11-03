using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.Data;
using StudentSystem.Data.Repositories;
using StudentSystem.Models;

namespace StudentSystem.WebApi.Controllers
{
    public class StudentController : ApiController
    {
        private IStudentSystemDbContext context;
        private StudentsRepository repository;

        public StudentController()
            : this(new StudentSystemDbContext())
        {
        }

        public StudentController(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repository = new StudentsRepository(this.context);
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.repository.All().ToList());
        }
        
        public IHttpActionResult Get(int studentIdentification)
        {
            var student = this.repository.All().FirstOrDefault(x => x.StudentIdentification == studentIdentification);

            if (student == null)
            {
                return this.NotFound();
            }

            return this.Ok(student);
        }

        // POST: api/Student
        public void Post(Student student)
        {
            this.repository.Add(student);
        }

        // PUT: api/Student/5
        public void Put(int studentIdentification, Student value)
        {
            this.repository.Update(value);
        }

        // DELETE: api/Student/5
        public void Delete(int studentIdentification)
        {
            var student = this.repository.All().FirstOrDefault(x => x.StudentIdentification == studentIdentification);

            if (student == null)
            {
                return;
            }

            this.repository.Delete(student);
        }
    }
}
