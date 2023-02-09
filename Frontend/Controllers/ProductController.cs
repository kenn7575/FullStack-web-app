using BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
            ProductRepository repo = new ProductRepository();
            List<Product> products = repo.Retrieve().ToList();
            List<ProductModel> productModels = new();
            foreach (Product product in products)
            {
                // Try autoparser en anden gang
                ProductModel productModel = new();
                productModel.ProductId = product.ProductId;
                productModel.ProductName = product.ProductName;
                productModel.Description = product.Description;
                productModel.CurrentPrice = product.CurrentPrice;
                productModel.QuantityInStock = product.QuantityInStock;
                productModels.Add(productModel);

            }
            return View(productModels);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            ProductRepository repo = new ProductRepository();
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
