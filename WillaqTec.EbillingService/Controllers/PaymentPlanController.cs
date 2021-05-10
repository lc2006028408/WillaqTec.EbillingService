using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WillaqTec.Controllers
{
    public class PaymentPlanController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
