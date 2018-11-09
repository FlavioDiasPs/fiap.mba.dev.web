using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Web.Controllers
{
    
    public class HomeController : Controller
    {        
        public IActionResult Index()
        {
            var teste = User;

            return View();
        }
    }
}
