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
    }
}