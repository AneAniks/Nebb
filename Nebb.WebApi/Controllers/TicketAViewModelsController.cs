using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nebb.Data.Models;
using Nebb.Data.ViewModels;

namespace Nebb.WebApi.Controllers
{
    public class TicketAViewModelsController : Controller
    {
        private readonly NebbContext _context;

        public TicketAViewModelsController(NebbContext context)
        {
            _context = context;
        }
        //public IActionResult Index()
        //{
        //    NebbContext nebb = new NebbContext();
        //    List<TicketAViewModel> tvm = new List<TicketAViewModel>();
        //    var list = (from p in nebb.PassengerInfo
        //             //   join f in nebb.FlightInfo
        //                join t in nebb.Ticket on p.Id equals t.PassengerId
        //                select { p.FirstName, p.LastName, p.DateOfBirth, p.Passport, f.Origin, 
        //                    f.Destination, f.Departure, f.Return, t.FreeCarry, f.TrollyBag, f.CheckedIn }).ToList();

        //    foreach(var item in list)
        //    {
        //        TicketAViewModel obj = new TicketAViewModel();
        //        obj.FirstName = item.FirstName;
        //    }

    // GET: TicketAViewModels
    public async Task<IActionResult> Index()
    {
        return View(await _context.TicketAViewModel.ToListAsync());
    }

    // GET: TicketAViewModels/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticketAViewModel = await _context.TicketAViewModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (ticketAViewModel == null)
        {
            return NotFound();
        }

        return View(ticketAViewModel);
    }

    // GET: TicketAViewModels/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TicketAViewModels/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Passport,Origin,Destination,Departure,ReturnDay,FreeCarry,CheckedIn,TrolleyBag")] TicketAViewModel ticketAViewModel)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ticketAViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(ticketAViewModel);
    }

    // GET: TicketAViewModels/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticketAViewModel = await _context.TicketAViewModel.FindAsync(id);
        if (ticketAViewModel == null)
        {
            return NotFound();
        }
        return View(ticketAViewModel);
    }

    // POST: TicketAViewModels/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for 
    // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Passport,Origin,Destination,Departure,ReturnDay,FreeCarry,CheckedIn,TrolleyBag")] TicketAViewModel ticketAViewModel)
    {
        if (id != ticketAViewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(ticketAViewModel);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketAViewModelExists(ticketAViewModel.Id))
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
        return View(ticketAViewModel);
    }

    // GET: TicketAViewModels/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var ticketAViewModel = await _context.TicketAViewModel
            .FirstOrDefaultAsync(m => m.Id == id);
        if (ticketAViewModel == null)
        {
            return NotFound();
        }

        return View(ticketAViewModel);
    }

    // POST: TicketAViewModels/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var ticketAViewModel = await _context.TicketAViewModel.FindAsync(id);
        _context.TicketAViewModel.Remove(ticketAViewModel);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TicketAViewModelExists(int id)
    {
        return _context.TicketAViewModel.Any(e => e.Id == id);
    }
}
    }
