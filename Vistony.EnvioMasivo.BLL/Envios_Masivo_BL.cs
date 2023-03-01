using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistony.EnvioMasivo.BO;
using Vistony.Masivo.DAL;

namespace Vistony.EnvioMasivo.BLL
{
    public class Envios_Masivo_BL
    {
        Envios_Masivo Em = new Envios_Masivo();
        /*public Cabecera_Mensaje ObtenerCabecera(SAPbouiCOM.Grid dt, string mensaje)
        {
            return Em.ObtenerCabecera(dt, mensaje);
        }*/
        public void GenerarCampania(SAPbouiCOM.Grid dt, SAPbouiCOM.EditText EditText1,
          SAPbouiCOM.EditText EditText0, string CodUsuario, string CodAsignacion, 
          SAPbouiCOM.EditText EditText2,
          SAPbouiCOM.StaticText StaticText10, SAPbouiCOM.EditText EditText4)
        {
             Em.GenerarCampania(dt, EditText1, EditText0, CodUsuario, CodAsignacion,EditText2, StaticText10, EditText4);
        }
       public void EnviarSMS(SAPbouiCOM.EditText EditText0)
        {
            Em.EnviarSMS(EditText0);
        }
        public void FormatoGrilla(SAPbouiCOM.Grid Grid1)
        {
            Em.FormatoGrilla(Grid1);
        }
        public void Get_Cliente_GiroNegocio(SAPbouiCOM.DataTable oDatatable, SAPbouiCOM.Grid Grid1, SAPbouiCOM.Form oForm, string Categoria,
          SAPbouiCOM.StaticText StaticText17, SAPbouiCOM.StaticText StaticText20, SAPbouiCOM.StaticText StaticText21,SAPbouiCOM.EditText EditText0)
        {
            Em.Get_Cliente_GiroNegocio(oDatatable, Grid1, oForm, Categoria,
                StaticText17, StaticText20, StaticText21, EditText0);
        }
    }
}
