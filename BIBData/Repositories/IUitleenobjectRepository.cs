using System;
using System.Collections.Generic;
using System.Text;
using BIBData.Models;

namespace BIBData.Repositories
{
    public interface IUitleenobjectRepository
    {
        Uitleenobject Get(int id);
        IEnumerable<Uitleenobject> GetAll();
    }
}
