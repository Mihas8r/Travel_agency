using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_agency.Models;
using Travel_agency.Repositories.Interfaces;

namespace Travel_agency.Controllers
{
    public class DestinationsController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public DestinationsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: Destinations
        public async Task<IActionResult> Index()
        {
            var agencyContext = _repository.DestinationRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }
        //[Route("Destinations/FirstPageHome")]
        public async Task<IActionResult> FirstPageHome()
        {
            var agencyContext = _repository.DestinationRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _repository.DestinationRepository.FindAll()== null)
            {
                return NotFound();
            }

            IQueryable<Destination> destinations = _repository.DestinationRepository.FindByCondition(b => b.DestinationId == id);
            var destination = destinations.FirstOrDefault();
           // var destination = _repository.DestinationRepository.FindByCondition(b => b.DestinationId == id);
               // .FirstOrDefaultAsync(m => m.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: Destinations/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId");
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DestinationId,Location,DepartDate,ReturnDate,ClientId")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _repository.DestinationRepository.Create(destination);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId", destination.ClientId);
            return View(destination);
        }

        // GET: Destinations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repository.DestinationRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<Destination> destinations = _repository.DestinationRepository.FindByCondition(b => b.DestinationId == id);
            var destination = destinations.FirstOrDefault();
              //  _repository.DestinationRepository.FindByCondition(b => b.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId");
            return View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DestinationId,Location,DepartDate,ReturnDate,ClientId")] Destination destination)
        {
            if (id != destination.DestinationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.DestinationRepository.Update(destination);
                     _repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinationExists(destination.DestinationId))
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
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId", destination.ClientId);
            return View(destination);
        }

        // GET: Destinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _repository.ClientRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<Destination> destinations = _repository.DestinationRepository.FindByCondition(b => b.DestinationId == id);
            var destination = destinations.FirstOrDefault();
           // var destination =_repository.DestinationRepository.FindByCondition(d => d.ClientId == id);
                //.FirstOrDefaultAsync(m => m.DestinationId == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repository.ClientRepository.FindAll() == null)
            {
                return Problem("Entity set 'AgencyContext.Destinations'  is null.");
            }
            IQueryable<Destination> destinations = _repository.DestinationRepository.FindByCondition(b => b.DestinationId == id);
            var destination = destinations.FirstOrDefault();
           // var destination =  _repository.DestinationRepository.FindByCondition(d => d.ClientId == id);
            if (destination != null)
            {
                _repository.DestinationRepository.Delete((Destination)destination);
            }
            
            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
          return (_repository.DestinationRepository.FindAll()?.Any(e => e.DestinationId == id)).GetValueOrDefault();
        }
    }
}
