using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechMAG.Data;
using TechMAG.Data.Services;
using TechMAG.Models;

namespace TechMAG.Controllers
{
    public class ProductImagesController : Controller
    {
        private readonly IProductImageService _service;

        public ProductImagesController(IProductImageService service)
        {
            _service = service;
        }

        // GET: ProductImages
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
              return View(data);
        }

        // GET: ProductImages/Details/5
        public async Task<IActionResult> Details(int id)
        { 
            var productImage = await _service.GetByIdAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // GET: ProductImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductImageURL,CreatedDate")] ProductImage productImage)
        {
            if (ModelState.IsValid)
            {
                _service.AddAsync(productImage);
                return RedirectToAction(nameof(Index));
            }
            return View(productImage);
        }

        // GET: ProductImages/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var productImage = await _service.GetByIdAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            return View(productImage);
        }

        //// POST: ProductImages/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductImageURL,CreatedDate")] ProductImage productImage)
        {
            if (id != productImage.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(productImage);
            }
            await _service.UpdateAsync(id, productImage);
            return RedirectToAction(nameof(Index));
        }

        //// GET: ProductImages/Delete/5
        public async Task<IActionResult> Delete(int id)
        {

            var productImage = await _service.GetByIdAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }

            return View(productImage);
        }

        // POST: ProductImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productImage = await _service.GetByIdAsync(id);
            if (productImage == null)
            {
                return NotFound();
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
