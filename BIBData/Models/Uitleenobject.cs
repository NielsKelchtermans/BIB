using System;
using System.Collections.Generic;
using System.Text;

namespace BIBData.Models
{
    public abstract class Uitleenobject
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public int Jaar { get; set; }
        public Status Status { get; set; }
        public decimal Kostprijs { get; set; }
        public string ImageUrl { get; set; }
    }
}
