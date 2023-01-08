using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Search(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Producer);

            if (!string.IsNullOrEmpty(searchString))
            {

                var filteredResultNew = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResultNew);
            }

            return View("Index", allProducts);
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImageURL,ScreenSize,OperatingSystem,Amount,Created,Discount,ProductCategory,ProducerId")] ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {

            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null)
            {
                return NotFound();
            }

            var productDropDownData = await _service.GetNewProductDropDownVal();
            ViewBag.ProducerId = new SelectList(productDropDownData.Producers, "Id", "Name");

            return View(productDetails);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImageURL,ScreenSize,OperatingSystem,Amount,Created,Discount,ProductCategory,ProducerId")] ProductVM product)
        {

            if(!ModelState.IsValid)
            {
                var productDropDownData = await _service.GetNewProductDropDownVal();
                ViewBag.ProducerId = new SelectList(productDropDownData.Producers, "Id", "Name");
            }

            await _service.UpdateMovieAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
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
