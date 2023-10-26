using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using Travel_agency.Models;
using Travel_agency.Repositories.Interfaces;

namespace Travel_agency.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IRepositoryWrapper _repository;

        public ClientsController(IRepositoryWrapper repository)
        {
            _repository = repository ;
        }

        // GET: Clients
        public async Task<IActionResult> Index()
        {
            var repo = _repository.ClientRepository.FindAll();
            return View(await repo.ToListAsync());
        }

        [Authorize]
        public async Task<IActionResult> SecondPageHome()
        {
            var agencyContext = _repository.ClientRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }
        public async Task<IActionResult> ContactPage()
        {
            var agencyContext = _repository.ClientRepository.FindAll();
            return View(await agencyContext.ToListAsync());
        }
        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _repository.ClientRepository.FindAll() == null)
            {
                return NotFound();
            }

            IQueryable<Client> clients = _repository.ClientRepository.FindByCondition(b => b.ClientId == id);
            var client = clients.FirstOrDefault();

            //var client = await _context.Clients
               // .FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId");
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,ClientName,ClientAddress")] Client client)
        {
            if (ModelState.IsValid)
            {
                _repository.ClientRepository.Create(client);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _repository.ClientRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<Client> clients = _repository.ClientRepository.FindByCondition(b => b.ClientId == id);
            var client = clients.FirstOrDefault();
           // var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClientId,ClientName,ClientAddress")] Client client)
        {
            if (id != client.ClientId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.ClientRepository.Update(client);
                    _repository.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientExists(client.ClientId))
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
            ViewData["ClientId"] = new SelectList(_repository.ClientRepository.FindAll(), "ClientId", "ClientId", client.ClientId);
            return View(client);
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _repository.ClientRepository.FindAll() == null)
            {
                return NotFound();
            }
            IQueryable<Client> clients = _repository.ClientRepository.FindByCondition(b => b.ClientId == id);
            var client = clients.FirstOrDefault();
            //var client = await _repository.ClientRepository.FindAll()
                //.FirstOrDefaultAsync(m => m.ClientId == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repository.ClientRepository.FindAll() == null)
            {
                return Problem("Entity set 'AgencyContext.Clients'  is null.");
            }
            IQueryable<Client> clients = _repository.ClientRepository.FindByCondition(b => b.ClientId == id);
            var client = clients.FirstOrDefault();
           // var client = await _context.Clients.FindAsync(id);
            if (client != null)
            {
                _repository.ClientRepository.Delete((Client)client);
            }

            _repository.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientExists(int id)
        {
            return (_repository.ClientRepository.FindAll()?.Any(e => e.ClientId == id)).GetValueOrDefault();
        }
    }
}
