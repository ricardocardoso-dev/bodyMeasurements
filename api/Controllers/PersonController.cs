using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class PersonController : BaseApiController
    {
        private readonly DataContext _context;

        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            var persons = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    Name = "Ricardo",
                    BirthDate = DateTime.Now
                },
                new Person
                {
                    Id = 2,
                    Name = "Vilela",
                    BirthDate = DateTime.Now
                },
                new Person
                {
                    Id = 3,
                    Name = "Sacani",
                    BirthDate = DateTime.Now
                }
            };

            return await Task.FromResult(persons);
        }
    }
}
