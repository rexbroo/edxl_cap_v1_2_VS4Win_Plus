using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using edxl_cap_v1_2.Data;
using edxl_cap_v1_2.Models;

namespace edxl_cap_v1_2.Controllers
{
    public class EdxlCapMessagesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EdxlCapMessagesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EdxlCapMessages
        public async Task<IActionResult> Index()
        {
            return View(await _context.EdxlCapMessage.ToListAsync());
        }

        // GET: EdxlCapMessages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edxlCapMessage = await _context.EdxlCapMessage
                .SingleOrDefaultAsync(m => m.AlertIndex == id);
            if (edxlCapMessage == null)
            {
                return NotFound();
            }

            return View(edxlCapMessage);
        }

        // GET: EdxlCapMessages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EdxlCapMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlertIndex,SelectedAlertIndex,Alert_Identifier,Sender,Sent,Status,MsgType,Source,Scope,Restriction,Addresses,Code,Note,References,Incidents,InfoIndex,Language,Event,Audience,EventCode,Effective,Onset,Expires,SenderName,Headline,Description,Instruction,Web,Contact,Parameter,AreaIndex,AreaDesc,Polygon,Circle,Geocode,Altitude,Ceiling,ResourceIndex,ResourceDesc,MimeType,Size,Uri,DerefUri,Digest")] EdxlCapMessage edxlCapMessage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edxlCapMessage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edxlCapMessage);
        }

        // GET: EdxlCapMessages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edxlCapMessage = await _context.EdxlCapMessage.SingleOrDefaultAsync(m => m.AlertIndex == id);
            if (edxlCapMessage == null)
            {
                return NotFound();
            }
            return View(edxlCapMessage);
        }

        // POST: EdxlCapMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlertIndex,SelectedAlertIndex,Alert_Identifier,Sender,Sent,Source,Restriction,Addresses,Code,Note,References,Incidents,InfoIndex,Language,Event,Audience,EventCode,Effective,Onset,Expires,SenderName,Headline,Description,Instruction,Web,Contact,Parameter,AreaIndex,AreaDesc,Polygon,Circle,Geocode,Altitude,Ceiling,ResourceIndex,ResourceDesc,MimeType,Size,Uri,DerefUri,Digest")] EdxlCapMessage edxlCapMessage)
        {
            if (id != edxlCapMessage.AlertIndex)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edxlCapMessage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdxlCapMessageExists(edxlCapMessage.AlertIndex))
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
            return View(edxlCapMessage);
        }

        // GET: EdxlCapMessages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edxlCapMessage = await _context.EdxlCapMessage
                .SingleOrDefaultAsync(m => m.AlertIndex == id);
            if (edxlCapMessage == null)
            {
                return NotFound();
            }

            return View(edxlCapMessage);
        }

        // POST: EdxlCapMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edxlCapMessage = await _context.EdxlCapMessage.SingleOrDefaultAsync(m => m.AlertIndex == id);
            _context.EdxlCapMessage.Remove(edxlCapMessage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdxlCapMessageExists(int id)
        {
            return _context.EdxlCapMessage.Any(e => e.AlertIndex == id);
        }
    }
}
