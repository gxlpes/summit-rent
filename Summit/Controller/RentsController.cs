using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summit.Data;
using Summit.Models;

namespace Summit.Controller
{
    [Route("api/rents")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Rents
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Rent>>> GetRent()
        {
            return await _context.Rent.ToListAsync();
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRent(int id)
        {
            var rent = await _context.Rent.FindAsync(id);

            if (rent == null)
            {
                return NotFound();
            }

            return rent;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent(int id, Rent rent)
        {
            if (id != rent.Id)
            {
                return BadRequest();
            }

            _context.Entry(rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rent>> PostRent(int carId, int clientId, string date, Description description)
        {
            // Retrieve the Car and Client instances based on the provided IDs.
            var car = await _context.Car.FindAsync(carId);
            var client = await _context.Client.FindAsync(clientId);

            if (car == null || client == null)
            {
                return NotFound(); // Handle the case where car or client doesn't exist.
            }

            // Try to parse the date string in the "dd/MM/yyyy" format.
            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var rentDate))
            {
                return BadRequest("Invalid date format. Please provide the date in dd/MM/yyyy format.");
            }

            // Create a new Rent instance and associate it with the Car and Client.
            var rent = new Rent
            {
                Car = car,
                Client = client,
                Date = rentDate, // Set the parsed rent date.
                Description = description
            };

            _context.Rent.Add(rent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRent", new { id = rent.Id }, rent);
        }



        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRent(int id)
        {
            var rent = await _context.Rent.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            _context.Rent.Remove(rent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentExists(int id)
        {
            return _context.Rent.Any(e => e.Id == id);
        }
    }
}
