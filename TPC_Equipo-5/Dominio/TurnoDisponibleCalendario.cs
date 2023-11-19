using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TurnoDisponibleCalendario
    {
        public int Id { get; set; }
        public int MedicoId { get; set; }
        public string MedicoStr { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora { get; set; }
        public string HoraStr 
        { 
            get 
            {
                return Hora.ToString(@"hh\:mm");
            } 
        }
        public string FechaStr
        {
            get
            {
                return Fecha.ToString("dd/MM/yyy");
            }
        }
    }
}
