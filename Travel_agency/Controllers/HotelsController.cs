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
    public class HotelsController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public HotelsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        // GET: Hotels
        public async Task<IActionResult> Index()
        {
            var agencyContext = _repository.HotelRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }

        public async Task<IActionResult> ThirdPageHome()
        {
            var agencyContext = _repository.HotelRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }

        // GET: Hotels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _repository.HotelRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<Hotel> hotels = _repository.HotelRepository.FindByCondition(b => b.HotelId == id);
            var hotel = hotels.FirstOrDefault();
            // var hotel = await _context.Hotels
            //  .Include(h => h.Client)
            //.FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // GET: Hotels/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HotelId,HotelName,HotelAddress,Description,ClientId")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                _repository.HotelRepository.Create(hotel);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_repository.HotelRepository.FindAll(), "ClientId", "ClientId", hotel.ClientId);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repository.HotelRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<Hotel> hotels = _repository.HotelRepository.FindByCondition(b => b.HotelId == id);
            var hotel = hotels.FirstOrDefault();
          //  var hotel = await _context.Hotels.FindAsync(id);
            if (hotel == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_repository.HotelRepository.FindAll(), "ClientId", "ClientId", hotel.ClientId);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HotelId,HotelName,HotelAddress,Description,ClientId")] Hotel hotel)
        {
            if (id != hotel.HotelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.HotelRepository.Update(hotel);
                    _repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HotelExists(hotel.HotelId))
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
            ViewData["ClientId"] = new SelectList(_repository.HotelRepository.FindAll(), "ClientId", "ClientId", hotel.ClientId);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _repository.ClientRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<Hotel> hotels = _repository.HotelRepository.FindByCondition(b => b.HotelId == id);
            var hotel = hotels.FirstOrDefault();
          //  var hotel = await _context.Hotels
                //.Include(h => h.Client)
               // .FirstOrDefaultAsync(m => m.HotelId == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repository.ClientRepository.FindAll() == null)
            {
                return Problem("Entity set 'AgencyContext.Hotels'  is null.");
            }
            IQueryable<Hotel> hotels = _repository.HotelRepository.FindByCondition(b => b.HotelId == id);
            var hotel = hotels.FirstOrDefault();
            //var hotel = await _context.Hotels.FindAsync(id);
            if (hotel != null)
            {
                _repository.HotelRepository.Delete((Hotel)hotel);
            }

            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool HotelExists(int id)
        {
            return (_repository.HotelRepository.FindAll()?.Any(e => e.HotelId == id)).GetValueOrDefault();
        }
    }
}
