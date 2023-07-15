using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductTaskCRUD.Models;
using ProductTaskCRUD.Models.ViewModels;


namespace ProductTaskCRUD.Controllers
{
    public class ProductController : Controller
    {
        private static IMapper _mapper;

        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }
        private static List<Product> _products = new()
        {
            new Product { Id = Guid.NewGuid(), Name="Coca&Cola", Category="Drink", Count=20, Description="Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company.",
                Price = 2, ImageURl = "https://getraenkeservice-muenchen.com/wp-content/uploads/2017/04/Cola-Light-033.png"},    
            new Product { Id = Guid.NewGuid(), Name="Nissan Skyline", Category="Car", Count=1, Description="The Nissan Skyline is a brand of automobile originally produced by the Prince Motor Company starting in 1957",
                Price = 300000, ImageURl = "https://cdn.motor1.com/images/mgl/P3nO74/s3/2000-nissan-skyline-r34-gt-r-by-kaizo-industries-driven-by-paul-walker-in-fast-and-furious-bonham-s-auction.webp"}, 
            new Product { Id = Guid.NewGuid(), Name="Fanta", Category="Drink", Count=100, Description="\r\nFanta is a popular carbonated soft drink known for its vibrant and fruity flavors. It offers a refreshing and effervescent taste that appeals to people of all ages. With its wide range of flavors, Fanta provides a fun and enjoyable beverage option for those seeking a fizzy and flavorful experience.",
                Price = 2, ImageURl = "https://josannecassar.com/wp-content/uploads/2016/08/Fanta-Bottle.jpg"}, 
            new Product { Id = Guid.NewGuid(), Name="Mercedes CLS 63", Category="Car", Count=5, Description="The Mercedes CLS 63 AMG stands as a true epitome of automotive brilliance, combining mesmerizing aesthetics, awe-inspiring power, and unmatched opulence to redefine the boundaries of luxury performance sedans.",
                Price = 60000, ImageURl = "https://dtmcollectibles.com/wp-content/uploads/2023/02/JPG-2023-02-09-DTM-Mercedes-AMG-CLS63-73-876x535.webp"},
        };


        public IActionResult Index()
        {
            return View(_products);
        }

        [HttpGet]
        public IActionResult AddProduct(Guid? id)
        {
            if (id == null)
                return View();

            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return RedirectToAction("Index");

            ViewData["id"] = product.Id;
            return View(_mapper.Map<Product, ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel product, Guid? id)
        {
            if (id == null)
            {
                var newProduct = _mapper.Map<Product>(product);
                _products.Add(newProduct);
            }
            else
            {
                var existingProduct = _products.FirstOrDefault(p => p.Id == id);

                if (existingProduct != null)
                {
                    existingProduct.dateOfAddition = DateTime.Now;
                    _mapper.Map(product, existingProduct);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult SearchProduct()
        {
            return View();
        }

        public IActionResult GetProduct(string searchProp, string method)
        {
            List<Product> products;

            switch (method)
            {
                case "Id" when Guid.TryParse(searchProp, out Guid id):
                    products = _products.FindAll(p => p.Id == id);
                    break;
                case "Category":
                    products = _products.FindAll(p => p.Category?.ToLower() == searchProp?.Trim().ToLower());
                    break;
                case "Name":
                    products = _products.FindAll(p => p.Name?.ToLower() == searchProp?.Trim().ToLower());
                    break;
                default:
                    products = new List<Product>();
                    break;
            }

            return View(products);
        }

        public IActionResult DeleteProduct(Guid id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _products.Remove(product);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Show(Product product)
        {
            return View(product);
        }
    }
}
