﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Contrasena { get; set; }
        public PerfilAcceso PerfilAcceso { get; set; }
        public Medico Medico { get; set; }
        public bool Activo { get; set; }
    }
}
