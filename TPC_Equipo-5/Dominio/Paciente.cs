using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Paciente
    {
        public int Id { get; set; }
        public int DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Nacimiento { get; set; }
        public string Genero { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Observaciones { get; set; }
        public string Fecha_NacimientoStr
        {
            get
            {
                return Fecha_Nacimiento != null ? Fecha_Nacimiento.ToString("dd/MM/yyy") : string.Empty;
            }
        }
        public string GeneroStr
        {
            get
            {
                string str = string.Empty;
                if (Genero == "M") str = "Masculino";
                else if (Genero == "F") str = "Femenino";
                else str = "Otro";
                return str;
            }
        }
    }
}
