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
        public UitleningService(IUitleenobjectRepository uitleenobjectRepository,
        IUitleningRepository uitleningRepository, ILenerRepository lenerRepository)
        {
            this.uitleenobjectRepository = uitleenobjectRepository;
            this.uitleningRepository = uitleningRepository;
            this.lenerRepository = lenerRepository;
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
            uitleningRepository.SetReturnDate(uitleenobjectId, DateTime.Now);
            //wijzig status in beschikbaar
            uitleenobjectRepository.SetStatus(uitleenobjectId, Status.Beschikbaar);
        }
    }
}
