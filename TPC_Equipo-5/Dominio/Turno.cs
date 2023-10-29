﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int Numero { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public string Observaciones { get; set; }
        public Estado Estado { get; set; } 
    }
}
