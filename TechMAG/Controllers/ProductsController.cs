using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechMAG.Data;
using TechMAG.Data.Services;
using TechMAG.Data.ViewModel;
using TechMAG.Models;

namespace TechMAG.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(n => n.Producer);
            return View(data);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var productDropDownData = await _service.GetNewProductDropDownVal();
            ViewBag.ProducerId = new SelectList(productDropDownData.Producers,"Id","Name");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImageURL,ScreenSize,OperatingSystem,Amount,Created,Discount,ProductCategory,ProducerId")] ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        //// GET: Products/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Products == null)
        //    {
        //        return NotFound();
        //    }

        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", product.ProducerId);
        //    return View(product);
        //}

        //// POST: Products/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImageURL,ScreenSize,OperatingSystem,Amount,Created,Discount,ProductCategory,ProducerId")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["ProducerId"] = new SelectList(_context.Producers, "Id", "Id", product.ProducerId);
        //    return View(product);
        //}

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _service.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.GetByIdAsync(id) == null)
            {
                return Problem("Entity set 'AppDbContext.Products'  is null.");
            }
            var product = await _service.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
