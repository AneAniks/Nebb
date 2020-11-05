using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nebb.Data.Models;
using Nebb.Data.ViewModels;
using Nebb.Service.Services;

namespace Nebb.WebApi.Controllers
{
    public class TicketsController : Controller
    {
        private readonly NebbContext _context;
        //private readonly ITicketService _ticketService;
        //  public Ticket Ticket { get; set; }

        public TicketsController(NebbContext context)
        {
            _context = context;
        }
        //public TicketsController(ITicketService ticketService)
        //{
        //    this._ticketService = ticketService;
        //}

        //public IActionResult OnGet(int id) 
        //{
        //    Ticket = _ticketService.GetTicket2(id);
        //    return View();
        //}

      //  GET: Tickets
        public async Task<IActionResult> Index()
        {
            var nebbContext = _context.Ticket.Include(t => t.Flight).Include(t => t.Passenger);
            return View(await nebbContext.ToListAsync());
        }

       // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Flight)
                .Include(t => t.Passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

       // GET: Tickets/Create
        public IActionResult Create()
        {
            ViewData["FlightId"] = new SelectList(_context.FlightInfo, "Id", "Destination");
            ViewData["PassengerId"] = new SelectList(_context.PassengerInfo, "Id", "FirstName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FreeCarry,CheckedIn,TrolleyBag,PassengerId,FlightId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FlightId"] = new SelectList(_context.FlightInfo, "Id", "Destination", ticket.FlightId);
            ViewData["PassengerId"] = new SelectList(_context.PassengerInfo, "Id", "FirstName", ticket.PassengerId);
            return View(ticket);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FirstName,LastName,DateOfBirth,Passport,Origin,Destination,Departure,ReturnDay,FreeCarry,CheckedIn,TrolleyBag")] TicketAViewModel ticketA)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(ticketA);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //   // ViewData["FlightId"] = new SelectList(_context.FlightInfo, "Id", "Destination", ticket.FlightId);
        //   // ViewData["PassengerId"] = new SelectList(_context.PassengerInfo, "Id", "FirstName", ticket.PassengerId);
        //    return View(ticketA);
        //}

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            ViewData["FlightId"] = new SelectList(_context.FlightInfo, "Id", "Destination", ticket.FlightId);
            ViewData["PassengerId"] = new SelectList(_context.PassengerInfo, "Id", "FirstName", ticket.PassengerId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FreeCarry,CheckedIn,TrolleyBag,PassengerId,FlightId")] Ticket ticket)
        {
            if (id != ticket.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.Id))
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
            ViewData["FlightId"] = new SelectList(_context.FlightInfo, "Id", "Destination", ticket.FlightId);
            ViewData["PassengerId"] = new SelectList(_context.PassengerInfo, "Id", "FirstName", ticket.PassengerId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .Include(t => t.Flight)
                .Include(t => t.Passenger)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            _context.Ticket.Remove(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.Id == id);
        }
    }
}
