using BIBData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BIBData.Repositories
{
    public class SQLReserveringRepository : IReserveringRepository
    {
        private BIBDbContext context;
        public SQLReserveringRepository(BIBDbContext context)
        {
            this.context = context;
        }
        public void Add(Reservering reservering)
        {
            context.Reserveringen.Add(reservering);
            context.SaveChanges();
        }

        public IEnumerable<Reservering> GetReserveringenVoorUitleenobject(int uitleenobjectId)
        {
            return context.Reserveringen.Include(r => r.Lener)
                .Where(r => r.Uitleenobject.Id == uitleenobjectId)
                .OrderBy(r => r.GereserveerdOp);
        }

        public bool IsGereserveerd(int uitleenobjectId)
        {
            var reservering = context.Reserveringen.Include(r => r.Uitleenobject)
                .FirstOrDefault(r => r.Uitleenobject.Id == uitleenobjectId);
            if (reservering==null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
