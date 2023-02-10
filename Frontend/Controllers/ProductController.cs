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
            ProductRepository repo = new ProductRepository();
            List<Product> products = repo.Retrieve(id);
            
           if (products.Count > 0)
            {
                ProductModel productModel = new();
                productModel.ProductId = products[0].ProductId;
                productModel.ProductName = products[0].ProductName;
                productModel.Description = products[0].Description;
                productModel.CurrentPrice = products[0].CurrentPrice;
                productModel.QuantityInStock = products[0].QuantityInStock;
                return View(productModel);
            }
            return(NotFound());
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductModel product)
        {
            try
            {
                //save product to database
                ProductRepository repo = new ProductRepository();
                Product productToSave = new Product(){
                    ProductId = id,
                    ProductName = product.ProductName,
                    Description = product.Description,
                    CurrentPrice = product.CurrentPrice,
                    QuantityInStock = product.QuantityInStock,
                    HasChanges = true,
                    
                };
                repo.Save(productToSave);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
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
