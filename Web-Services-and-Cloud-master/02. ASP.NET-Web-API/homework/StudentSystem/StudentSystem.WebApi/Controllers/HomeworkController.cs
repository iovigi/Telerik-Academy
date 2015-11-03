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
    public class HomeworkController : ApiController
    {
        private IStudentSystemDbContext context;
        private GenericRepository<Homework> repository;

        public HomeworkController()
            : this(new StudentSystemDbContext())
        {
        }

        public HomeworkController(IStudentSystemDbContext context)
        {
            this.context = context;
            this.repository = new GenericRepository<Homework>(this.context);
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

        public void Post(Homework student)
        {
            this.repository.Add(student);
        }
        
        public void Put(int id, Homework homework)
        {
            this.repository.Update(homework);
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
