using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BIBServices;
using BIBWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BIBWeb.Controllers
{
    public class UitleenObjectController : Controller
    {
        private UitleenObjectService UitleenObjectService;
        private LenerService lenerService;
        private UitleningService UitleningService;
        public UitleenObjectController(UitleenObjectService uitleenObjectService, LenerService lenerService, UitleningService uitleningService)
        {
            this.UitleenObjectService = uitleenObjectService;
            this.lenerService = lenerService;
            this.UitleningService = uitleningService;
        }
        public IActionResult Index()
        {
            var objecten = UitleenObjectService.GetAllUitleenobjecten();
            //elke van de lijst van objecten in een UitleenobjectDetailViewModel steken
            var listResult = objecten.Select(result => new UitleenobjectDetailViewModel
            {
                Id = result.Id,
                Naam = result.Naam,
                Jaar = result.Jaar,
                Kostprijs = result.Kostprijs,
                Status = result.Status,
                ImageUrl = result.ImageUrl,
                Details = UitleenObjectService.GetDetails(result.Id),
                Type = UitleenObjectService.GetUitleenObjectType(result.Id)
            });

                

            return View(listResult);
        }
        public IActionResult Detail(int id)
        {
            var item = UitleenObjectService.GetUitleenobject(id);
            var model = new UitleenobjectDetailViewModel
            {
                Id = id,
                Naam = item.Naam,
                Jaar = item.Jaar,
                Kostprijs = item.Kostprijs,
                Status = item.Status,
                ImageUrl = item.ImageUrl,
                Details = UitleenObjectService.GetDetails(id),
                Type = UitleenObjectService.GetUitleenObjectType(id)
            };
            return View(model);
        }
        public IActionResult Uitlenen(int id)
        {
            //eerst object ophalen
            var item = UitleenObjectService.GetUitleenobject(id);
            //de selectlist al aanmaken dan vullen
            var lenerSelectList = new List<SelectListItem>();
            foreach (var lener in lenerService.GetAllLeners())
            {
                lenerSelectList.Add(new SelectListItem
                {
                    Text = lener.Voornaam + " " + lener.Familienaam,
                    Value= lener.Id.ToString()
                });
            }
            var model = new UitleenViewModel
            {
                ItemId = id,
                ImageUrl = item.ImageUrl,
                Naam = item.Naam,
                Leners = lenerSelectList
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UitleningRegistreren(int itemId, int GekozenLenerId)
        {
            UitleningService.UitleningRegistreren(itemId, GekozenLenerId);
            return RedirectToAction("Detail", new { id = itemId });
        }

        [HttpPost]
        public IActionResult Terugbrengen(int id)
        {
            UitleningService.ItemTerugbrengen(id);
            return RedirectToAction("Index");
        }
    }
}