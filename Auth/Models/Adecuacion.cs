﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auth.Models
{
    public class Adecuacion
    {
        public int Id { get; set; }

        public int IdCilindraje { get; set; }

        public string DesAdecuacion { get; set; }

        public bool Activo { get; set; }
    }
}