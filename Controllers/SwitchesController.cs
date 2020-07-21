using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Webkom.Data;
using Webkom.Models;
using Webkom.Stuff;
using Webkom.ViewModels.Switches;

namespace Webkom.Controllers
{
    public class SwitchesController : Controller
    {
        private readonly WebkomContext _context;

        public SwitchesController(WebkomContext context)
        {
            _context = context;
        }

        // GET: Switches
        public async Task<IActionResult> Index(int? pageIndex, int? pageSize, bool extendedMode, SwitchFilter filter)
        {
            
            
            var switches = from s
                           in _context.Switches
                           select s;
           
            if (extendedMode)
            {
                if (filter.VLanIdMin > filter.VLanIdMax)
                    ModelState.AddModelError("Filter.VLanIdMin", "Неправильный интервал для идентификаторов VLan.");
                if (filter.PurchaseDateMin > filter.PurchaseDateMax)
                    ModelState.AddModelError("Filter.PurchaseDateMin", "Неправильный интервал для дат покупки.");
                if (filter.ConnectDateMin > filter.ConnectDateMax)
                    ModelState.AddModelError("Filter.ConnectDateMin", "Неправильный интервал для дат установки.");

                if (!string.IsNullOrEmpty(filter.IPAddress))
                    switches = switches.Where(s => s.IPAddress.Contains(filter.IPAddress));
                if (!string.IsNullOrEmpty(filter.MACAddress))
                    switches = switches.Where(s => s.MACAddress.Contains(filter.MACAddress));
                if (!string.IsNullOrEmpty(filter.SerialNumber))
                    switches = switches.Where(s => s.SerialNumber.Contains(filter.SerialNumber));
                if (!string.IsNullOrEmpty(filter.InventoryNumber))
                    switches = switches.Where(s => s.InventoryNumber.Contains(filter.InventoryNumber));
                if (!string.IsNullOrEmpty(filter.Description))
                    switches = switches.Where(s => s.Description.Contains(filter.Description));
                if (filter.EnableVLanIDSearch)
                    switches = switches.Where(s => s.VLanId >= filter.VLanIdMin &&
                        s.VLanId <= filter.VLanIdMax);
                if (filter.EnableFloorNumberSearch)
                    switches = switches.Where(s => s.FloorNumber >= filter.FloorNumberMin &&
                        s.FloorNumber <= filter.FloorNumberMax);
                if (filter.EnablePuchaseDataSearch)
                    switches = switches.Where(s => s.PurchaseDate >= filter.PurchaseDateMin &&
                        s.PurchaseDate <= filter.PurchaseDateMax);
                if (filter.EnableConnectDateSearch)
                    switches = switches.Where(s => s.ConnectDate >= filter.ConnectDateMin &&
                        s.ConnectDate <= filter.ConnectDateMax);                
            }
            else
            {
                if (!string.IsNullOrEmpty(filter.SearchString))
                {
                    switches = switches.Where(
                        s => s.IPAddress.Contains(filter.SearchString) ||
                            s.MACAddress.Contains(filter.SearchString) ||
                            s.SerialNumber.Contains(filter.SearchString) ||
                            s.InventoryNumber.Contains(filter.SearchString) ||
                            s.Description.Contains(filter.SearchString));
                }               
            }
            
            PaginatedList<Switch> model = await PaginatedList<Switch>.CreateAsync(
                switches.AsNoTracking(),
                pageIndex ?? 1,
                pageSize ?? -1);
            
            model.Filter = filter;
            model.Filter.ExtendedMode = extendedMode;
            
            return View(model);
        }

        // GET: Switches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @switch = await _context.Switches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@switch == null)
            {
                return NotFound();
            }

            return View(@switch);
        }

        // GET: Switches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Switches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IPAddress,MACAddress,VLanId,SerialNumber,InventoryNumber,PurchaseDate,ConnectDate,FloorNumber,Description")] Switch @switch)
        {
            if (@switch.PurchaseDate >= @switch.ConnectDate)
                ModelState.AddModelError("", "Дата установки не должна быть меньше даты установки");
            if (ModelState.IsValid)
            {
                _context.Add(@switch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@switch);
        }

        // GET: Switches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @switch = await _context.Switches.FindAsync(id);
            if (@switch == null)
            {
                return NotFound();
            }
            return View(@switch);
        }

        // POST: Switches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IPAddress,MACAddress,VLanId,SerialNumber,InventoryNumber,PurchaseDate,ConnectDate,FloorNumber,Description")] Switch @switch)
        {
            if (id != @switch.Id)
            {
                return NotFound();
            }
            if (@switch.PurchaseDate >= @switch.ConnectDate)
                ModelState.AddModelError("", "Дата установки не должна быть меньше даты установки");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@switch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SwitchExists(@switch.Id))
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
            return View(@switch);
        }

        // GET: Switches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @switch = await _context.Switches
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@switch == null)
            {
                return NotFound();
            }

            return View(@switch);
        }

        // POST: Switches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @switch = await _context.Switches.FindAsync(id);
            _context.Switches.Remove(@switch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SwitchExists(int id)
        {
            return _context.Switches.Any(e => e.Id == id);
        }

        #region для проверки атрибутов SwitchFilter, но она почему-то принимает пустые значения :(

        public IActionResult CheckRangeVLan([Bind(Prefix = "Filter")]int VLanIdMin, [Bind(Prefix = "Filter")] int VLanIdMax)
        {
            return Json(VLanIdMin <= VLanIdMax);
        }
        
        public IActionResult CheckDateTimeRange([Bind(Prefix = "Filter")]DateTime minVal, [Bind(Prefix = "Filter")]DateTime maxVal) => Json(minVal <= maxVal);

        public IActionResult Test(string Description)
        {
            return Json(Description.Contains("test"), "Ошибка!!");
        }

        #endregion
    }

}
