using Microsoft.AspNetCore.Mvc;
using ProductTaskCRUD.Models;
using System.Xml.Linq;

namespace ProductTaskCRUD.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new()
        {
            new Product { Id = Guid.NewGuid(), Name="Coca&Cola", Category="Drink", Count=20, Description="Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company.",
                Price = 2, ImageLink = "https://getraenkeservice-muenchen.com/wp-content/uploads/2017/04/Cola-Light-033.png"},    
            new Product { Id = Guid.NewGuid(), Name="Nissan Skyline", Category="Car", Count=1, Description="The Nissan Skyline is a brand of automobile originally produced by the Prince Motor Company starting in 1957",
                Price = 300000, ImageLink = "https://cdn.motor1.com/images/mgl/P3nO74/s3/2000-nissan-skyline-r34-gt-r-by-kaizo-industries-driven-by-paul-walker-in-fast-and-furious-bonham-s-auction.webp"}, 
            new Product { Id = Guid.NewGuid(), Name="Fanta", Category="Drink", Count=100, Description="Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company.",
                Price = 1.5, ImageLink = "https://josannecassar.com/wp-content/uploads/2016/08/Fanta-Bottle.jpg"}, 
            new Product { Id = Guid.NewGuid(), Name="Mercedes CLS 63", Category="Car", Count=5, Description="Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company.",
                Price = 60000, ImageLink = "https://dtmcollectibles.com/wp-content/uploads/2023/02/JPG-2023-02-09-DTM-Mercedes-AMG-CLS63-73-876x535.webp"},
        };

        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            product.Id = Guid.NewGuid();
            _products.Add(product);
            return RedirectToAction("Index");
        }

        public IActionResult SearchProduct()
        {
            return View();
        }

        public IActionResult GetProduct(string searchProp, string method)
        {
            List<Product>? products = new();
            if (method == "Id" && Guid.TryParse(searchProp, out Guid id))
            {
                products = _products.FindAll(p => p.Id == id);
            }
            else if (method == "Category")
            {
                products = _products.FindAll(p => p?.Category?.ToLower() == searchProp?.Trim().ToLower());
            }
            else if (method == "Name")
            {
                products = _products.FindAll(p => p?.Name?.ToLower() == searchProp?.Trim().ToLower());
            }

            return View(products);
        }
        public IActionResult DeleteProduct(Guid id)
        {
            Product? product = null;
            product = _products.Find(p => p.Id == id);

            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction("Index");
        }
    }
}
