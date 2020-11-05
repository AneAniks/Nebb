using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nebb.Data.Models;

namespace Nebb.WebApi.Controllers
{
    public class FlightInfoesController : Controller
    {
        private readonly NebbContext _context;

        public FlightInfoesController(NebbContext context)
        {
            _context = context;
        }

        // GET: FlightInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FlightInfo.ToListAsync());
        }

        // GET: FlightInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightInfo = await _context.FlightInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightInfo == null)
            {
                return NotFound();
            }

            return View(flightInfo);
        }

        // GET: FlightInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FlightInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Origin,Destination,Departure,ReturnDay")] FlightInfo flightInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flightInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flightInfo);
        }

        // GET: FlightInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightInfo = await _context.FlightInfo.FindAsync(id);
            if (flightInfo == null)
            {
                return NotFound();
            }
            return View(flightInfo);
        }

        // POST: FlightInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Origin,Destination,Departure,ReturnDay")] FlightInfo flightInfo)
        {
            if (id != flightInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(flightInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FlightInfoExists(flightInfo.Id))
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
            return View(flightInfo);
        }

        // GET: FlightInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flightInfo = await _context.FlightInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (flightInfo == null)
            {
                return NotFound();
            }

            return View(flightInfo);
        }

        // POST: FlightInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var flightInfo = await _context.FlightInfo.FindAsync(id);
            _context.FlightInfo.Remove(flightInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FlightInfoExists(int id)
        {
            return _context.FlightInfo.Any(e => e.Id == id);
        }
    }
}
