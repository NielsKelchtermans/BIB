using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIBServices;
using Microsoft.AspNetCore.Mvc;
using BIBWeb.Models;

namespace BIBWeb.Controllers
{
    public class LenerController : Controller
    {
        private LenerService lenerService;
        private ReserveringService reserveringService;
        private UitleningService uitleningService;
        public LenerController(LenerService lenerService, ReserveringService reserveringService, UitleningService uitleningService)
        {
            this.lenerService = lenerService;
            this.reserveringService = reserveringService;
            this.uitleningService = uitleningService;
        }
        public IActionResult Index()
        {
            return View(lenerService.GetAllLeners());
        }
        public IActionResult Detail(int id)
        {

            return View(new LenerDetailViewModel
            {
                Lener = lenerService.GetLener(id),
                OpenstaandeUitleningen = uitleningService.GetOpenstaandeUitleningenVanLener(id),
                Reserveringen=reserveringService.GetReserveringenVanLener(id)
            }
                ) ;
        }
    }
}