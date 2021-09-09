using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataTopError.Models;

namespace ODataTopError.Controllers
{
    [ODataRouteComponent("v1")]
    public class SchoolsController : ODataController
    {
        private readonly ApplicationDbContext _db;

        public SchoolsController(ApplicationDbContext db)
        {
            _db = db;
            if (!_db.Schools.Any())
            {
                _db.Schools.Add(new School
                {
                    Name = "Some school",
                    Students = new List<Student>(new[]
                    {
                        new Student
                        {
                            Name = "Bob"
                        },
                        new Student
                        {
                            Name = "Bettie"
                        }
                    })
                });
                _db.Schools.Add(new School
                {
                    Name = "Some other school",
                    Students = new List<Student>(new[]
                    {
                        new Student
                        {
                            Name = "Jane"
                        },
                        new Student
                        {
                            Name = "Jill"
                        }
                    })
                });
                _db.SaveChanges();
            }
        }

        [HttpGet]
        [EnableQuery(PageSize = 50)]
        public ActionResult<IEnumerable<School>> Get()
        {
            return Ok(_db.Schools);
        }
    }
}