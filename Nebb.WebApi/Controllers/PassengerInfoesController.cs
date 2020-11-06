using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nebb.Data.Models;

namespace Nebb.WebApi.Controllers
{
    public class PassengerInfoesController : Controller
    {
        private readonly NebbContext _context;

        public PassengerInfoesController(NebbContext context)
        {
            _context = context;
        }

        // GET: PassengerInfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PassengerInfo.ToListAsync());
        }

        // GET: PassengerInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passengerInfo = await _context.PassengerInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passengerInfo == null)
            {
                return NotFound();
            }

            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PassengerInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Passport,LoyalMemberId,UseLoyalMember")] PassengerInfo passengerInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passengerInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passengerInfo = await _context.PassengerInfo.FindAsync(id);
            if (passengerInfo == null)
            {
                return NotFound();
            }
            return View(passengerInfo);
        }

        // POST: PassengerInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Passport,LoyalMemberId,UseLoyalMember")] PassengerInfo passengerInfo)
        {
            if (id != passengerInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passengerInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassengerInfoExists(passengerInfo.Id))
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
            return View(passengerInfo);
        }

        // GET: PassengerInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passengerInfo = await _context.PassengerInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (passengerInfo == null)
            {
                return NotFound();
            }

            return View(passengerInfo);
        }

        // POST: PassengerInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passengerInfo = await _context.PassengerInfo.FindAsync(id);
            _context.PassengerInfo.Remove(passengerInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassengerInfoExists(int id)
        {
            return _context.PassengerInfo.Any(e => e.Id == id);
        }
    }
}
