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

        //extra methods omdat we ook de afgeleide classes volledig willen tonen:
        Boek GetBoek(int id);
        Device GetDevice(int id);

        //extra voor terugbrengen
        void SetStatus(int uitleenobjectId, Status status);
    }
}
