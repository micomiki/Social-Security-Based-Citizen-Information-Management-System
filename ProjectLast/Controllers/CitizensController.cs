using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectLast.Data;
using ProjectLast.Models;
using ProjectLast.Extensions;

namespace ProjectLast.Controllers
{
    public class CitizensController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitizensController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Citizens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Citizens.ToListAsync());
        }

        // GET: Citizens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = await _context.Citizens
                .FirstOrDefaultAsync(m => m.SSN == id);
           
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // GET: Citizens/Create
        public async Task<IActionResult> Create(int ssn)
        {
            List<City> cities = await _context.Cities.ToListAsync();
            Citizen citizens = new Citizen {
                SSN = ssn,
                Citiy = cities.ConvertToSelectList(0)
                
           
           };
            
                
            
            return View(citizens);
        }

        // POST: Citizens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SSN,First_Name,Last_Name,DOB,CityCode,Woreda,Kebele,Blood_Type,Phone,Age")] Citizen citizen)
        {
            if (ModelState.IsValid)
            {
                var citize = await _context.Cities
              .FirstOrDefaultAsync(m => m.Code == citizen.CityCode);
               // ViewBag.result = citize.Name;
                //Console.WriteLine(citize.Name);
                citizen.City = citize.Name;

                _context.Add(citizen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(citizen);
        }

        // GET: Citizens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            List<City> cities = await _context.Cities.ToListAsync();

            var citizen = await _context.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }
            citizen.Citiy = cities.ConvertToSelectList(citizen.CityCode);
            return View(citizen);
        }

        // POST: Citizens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SSN,First_Name,Last_Name,DOB,CityCode,Woreda,Kebele,Blood_Type,Phone,Age")] Citizen citizen)
        {
            if (id != citizen.SSN)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var citize = await _context.Cities
             .FirstOrDefaultAsync(m => m.Code == citizen.CityCode);
                    ViewBag.result = citize.Name;
                    Console.WriteLine(citize.Name);
                    citizen.City = citize.Name;

                    _context.Update(citizen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitizenExists(citizen.SSN))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(citizen);
        }

        // GET: Citizens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var citizen = await _context.Citizens
                .FirstOrDefaultAsync(m => m.SSN == id);
            if (citizen == null)
            {
                return NotFound();
            }

            return View(citizen);
        }

        // POST: Citizens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var citizen = await _context.Citizens.FindAsync(id);
            _context.Citizens.Remove(citizen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitizenExists(int id)
        {
            return _context.Citizens.Any(e => e.SSN == id);
        }
    }
}
