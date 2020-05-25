using BIBData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIBData.Repositories
{
    public class SQLUitleningRepository : IUitleningRepository
    {
        private BIBDbContext context;
        public SQLUitleningRepository(BIBDbContext context)
        {
            this.context = context;
        }
        public void Add(Uitlening nieuweUitlening)
        {
            context.Add(nieuweUitlening);
            context.SaveChanges();
        }

        public Uitlening Get(int uitleenId)
        {
            return context.Uitleningen.Find(uitleenId);
        }

        public IEnumerable<Uitlening> GetAll()
        {
            return context.Uitleningen;
        }

        public void SetReturnDate(int uitleenobjectId, DateTime now)
        {
            var uitlening = context.Uitleningen
                .Where(u => u.Tot == null)
                .Where(u => u.Uitleenobject.Id == uitleenobjectId)
                .FirstOrDefault();
            uitlening.Tot = now;
            context.SaveChanges();
        }
    }
}
