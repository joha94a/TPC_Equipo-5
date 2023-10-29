using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Medico
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public List<Especialidad> Especialidades { get; set; }
        public List<Horario> Horarios { get; set; }
    }
}
