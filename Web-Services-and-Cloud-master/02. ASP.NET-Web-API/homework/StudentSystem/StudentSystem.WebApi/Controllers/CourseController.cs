using StudentSystem.Data;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentSystem.Data.Repositories;

namespace StudentSystem.WebApi.Controllers
{
    public class CourseController : ApiController
    {
        private IStudentSystemDbContext context;
        private GenericRepository<Course> repository;

        public CourseController()
            : this(new StudentSystemDbContext())
        {
        }

        public CourseController(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repository = new GenericRepository<Course>(this.context);
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.repository.All().ToList());
        }

        public IHttpActionResult Get(Guid id)
        {
            var student = this.repository.All().FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return this.NotFound();
            }

            return this.Ok(student);
        }

        public void Post(Course course)
        {
            this.repository.Add(course);
        }

        public void Put(Guid id, Course course)
        {
            this.repository.Update(course);
        }

        public void Delete(Guid id)
        {
            var student = this.repository.All().FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return;
            }

            this.repository.Delete(student);
        }
    }
}
