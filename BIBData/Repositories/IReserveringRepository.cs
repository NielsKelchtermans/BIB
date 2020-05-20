using System;
using System.Collections.Generic;
using System.Text;
using BIBData.Models;

namespace BIBData.Repositories
{
    public interface IReserveringRepository
    {
        void Add(Reservering reservering);
    }
}
