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
    public class personalContactsController : Controller
    {
        private readonly HarrisDbContext _context;

        public personalContactsController(HarrisDbContext context)
        {
            _context = context;
        }

        // GET: personalContacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.personalContacts.ToListAsync());
        }

        // GET: personalContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.personalContacts
                .FirstOrDefaultAsync(m => m.personalContactID == id);
            if (personalContact == null)
            {
                return NotFound();
            }

            return View(personalContact);
        }

        // GET: personalContacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: personalContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("personalContactID,personalContactFirstName,personalContactLastName,personalContactTelephone,personalContactHomeTelephone,personalContactEmail,personalContactAddress1,personalContactAddress2,personalContactCity,personalContactPostcode")] personalContact personalContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personalContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personalContact);
        }

        // GET: personalContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.personalContacts.FindAsync(id);
            if (personalContact == null)
            {
                return NotFound();
            }
            return View(personalContact);
        }

        // POST: personalContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("personalContactID,personalContactFirstName,personalContactLastName,personalContactTelephone,personalContactHomeTelephone,personalContactEmail,personalContactAddress1,personalContactAddress2,personalContactCity,personalContactPostcode")] personalContact personalContact)
        {
            if (id != personalContact.personalContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personalContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!personalContactExists(personalContact.personalContactID))
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
            return View(personalContact);
        }

        // GET: personalContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personalContact = await _context.personalContacts
                .FirstOrDefaultAsync(m => m.personalContactID == id);
            if (personalContact == null)
            {
                return NotFound();
            }

            return View(personalContact);
        }

        // POST: personalContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personalContact = await _context.personalContacts.FindAsync(id);
            _context.personalContacts.Remove(personalContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool personalContactExists(int id)
        {
            return _context.personalContacts.Any(e => e.personalContactID == id);
        }
    }
}
