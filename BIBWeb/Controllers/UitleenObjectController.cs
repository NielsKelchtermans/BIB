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
        private ReserveringService reserveringService;
        public UitleenObjectController(UitleenObjectService uitleenObjectService, LenerService lenerService,
            UitleningService uitleningService,ReserveringService reserveringService)
        {
            this.UitleenObjectService = uitleenObjectService;
            this.lenerService = lenerService;
            this.UitleningService = uitleningService;
            this.reserveringService = reserveringService;
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
                Type = UitleenObjectService.GetUitleenObjectType(id),
                HuidigeUitlener = UitleningService.GetHuidigeUitlener(id),
                Wachtlijst = reserveringService.GetReserveringslijst(id),
                EersteInWachtlijst = reserveringService.GetEersteLenerOpReserveringslijst(id)
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
        public IActionResult Reserveren(int id)
        {
            //uitleenobject zoeken
            var item = UitleenObjectService.GetUitleenobject(id);

            //reserveringenlijst
            var reserveringenLijst = reserveringService.GetReserveringenVoorUitleenobject(id);

            //lenerslijst
            var lenerSelectList = new List<SelectListItem>();
            foreach (var lener in lenerService.GetAllLeners())
            {
                lenerSelectList.Add(new SelectListItem
                {
                    Text = lener.Voornaam + " " + lener.Familienaam,
                    Value = lener.Id.ToString()
                }) ;

            }
            //Viewmodel invullen
            var model = new ReserveerViewModel
            {
                ItemId = id,
                ImageUrl = item.ImageUrl,
                Naam = item.Naam,
                Reserveringen = reserveringenLijst,
                Leners= lenerSelectList
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult ItemReserveren(int itemId, int GekozenLenerId)
        {
            reserveringService.ItemReserveren(itemId, GekozenLenerId);
            return RedirectToAction("Detail", new { id = itemId });
        }

        [HttpPost]
        public IActionResult ReserveringOphalen(int itemId, int lenerId)
        {
            //oudste reservering verwijderen van dit item
            reserveringService.ReserveringVerwijderen( itemId, lenerId);
            //item uitlenen aan eerste in wachtlijst
            UitleningService.UitleningRegistreren(itemId, lenerId);

            return RedirectToAction("Detail", new { id = itemId });

        }



    }
}