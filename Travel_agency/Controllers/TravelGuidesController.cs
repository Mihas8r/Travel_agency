using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_agency.Models;
using Travel_agency.Repositories.Interfaces;
using Travel_agency.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Travel_agency.Controllers
{
    public class TravelGuidesController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public TravelGuidesController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: TravelGuides
        public async Task<IActionResult> Index()
        {
            var agencyContext = _repository.TravelGuideRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }
        public async Task<IActionResult> LastPageHome()
        {
            var agencyContext = _repository.TravelGuideRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }
        public async Task<IActionResult> LastPageHome2()
        {
            var agencyContext = _repository.TravelGuideRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }
        [Authorize (Roles = "Administrator")]
        public async Task<IActionResult> LastPageHome3()
        {
            var agencyContext = _repository.TravelGuideRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }
        // GET: TravelGuides/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _repository.TravelGuideRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<TravelGuide> travelguides = _repository.TravelGuideRepository.FindByCondition(b => b.TravelGuideId == id);
            var travelguide = travelguides.FirstOrDefault();
            //  var travelGuide = await _context.TravelGuides
            //  .Include(t => t.Client)
            // .FirstOrDefaultAsync(m => m.TravelGuideId == id);
            if (travelguide == null)
            {
                return NotFound();
            }

            return View(travelguide);
        }

        // GET: TravelGuides/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId");
            return View();
        }

        // POST: TravelGuides/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TravelGuideId,TravelGuideName,TravelGuideDomain,ClientId")] TravelGuide travelGuide)
        {
            if (ModelState.IsValid)
            {
                _repository.TravelGuideRepository.Create(travelGuide);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId", travelGuide.ClientId);
            return View(travelGuide);
        }

        // GET: TravelGuides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repository.TravelGuideRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<TravelGuide> travelguides = _repository.TravelGuideRepository.FindByCondition(b => b.TravelGuideId == id);
            var travelguide = travelguides.FirstOrDefault();
           // var travelGuide = await _context.TravelGuides.FindAsync(id);
            if (travelguide == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId", travelguide.ClientId);
            return View(travelguide);
        }

        // POST: TravelGuides/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TravelGuideId,TravelGuideName,TravelGuideDomain,ClientId")] TravelGuide travelGuide)
        {
            if (id != travelGuide.TravelGuideId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.TravelGuideRepository.Update(travelGuide);
                    _repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelGuideExists(travelGuide.TravelGuideId))
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
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId", travelGuide.ClientId);
            return View(travelGuide);
        }

        // GET: TravelGuides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _repository.ClientRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<TravelGuide> travelguides = _repository.TravelGuideRepository.FindByCondition(b => b.TravelGuideId == id);
            var travelguide = travelguides.FirstOrDefault();
            // var travelGuide = await _context.TravelGuides
            //   .Include(t => t.Client)
            // .FirstOrDefaultAsync(m => m.TravelGuideId == id);
            if (travelguide == null)
            {
                return NotFound();
            }

            return View(travelguide);
        }

        // POST: TravelGuides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repository.ClientRepository.FindAll() == null)
            {
                return Problem("Entity set 'AgencyContext.TravelGuides'  is null.");
            }
            //  var travelGuide = await _context.TravelGuides.FindAsync(id);
            IQueryable<TravelGuide> travelguides = _repository.TravelGuideRepository.FindByCondition(b => b.TravelGuideId == id);
            var travelguide = travelguides.FirstOrDefault();
            if (travelguide != null)
            {
                _repository.TravelGuideRepository.Delete((TravelGuide)travelguide);
            }

            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelGuideExists(int id)
        {
            return (_repository.TravelGuideRepository.FindAll()?.Any(e => e.TravelGuideId == id)).GetValueOrDefault();
        }
    }
}
