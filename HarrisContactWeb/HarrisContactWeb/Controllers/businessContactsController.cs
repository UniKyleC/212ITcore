using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HarrisContactWeb.Data;
using HarrisContactWeb.Models;

namespace HarrisContactWeb.Controllers
{
    public class businessContactsController : Controller
    {
        private readonly HarrisDbContext _context;

        public businessContactsController(HarrisDbContext context)
        {
            _context = context;
        }

        // GET: businessContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.businessContacts.ToListAsync());
        }

        // GET: businessContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessContact = await _context.businessContacts
                .FirstOrDefaultAsync(m => m.businessContactID == id);
            if (businessContact == null)
            {
                return NotFound();
            }

            return View(businessContact);
        }

        // GET: businessContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: businessContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("businessContactID,businessContactFirstName,businessContactLastName,businessContactTelephone,businessContactBusinessTelephone,businessContactEmail,businessContactAddress1,businessContactAddress2,businessContactCity,businessContactPostcode")] businessContact businessContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(businessContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(businessContact);
        }

        // GET: businessContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessContact = await _context.businessContacts.FindAsync(id);
            if (businessContact == null)
            {
                return NotFound();
            }
            return View(businessContact);
        }

        // POST: businessContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("businessContactID,businessContactFirstName,businessContactLastName,businessContactTelephone,businessContactBusinessTelephone,businessContactEmail,businessContactAddress1,businessContactAddress2,businessContactCity,businessContactPostcode")] businessContact businessContact)
        {
            if (id != businessContact.businessContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(businessContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!businessContactExists(businessContact.businessContactID))
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
            return View(businessContact);
        }

        // GET: businessContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var businessContact = await _context.businessContacts
                .FirstOrDefaultAsync(m => m.businessContactID == id);
            if (businessContact == null)
            {
                return NotFound();
            }

            return View(businessContact);
        }

        // POST: businessContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var businessContact = await _context.businessContacts.FindAsync(id);
            _context.businessContacts.Remove(businessContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool businessContactExists(int id)
        {
            return _context.businessContacts.Any(e => e.businessContactID == id);
        }
    }
}
