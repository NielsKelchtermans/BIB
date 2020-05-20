using BIBData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BIBData.Repositories
{
    public class SQLLenerRepository : ILenerRepository
    {
        //injecteren van de BibDbContext
        private BIBDbContext context;
        public SQLLenerRepository(BIBDbContext context)
        {
            this.context = context;       
        }
        public Lener Get(int id)
        {
            return context.Leners.Find(id);
        }

        public IEnumerable<Lener> GetAll()
        {
            return context.Leners;
        }
    }
}
