using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<ActionResult<List<MeasurementEntry>>> Get(){
            
            return await _context.MeasurementEntries.ToListAsync();
        }
    }
}