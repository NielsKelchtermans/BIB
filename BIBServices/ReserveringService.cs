using System;
using System.Collections.Generic;
using System.Text;
using BIBData.Repositories;
using BIBData.Models;
using System.Linq;

namespace BIBServices
{
    public class ReserveringService
    {
        private IReserveringRepository reserveringRepository;
        private IUitleenobjectRepository uitleenobjectRepository;
        private ILenerRepository lenerRepository;
        public ReserveringService(IReserveringRepository reserveringRepository, IUitleenobjectRepository uitleenobjectRepository, ILenerRepository lenerRepository)
        {
            this.reserveringRepository = reserveringRepository;
            this.uitleenobjectRepository = uitleenobjectRepository;
            this.lenerRepository = lenerRepository;
        }
        public IEnumerable<Reservering> GetReserveringenVoorUitleenobject(int id)
        {
            return reserveringRepository.GetReserveringenVoorUitleenobject(id);
        }

        public void ItemReserveren(int itemId, int lenerId)
        {
            var item = uitleenobjectRepository.Get(itemId);
            var lener = lenerRepository.Get(lenerId);

            reserveringRepository.Add(new Reservering
            {
                Uitleenobject = item,
                Lener = lener,
                GereserveerdOp = DateTime.Now

            }) ;
        }
        public Lener GetEersteLenerOpReserveringslijst(int uitleenobjectId)
        {
            return reserveringRepository.GetReserveringenVoorUitleenobject(uitleenobjectId)
                .FirstOrDefault()?.Lener;
        }

        public void ReserveringVerwijderen(int itemId, int lenerId)
        {
            reserveringRepository.VerwijderReservering(itemId, lenerId);
        }
    }
}