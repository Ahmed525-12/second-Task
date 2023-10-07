using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductIce productIce;

        public ProductsController(ProductIce productIce)
        {
            this.productIce = productIce;
        }

        public IActionResult Index()
        {
            var products = productIce.GetALL();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products products)
        {
            if (ModelState.IsValid)
            {
                productIce.AddProduct(products);
                return RedirectToAction("Index");
            }
            return View(products);
        }

        public IActionResult Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var prod = productIce.ProductGetByID(id.Value);
            if (prod is null)
                return NotFound();
            return View(prod);
        }

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var prod = productIce.ProductGetByID(id.Value);
            if (prod is null)
                return NotFound();
            return View(prod);
        }

        [HttpPost]
        public IActionResult Edit(Products products)
        {
            if (ModelState.IsValid)
            {
                productIce.UpdateProduct(products);
                return RedirectToAction("Index");
            }
            return View(products);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var prod = productIce.ProductGetByID(id.Value);
            if (prod is null)
                return NotFound();
            return View(prod);
        }

        [HttpPost]
        public IActionResult Delete(Products products)
        {
            productIce.DeleteProduct(products);
            return RedirectToAction("Index");
        }

        public IActionResult ImportProducts()
        {
            productIce.ImportProductsFromJson();
            return RedirectToAction("Index");
        }
    }
}