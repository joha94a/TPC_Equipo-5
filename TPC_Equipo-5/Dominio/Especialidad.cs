﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
