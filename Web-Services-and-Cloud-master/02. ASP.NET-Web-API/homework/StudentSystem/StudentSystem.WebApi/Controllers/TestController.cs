using StudentSystem.Data;
using StudentSystem.Data.Repositories;
using StudentSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSystem.WebApi.Controllers
{
    public class TestController : ApiController
    {
        private IStudentSystemDbContext context;
        private GenericRepository<Test> repository;

        public TestController()
            : this(new StudentSystemDbContext())
        {
        }

        public TestController(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repository = new GenericRepository<Test>(this.context);
        }

        public IHttpActionResult Get()
        {
            return this.Ok(this.repository.All().ToList());
        }

        public IHttpActionResult Get(int id)
        {
            var student = this.repository.All().FirstOrDefault(x => x.Id == id);

            if (student == null)
            {
                return this.NotFound();
            }

            return this.Ok(student);
        }

        public void Post(Test test)
        {
            this.repository.Add(test);
        }

        public void Put(int id, Test test)
        {
            this.repository.Update(test);
        }

        public void Delete(int id)
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
