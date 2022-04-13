using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectLast.Data;
using ProjectLast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectLast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiKebeleController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ApiKebeleController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Citizen>>> GetCitizens() {
            return await _context.Citizens.ToListAsync();
        }
        [HttpGet("{City}/{SubCity}/{Woreda}/{Kebele}")]
        public async Task<ActionResult<IEnumerable<Citizen>>> GetCitizen(string City, string SubCity, string Woreda, int Kebele)
        {
            //return await _context.Citizens.ToListAsync().f
            //
            var citi = await _context.Citizens.Where(m => m.City == City && m.SubCity == SubCity && m.Woreda == Woreda && m.Kebele == Kebele).ToListAsync();
            if (citi == null) 
            {
                return NotFound();
            }
            return citi;

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Citizen>> GetCitizenn(int id)
        {
            //return await _context.Citizens.ToListAsync().f
            //
            var citi = await _context.Citizens.FindAsync(id);
            if (citi == null)
            {
                return NotFound();
            }
            return citi;

        }
        [HttpPost]
        public async Task<ActionResult<Citizen>> PostCitizen(Citizen citizen) 
        { // SSN code Generating
            var ss = await _context.SSNs.FirstOrDefaultAsync(m => m.CityCode == citizen.CityCode);
            int ssn = int.Parse(ss.CityCode.ToString() + ss.CurrentNumber.ToString());
            // calculate Age Based on Date of Birth
            var dob = citizen.DOB;
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            //
            citizen.SSN = ssn;
            citizen.Age = age;
            //
            var city = await _context.Cities.FirstOrDefaultAsync(m => m.Code == citizen.CityCode);
            citizen.City = city.Name;
            _context.Citizens.Add(citizen);
            await _context.SaveChangesAsync();
            ss.CurrentNumber = ss.CurrentNumber + 1;

            _context.Entry(ss).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCitizen", new { id = citizen.SSN }, citizen);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCitizen(int id, Citizen citizen) 
        {
            if (id != citizen.SSN) 
            {
                return BadRequest();
            }
            var dob = citizen.DOB;
            int age = 0;
            age = DateTime.Now.Subtract(dob).Days;
            age = age / 365;
            //
            citizen.Age = age;
            _context.Entry(citizen).State = EntityState.Modified;
            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!CitizenExists(id))
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

        private bool CitizenExists(int id) 
        {
            return _context.Citizens.Any(e => e.SSN == id);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Citizen>> DeleteCitizen(int id) 
       {

            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }

            _context.Citizens.Remove(citizen);
            await _context.SaveChangesAsync();
            return citizen;
        }

    }
}
