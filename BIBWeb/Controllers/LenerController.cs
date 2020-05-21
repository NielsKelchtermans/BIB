using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIBServices;
using Microsoft.AspNetCore.Mvc;

namespace BIBWeb.Controllers
{
    public class LenerController : Controller
    {
        private LenerService lenerService;
        public LenerController(LenerService lenerService)
        {
            this.lenerService = lenerService;
        }
        public IActionResult Index()
        {
            return View(lenerService.GetAllLeners());
        }
        public IActionResult Detail(int id)
        {
            return View(lenerService.GetLener(id));
        }
    }
}