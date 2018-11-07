using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fiap.StackOverflow.Web.Controllers
{
    public class QuestionController : Controller
    {
        public QuestionController()
        {

        }

        public IActionResult Question(int? questionId)
        {
            return View();
        }
    }
}
