using System;
using System.Collections.Generic;
using System.Text;
using BIBData.Models;
using BIBData.Repositories;

namespace BIBServices
{
    public class UitleenObjectService
    {
        private IUitleenobjectRepository uitleenobjectRepository;
        public UitleenObjectService(IUitleenobjectRepository uitleenobjectRepository)
        {
            this.uitleenobjectRepository = uitleenobjectRepository;
        }

        //voor index
        public IEnumerable<Uitleenobject> GetAllUitleenobjecten()
        {
            return uitleenobjectRepository.GetAll();
        }
        public Uitleenobject GetUitleenobject(int id)
        {
            return uitleenobjectRepository.Get(id);
        }
        
        //method nodig om het verschil te maken tussen boek en device  ... type ziet er zo uit: "BIBData.Models.Boek" 
        public string GetUitleenObjectType(int id)
        {
            return uitleenobjectRepository.Get(id).GetType().ToString().Contains("Boek") ? "Boek" : "Device";   //mooie beknopte formulering
        }

        //we willen uiteindelijk een string van Details
        public string GetDetails(int id)
        {
            if (GetUitleenObjectType(id)=="Boek")
            {
                var boek = uitleenobjectRepository.GetBoek(id);
                return boek.ISBN + " (" + boek.Auteur + ", " + boek.Aantalpaginas + "p.)";
            }
            else
            {
                var device = uitleenobjectRepository.GetDevice(id);
                return device.Operatingsysteem.Naam + " - " + device.Schermgrootte + "\"";
            }
        }

    }
}
