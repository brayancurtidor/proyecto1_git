using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class REPORTE_ARBITROS_ALQUILER_MODELO
    {
        public int DPI_arbitros { get; set; }
        public string nombres_arbitros { get; set; }
        public string apellidos_arbitros { get; set; }
        public int año { get; set; }
        public int mes { get; set; }
        public int dia { get; set; }
        public decimal monto_por_dia_tootal { get; set; }


    }
}
