using System;
using System.Collections.Generic;
using System.Text;
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


    }
}
