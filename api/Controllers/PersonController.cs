using System.Text.Json;
using api.Data;
using api.Entities;
using api.Enums;
using api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
	public class PersonController : BaseApiController
	{
		private readonly DataContext _context;

		public PersonController(DataContext context)
		{
			_context = context;
		}

		#region [Methods]

		[HttpGet]
		public async Task<ActionResult<List<Person>>> Get()
		{
			return await _context.Persons.ToListAsync();
		}

		[HttpGet("{id}", Name = "GetPersonById")]
		public async Task<ActionResult<Person>> Get(int id)
		{
			var person = await _context.Persons.FindAsync(id);
			if (person == null)
				return NotFound();

			return person;
		}

		[HttpPost]
		public async Task<ActionResult<Person>> Add(Person person)
		{
			if (person == null)
				return BadRequest(new ProblemDetails { Title = "Problem saving person" });

			person.UserNameCreator = "system.person.add";
			person.UserNameLastChange = "system.person.add";
			person.CreationDate = DateTime.Now;
			person.LastChangeDate = DateTime.Now;

			await _context.Persons.AddAsync(person);
			var result = await _context.SaveChangesAsync() > 0;

			if (result)
				return CreatedAtRoute("GetPersonById", routeValues: new { id = person.Id }, value: person);

			return BadRequest(new ProblemDetails { Title = "Problem saving person" });
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			var person = await _context.Persons.FindAsync(id);
			if (person == null)
				return NotFound();

			_context.Persons.Remove(person);

			return await _context.SaveChangesAsync() > 0 ? Ok() : BadRequest(new ProblemDetails { Title = "Problem deleting person" });
		}

		[HttpPut]
		public async Task<ActionResult> Update(Person person)
		{
			if (person == null || person.Id == 0)
				return BadRequest(new ProblemDetails{Title = "Person ID in the request body does not match the route parameter"});

			var storedPerson = await _context.Persons.FindAsync(person.Id);
			if (storedPerson == null)
				return NotFound(new ProblemDetails { Title = "Person not found" });

			EPersonType[] ePersonTypeValues = (EPersonType[]) Enum.GetValues(typeof(EPersonType));
			if(!ePersonTypeValues.Contains(person.PersonType)){
				var detailMessage = EnumHelper.GetEnumData<EPersonType>();
				return BadRequest(new ProblemDetails{Title = "Person Type in the request body does not match with person types available", Detail = detailMessage});
			}
			
			storedPerson.Name = person.Name;
			storedPerson.PersonType = person.PersonType;
			storedPerson.BirthDate = person.BirthDate;
			storedPerson.LastChangeDate = DateTime.UtcNow;
			storedPerson.UserNameLastChange = "system.person.update";

			return await _context.SaveChangesAsync() > 0 ? Ok(storedPerson) : BadRequest(new ProblemDetails { Title = "Problem updating person" });
		}
		
		#endregion



	}
}
