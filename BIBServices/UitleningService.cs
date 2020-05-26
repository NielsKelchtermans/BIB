using System;
using System.Collections.Generic;
using System.Text;
using BIBData.Repositories;
using BIBData.Models;

namespace BIBServices
{
    public class UitleningService
    {
        private IUitleenobjectRepository uitleenobjectRepository;
        private IUitleningRepository uitleningRepository;
        private ILenerRepository lenerRepository;
        private IReserveringRepository reserveringRepository;
        public UitleningService(IUitleenobjectRepository uitleenobjectRepository,
        IUitleningRepository uitleningRepository, ILenerRepository lenerRepository, IReserveringRepository reserveringRepository)
        {
            this.uitleenobjectRepository = uitleenobjectRepository;
            this.uitleningRepository = uitleningRepository;
            this.lenerRepository = lenerRepository;
            this.reserveringRepository = reserveringRepository;
        }

        public void UitleningRegistreren(int uitleenobjectId, int LenerId)
        {
            var item = uitleenobjectRepository.Get(uitleenobjectId);
            var lener = lenerRepository.Get(LenerId);
            item.Status = Status.Uitgeleend;
            uitleningRepository.Add(new Uitlening { Uitleenobject = item, Lener = lener, Van = DateTime.Now, Tot = null });
        }

        public void ItemTerugbrengen(int uitleenobjectId)
        {
            //datum "tot" invullen
            uitleningRepository.SetReturnDate(uitleenobjectId,  DateTime.Now);

            if (reserveringRepository.IsGereserveerd(uitleenobjectId))
            {
                uitleenobjectRepository.SetStatus(uitleenobjectId, Status.Gereserveerd);
            }
            else
            {
                //wijzig status in beschikbaar
                uitleenobjectRepository.SetStatus(uitleenobjectId, Status.Beschikbaar);
            }
            
        }

        public string GetHuidigeUitlener(int uitleenobjectId)
        {
            var uitlening = uitleningRepository.GetOpenstaandeUitleningVoorUitleenobject(uitleenobjectId);

            if (uitlening == null)
            {
                return "Niet uitgeleend";
            }
            else
            {
                return uitlening.Lener.Voornaam + " " + uitlening.Lener.Familienaam;
            }
        }
        public IEnumerable<Uitlening> GetOpenstaandeUitleningenVanLener(int lenerId)
        {
            return uitleningRepository.GetOpenstaandeUitleningenVanLener(lenerId);
        }
    }
}
