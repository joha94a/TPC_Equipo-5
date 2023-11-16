using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Medico Medico { get; set; }
        public Paciente Paciente { get; set; }
        public string Observaciones { get; set; }
        public TurnoEstado Estado { get; set; }
        public string MedicoStr { get; set; }
        public string PacienteStr { get; set; }
        public string EstadoStr { get; set; }
        public int EstadoValor { get; set; }
        public string FechaStr {
            get {
                return Fecha != null ? Fecha.ToString("dd/MM/yyy") : "";
            }
        }
    }

    public enum TurnoEstado
    {
        Activo = 1,
        Cancelado = 2,
        Completado = 3,
        Ausente = 4
    }
}
