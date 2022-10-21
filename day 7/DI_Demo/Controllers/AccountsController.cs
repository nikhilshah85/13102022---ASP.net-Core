using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DI_Demo.Models.EF;

namespace DI_Demo.Controllers
{
    public class AccountsController : Controller
    {
        private readonly bankingDBContext _context;

        public AccountsController(bankingDBContext context)
        {
            _context = context;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var bankingDBContext = _context.AccountsInfos.Include(a => a.AccBranchNavigation);
            return View(await bankingDBContext.ToListAsync());
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.AccountsInfos == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos
                .Include(a => a.AccBranchNavigation)
                .FirstOrDefaultAsync(m => m.AccNo == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccNo,AccName,AccType,AccBalance,AccIsActive,AccBranch")] AccountsInfo accountsInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accountsInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.AccountsInfos == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos.FindAsync(id);
            if (accountsInfo == null)
            {
                return NotFound();
            }
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccNo,AccName,AccType,AccBalance,AccIsActive,AccBranch")] AccountsInfo accountsInfo)
        {
            if (id != accountsInfo.AccNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accountsInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsInfoExists(accountsInfo.AccNo))
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
            ViewData["AccBranch"] = new SelectList(_context.BranchInfos, "BranchId", "BranchId", accountsInfo.AccBranch);
            return View(accountsInfo);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.AccountsInfos == null)
            {
                return NotFound();
            }

            var accountsInfo = await _context.AccountsInfos
                .Include(a => a.AccBranchNavigation)
                .FirstOrDefaultAsync(m => m.AccNo == id);
            if (accountsInfo == null)
            {
                return NotFound();
            }

            return View(accountsInfo);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.AccountsInfos == null)
            {
                return Problem("Entity set 'bankingDBContext.AccountsInfos'  is null.");
            }
            var accountsInfo = await _context.AccountsInfos.FindAsync(id);
            if (accountsInfo != null)
            {
                _context.AccountsInfos.Remove(accountsInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AccountsInfoExists(int id)
        {
          return _context.AccountsInfos.Any(e => e.AccNo == id);
        }
    }
}
