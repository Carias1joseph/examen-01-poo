using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen01.Api.Entities
{
    public class InversionEntity
    {
        public double CapitalInicial { get; set; }
        public double TasaInteresAnual { get; set; } 
        public int Anios { get; set; }
        public double AportacionMensual { get; set; }
    }
}
