using System;
using System.Collections.Generic;
using System.Text;

namespace BIBData.Models
{
    public class Boek:Uitleenobject
    {
        public string ISBN { get; set; }
        public string Auteur { get; set; }
        public int Aantalpaginas { get; set; }
    }
}
