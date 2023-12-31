﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Horario
    {
        public int Id { get; set; }
        public Dia Dia { get; set; }
        public TimeSpan Hora_Inicio { get; set; }
        public TimeSpan Hora_Fin { get; set; }
        public Medico Medico { get; set; }
        public string Hora_InicioStr 
        {
            get
            {
                return Hora_Inicio.ToString(@"hh\:mm");
            }
        }
        public string Hora_FinStr
        {
            get
            {
                return Hora_Fin.ToString(@"hh\:mm");
            }
        }
        public string DiaStr
        {
            get
            {
                switch (Dia)
                {
                    case Dia.Lunes:
                        return "Lunes";
                        break;
                    case Dia.Martes:
                        return "Martes";
                        break;
                    case Dia.Miercoles:
                        return "Miercoles";
                        break;
                    case Dia.Jueves:
                        return "Jueves";
                        break;
                    case Dia.Viernes:
                        return "Viernes";
                        break;
                    case Dia.Sabado:
                        return "Sabado";
                        break;
                    case Dia.Domingo:
                        return "Domingo";
                        break;
                    default:
                        return "";
                        break;
                }
            }
        }
    }

    public enum Dia
    {
        Lunes = 1,
        Martes = 2,
        Miercoles = 3,
        Jueves = 4,
        Viernes = 5,
        Sabado = 6,
        Domingo = 7
    }
}
