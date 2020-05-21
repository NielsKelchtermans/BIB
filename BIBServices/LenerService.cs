using System;
using System.Collections.Generic;
using System.Text;
using BIBData.Models;
using BIBData.Repositories;

namespace BIBServices
{
    public class LenerService
    {
        //injectie van LenerRepository
        private ILenerRepository lenerRepository;

        public LenerService(ILenerRepository lenerRepository)
        {
            this.lenerRepository = lenerRepository;
        }

        //voor Index van LenerController
        public IEnumerable<Lener> GetAllLeners()
        {
            return lenerRepository.GetAll();
        }
        //Voor Detail van LenerController
        public Lener GetLener(int id)
        {
            return lenerRepository.Get(id);
        }


    }
}
