using BIBData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BIBData.Repositories
{
    public class SQLUitleenobjectRepository : IUitleenobjectRepository
    {
        private BIBDbContext context;
        public SQLUitleenobjectRepository(BIBDbContext context)
        {
            this.context = context;
        }
        public Uitleenobject Get(int id)
        {
            return context.Uitleenobjecten.Find(id);
        }

        public IEnumerable<Uitleenobject> GetAll()
        {
            return context.Uitleenobjecten;
        }

        public Boek GetBoek(int id)
        {
            return context.Boeken.Find(id);
        }

        public Device GetDevice(int id)
        {
            return context.Devices
                .Include(m => m.Operatingsysteem)
                .FirstOrDefault(x => x.Id == id);
        }

        public void SetStatus(int uitleenobjectId, Status status)
        {
            var item = context.Uitleenobjecten.Find(uitleenobjectId);
            item.Status = status;
            context.SaveChanges();
        }
    }
}
