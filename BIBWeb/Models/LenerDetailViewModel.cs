﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BIBData.Models;

namespace BIBWeb.Models
{
    public class LenerDetailViewModel
    {
        public Lener Lener { get; set; }
        public IEnumerable<Uitlening> OpenstaandeUitleningen { get; set; }
        public IEnumerable<Reservering> Reserveringen { get; set; }
    }
}
