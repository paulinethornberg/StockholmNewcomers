using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace StockholmNewcomers.Controllers
{
    public class ErrorController : Controller
    {
        // GET: /<controller>/
        public IActionResult ServerError()
        {
            return View();
        }
        public IActionResult HttpError(int id)
        {
            return View(id);
        }
    }
}
