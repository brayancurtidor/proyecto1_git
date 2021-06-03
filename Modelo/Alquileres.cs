using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class Alquileres
    {
        public int id_alquiler { get; set; }
        public long dpi_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string apellido_cliente { get; set; }
        public string teleefono_clinete { get; set; }
        public string correo_cliente { get; set; }
        public int id_cancha { get; set; }
        public int id_arbitro { get; set; }
        public DateTime fecha_reservacion { get; set; }
        public TimeSpan hora_inicio_reservacion{get;set;}
        public TimeSpan hora_final_reservacion { get; set; }
        public decimal pago_cancha { get; set; }
        public decimal pago_arbitro { get; set; }
        public decimal total_pagar { get; set; }


    }
}
