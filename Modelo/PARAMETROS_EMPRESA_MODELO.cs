using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Administracion_Torneos.Modelo
{
    public class PARAMETROS_EMPRESA_MODELO
    {
        public int id_empresa { get; set; }
        public string nombre_empresa { get; set; }
        public TimeSpan inicio_lunes_viernes { get; set; }
        public TimeSpan fin_lunes_viernes { get; set; }
        public TimeSpan inicio_jornada_sabado { get; set; }
        public TimeSpan fin_jornada_sabado { get; set; }
        public TimeSpan inicio_jornada_domingos { get; set; }
        public TimeSpan fin_jornada_domingos { get; set; }


    }
}
