using System;
using System.Collections.Generic;
using System.Text;
using BIBData.Models;

namespace BIBData.Repositories
{
    public interface IUitleningRepository
    {
        Uitlening Get(int uitleenId);
        IEnumerable<Uitlening> GetAll();
        void Add(Uitlening nieuweUitlening);
        void SetReturnDate(int uitleenobjectId, DateTime now);
        

    }
}
