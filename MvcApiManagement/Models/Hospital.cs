﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiManagement.Models
{
    public class Hospital
    {
        public int IdHospital { get; set;}
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int Camas { get; set; }
    }
}
