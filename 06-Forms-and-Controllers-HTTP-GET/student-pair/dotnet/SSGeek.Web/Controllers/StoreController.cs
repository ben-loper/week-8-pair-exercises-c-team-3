using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SessionControllerData;
using SSGeek.Web.DAL;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class StoreController : SessionController
    {
        private ProductSqlDAL _proDAL;
        public StoreController(ProductSqlDAL proDAL)
        {
            _proDAL = proDAL;
        }

        // GET: Store/Index
        public IActionResult Index()
        {
            List<Product> products = _proDAL.GetProducts();
            return View(products);
        }

        public IActionResult Detail(int ProductId)
        {
            Product product = _proDAL.GetProduct(ProductId);
            return View(product);
        }

        [HttpPost]
        public IActionResult AddToCart(int ProductId)
        {
            //1.  Get the Product associated with id
            Product product = _proDAL.GetProduct(ProductId);

            //2.  Add Product, qty 1 to our active shopping cart
            ShoppingCart cart = GetActiveShoppingCart();
            cart.AddToCart(product, 1);

            //3. Save shopping cart
            SaveActiveShoppingCart(cart);

            return RedirectToAction("ViewCart");
        }

        [HttpGet]
        public ActionResult ViewCart()
        {
            ShoppingCart cart = GetActiveShoppingCart();
            return View(cart);
        }

        //Methods
        private ShoppingCart GetActiveShoppingCart()
        {
            ShoppingCart cart = null;

            // See if the user has a shopping cart stored in session            
            if (GetSessionData<ShoppingCart>("ShoppingCart") == null)
            {
                cart = new ShoppingCart();
                SaveActiveShoppingCart(cart);
            }
            else
            {
                cart = GetSessionData<ShoppingCart>("ShoppingCart"); // <-- gets the shopping cart out of session
            }

            // If not, create one for them

            return cart;
        }

        private void SaveActiveShoppingCart(ShoppingCart cart)
        {
            SetSessionData("ShoppingCart", cart);        // <-- saves the shopping cart into session
        }
    }
}