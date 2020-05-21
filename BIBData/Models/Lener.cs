using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BIBData.Models
{
    public class Lener
    {

        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Adres { get; set; }
        [DisplayFormat(DataFormatString ="{0:d-M-yyyy}")]
        public DateTime Geboortedatum { get; set; }
        public string Telefoonnr { get; set; }

        //
        public IEnumerable<Uitlening> Uitleningen { get; set; }

    }

}
