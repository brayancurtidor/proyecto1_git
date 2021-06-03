using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public  class disponibilidad_cancha_modelo_modelo
    {

        public int numero_cancha { get; set; }
        public string nombre_cancha { get; set; }
        public DateTime fecha_uso_cancha
        {
            set;
            get;

        }

        public TimeSpan horaInicio_uso_cancha
        {
            set;
            get;

        }

        public TimeSpan horaFin_uso_cancha
        {
            set;
            get;

        }



    }
}
