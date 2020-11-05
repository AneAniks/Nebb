using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nebb.Data.Models;

namespace Nebb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerAPIController : ControllerBase
    {
        private readonly NebbContext _context;

        public PassengerAPIController(NebbContext context)
        {
            _context = context;
        }

        // GET: api/PassengerAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PassengerInfo>>> GetPassengerInfo()
        {
            return await _context.PassengerInfo.ToListAsync();
        }

        // GET: api/PassengerAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PassengerInfo>> GetPassengerInfo(int id)
        {
            var passengerInfo = await _context.PassengerInfo.FindAsync(id);

            if (passengerInfo == null)
            {
                return NotFound();
            }

            return passengerInfo;
        }

        // PUT: api/PassengerAPI/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassengerInfo(int id, PassengerInfo passengerInfo)
        {
            if (id != passengerInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(passengerInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PassengerAPI
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PassengerInfo>> PostPassengerInfo(PassengerInfo passengerInfo)
        {
            _context.PassengerInfo.Add(passengerInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassengerInfo", new { id = passengerInfo.Id }, passengerInfo);
        }

        // DELETE: api/PassengerAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PassengerInfo>> DeletePassengerInfo(int id)
        {
            var passengerInfo = await _context.PassengerInfo.FindAsync(id);
            if (passengerInfo == null)
            {
                return NotFound();
            }

            _context.PassengerInfo.Remove(passengerInfo);
            await _context.SaveChangesAsync();

            return passengerInfo;
        }

        private bool PassengerInfoExists(int id)
        {
            return _context.PassengerInfo.Any(e => e.Id == id);
        }
    }
}
