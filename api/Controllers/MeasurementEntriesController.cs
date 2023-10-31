using api.Data;
using api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
	public class MeasurementEntriesController : BaseApiController
	{
		private readonly DataContext _context;

		public MeasurementEntriesController(DataContext context)
		{
			_context = context;
		}

		#region [ Default Methods ]
		
		[HttpGet]
		public async Task<ActionResult<List<MeasurementEntry>>> Get()
		{
			return await _context.MeasurementEntries.ToListAsync();
		}

		[HttpGet("{id}", Name = "GetMeasurementEntryById")]
		public async Task<ActionResult<MeasurementEntry>> Get(int id)
		{
			var measurementEntry = await _context.MeasurementEntries.FindAsync(id);
			if (measurementEntry == null)
				return NotFound();

			return measurementEntry;
		}

		[HttpPost]
		public async Task<ActionResult<MeasurementEntry>> Add(MeasurementEntry measurementEntry)
		{
			if (measurementEntry == null)
				return BadRequest();

			measurementEntry.CreationDate = DateTime.Now;
			measurementEntry.UserNameCreator = "system.measurementEntry.update";

			await _context.MeasurementEntries.AddAsync(measurementEntry);
			var result = await _context.SaveChangesAsync() < 0;

			if (result)
				return CreatedAtRoute(
					"GetMeasurementEntryById",
					routeValues: new { id = measurementEntry.Id },
					value: measurementEntry
				);

			return BadRequest(new ProblemDetails { Title = "Problem saving measurementEntry" });
		}

		[HttpPut]
		public async Task<ActionResult<MeasurementEntry>> Update(int id, MeasurementEntry measurementEntry)
		{
			if (measurementEntry == null || measurementEntry.Id == 0)
				return BadRequest(
					new ProblemDetails
					{
						Title = "Person ID in the request body does not match the route parameter"
					}
				);

			var storedMeasurementEntry = await _context.MeasurementEntries.FindAsync(id);
			if (storedMeasurementEntry == null)
				return BadRequest();

			storedMeasurementEntry.Height = measurementEntry.Height;
			storedMeasurementEntry.Weight = measurementEntry.Weight;
			storedMeasurementEntry.Shoulders = measurementEntry.Shoulders;
			storedMeasurementEntry.Chest = measurementEntry.Chest;
			storedMeasurementEntry.Waist = measurementEntry.Waist;
			storedMeasurementEntry.Hip = measurementEntry.Hip;
			storedMeasurementEntry.RelaxedRightArm = measurementEntry.RelaxedRightArm;
			storedMeasurementEntry.RelaxedLeftArm = measurementEntry.RelaxedLeftArm;
			storedMeasurementEntry.ContractedRightArm = measurementEntry.ContractedRightArm;
			storedMeasurementEntry.ContractedLeftArm = measurementEntry.ContractedLeftArm;
			storedMeasurementEntry.RightForearm = measurementEntry.RightForearm;
			storedMeasurementEntry.LeftForearm = measurementEntry.LeftForearm;
			storedMeasurementEntry.RightThigh = measurementEntry.RightThigh;
			storedMeasurementEntry.LeftThigh = measurementEntry.LeftThigh;
			storedMeasurementEntry.RightCalf = measurementEntry.RightCalf;
			storedMeasurementEntry.LeftCalf = measurementEntry.LeftCalf;
			storedMeasurementEntry.EntryDate = measurementEntry.EntryDate;
			storedMeasurementEntry.PersonId = measurementEntry.PersonId;

			storedMeasurementEntry.LastChangeDate = DateTime.Now;
			storedMeasurementEntry.UserNameLastChange = "system.measurementEntry.update";

			return await _context.SaveChangesAsync() > 0
				? Ok(storedMeasurementEntry)
				: BadRequest(new ProblemDetails { Title = "Problem updating measurementEntry" });
		}
	
		[HttpDelete]
		public async Task<ActionResult<MeasurementEntry>> Delete(int id)
		{
			var measurementEntry = await _context.MeasurementEntries.FindAsync(id);
			if(measurementEntry is null)
				return NotFound();
				
			_context.Remove(measurementEntry);
			return await _context.SaveChangesAsync() > 0
				? Ok()
				: BadRequest(new ProblemDetails { Title = "Problem updating measurementEntry" });
		}
	
		#endregion
	
		[HttpGet("GetByPerson/{personId}", Name = "GetByPerson")]
		public async Task<ActionResult<List<MeasurementEntry>>> GetByPerson(int personId){

			var measurementEntries = await _context.MeasurementEntries.Where(x=> x.PersonId == personId)
																	  .ToListAsync();
																	   
			if(measurementEntries?.Count == 0)
				return Ok(Enumerable.Empty<MeasurementEntry>());
				
			return measurementEntries;
		}
	
	}
}