using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.BO
{


    public class EntregaConsolidado
    {
        public string U_SYP_DT_CONSOL { get; set; }
        public string U_SYP_DT_FCONSOL { get; set; }
        public string U_SYP_DT_HCONSOL { get; set; }
    }

    public class EntregaDespacho
    {
        public string U_SYP_MDFC { get; set; }
        public string U_SYP_DT_CORRDES { get; set; }
        public string U_SYP_DT_FCDES { get; set; }
        public string U_SYP_MDFN { get; set; }
        public string U_SYP_MDVC { get; set; }
        public string U_SYP_DT_AYUDANTE { get; set; }
        public string U_SYP_DT_ESTDES { get; set; }

    }

    public class EstadoDespacho
    {
        public string U_SYP_DT_ESTDES { get; set; }
        public string U_SYP_DT_OCUR { get; set; }
    }
}
