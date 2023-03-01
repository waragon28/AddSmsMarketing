using Forxap.Framework.Extensions;
using Forxap.Framework.UI;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vistony.EnvioMasivo.BO;

namespace Vistony.Masivo.DAL
{
    public class Envios_Masivo
    {
        private Cabecera_Mensaje ObtenerClientes = new Cabecera_Mensaje();

        List<Data> ListtransferDocumentDetalls = new List<Data>();
        Data transferDocumentDetalls = new Data();

        public Cabecera_Mensaje ObtenerCabecera()
        {
            List<Cabecera_Mensaje> ListtransferDocument = new List<Cabecera_Mensaje>();
            Cabecera_Mensaje transferDocument = new Cabecera_Mensaje();

            transferDocument.Data = /*listOfUsers*/ ListtransferDocumentDetalls2;
            return transferDocument;
        }
        public Campaigns ObtenerCabeceraCampania(SAPbouiCOM.Grid dt, string mensaje,
            string CampaignName,string Owner,string AssignName)
        {
            List<Campaigns> ListCampaignsDocument = new List<Campaigns>();
            Campaigns CampaignsDocument = new Campaigns();

            CampaignsDocument.CampaignName = CampaignName;
            CampaignsDocument.CampaignType = "S";
            CampaignsDocument.Owner = Owner;
            CampaignsDocument.Status = "csOpen";
            CampaignsDocument.StartDate = DateTime.Now.ToString("yyyyMMdd");
            CampaignsDocument.FinishDate = DateTime.Now.ToString("yyyyMMdd");
            CampaignsDocument.Remarks = mensaje;
            CampaignsDocument.TargetGroupType = "tgtCustomer";
            CampaignsDocument.CampaignBusinessPartners = ObtenerDetalleCompania(dt, AssignName);
            return CampaignsDocument;
        }
        public List<CampaignBusinessPartners> ObtenerDetalleCompania(SAPbouiCOM.Grid dt,
            string AssignName)
        {
            List<CampaignBusinessPartners> ListtransferDocumentDetalls = new List<CampaignBusinessPartners>();
            for (int oRows = 0; oRows < dt.Rows.Count; oRows++)
            {
                CampaignBusinessPartners transferDocumentDetalls = new CampaignBusinessPartners();
                string GetTelef = dt.DataTable.GetValue("Telefono", oRows).ToString();
                if (GetTelef.Length == 9 && dt.DataTable.GetString("*", oRows) == "Y")
                {
                    transferDocumentDetalls.BPCode = dt.DataTable.GetValue("Cod Cliente", oRows).ToString();
                    transferDocumentDetalls.BPGroupName = "Clte.Local Tercero";
                    transferDocumentDetalls.BPStatus = "A";
                    transferDocumentDetalls.AssignName = AssignName;
                    transferDocumentDetalls.CreateActivity = "tNO";

                    ListtransferDocumentDetalls.Add(transferDocumentDetalls);
                }

            }
            return ListtransferDocumentDetalls;

        }

        /*PRUBE*/
        public string Mensaje { get; set; }
        public string NumeroTelf { get; set; }
        List<Data> listOfUsers = new List<Data>()
                    {
                    /*new Data() {  Mensaje= "¡VISTONY!\n" +
                                           "Trae algo nuevo para ti" + "\n" +
                                           "Solo debes  descargar nuestra App VistoPlus y lle\u0301" +"vate grandes premios." + "\n\n" +
                                           "#Vistony #TecnologiaQueGeneraConfianza." + "\n\n"+
                                           "https://bit.ly/3L7TBNH",
                                   NumeroTelf = "51958792500" }/*--,
                      new Data() {  Mensaje= "¡VISTONY!\n" +
                                           "Trae algo nuevo para ti" + "\n" +
                                           "Solo debes  descargar nuestra App VistoPlus y lle\u0301" +"vate grandes premios." + "\n\n" +
                                           "#Vistony #TecnologiaQueGeneraConfianza." + "\n\n"+
                                           "https://play.google.com/store/apps/details?id=com.vistony.clientes",
                                   NumeroTelf = "51946159770" }*/
                        };

        public void EnviarSMS(SAPbouiCOM.EditText RespuestMensaje)
        {
          
            try
            {
                Cabecera_Mensaje ObtenerCabecera2 = new Cabecera_Mensaje();

                ObtenerCabecera2 = ObtenerCabecera();

                RestClient client = new RestClient("http://192.168.254.20:88/vs1.0/sms");
                RestRequest request = new RestRequest(Method.POST);
                string JsonObtenerCabezera = JsonConvert.SerializeObject(ObtenerCabecera2);
                string dataReq = JsonObtenerCabezera;
                IRestResponse result = client.Execute(request.AddJsonBody(dataReq));

                if (result.StatusDescription == "OK")
                {
                    RespuestMensaje.Value= "OK";
                }
                else
                {
                    Sb1Messages.ShowError(result.Content);
                    RespuestMensaje.Value = "ERROR";
                }
            }
            catch (Exception e)
            {

                Sb1Messages.ShowError(e.ToString());
            }



        }
        public void GenerarCampania(SAPbouiCOM.Grid dt,SAPbouiCOM.EditText EditText1,
            SAPbouiCOM.EditText EditText0,string CodUsuario,string CodAsignacion, 
            SAPbouiCOM.EditText EditText2,
            SAPbouiCOM.StaticText StaticText10, SAPbouiCOM.EditText EditText4)
        {
            //Sb1Messages.ShowWarning(AddonMessageInfo.FinishLoading);
            //Sb1Messages.ShowWarning(AddonMessageInfo);
            Envios_Masivo tr = new Envios_Masivo();
            Campaigns ObtenerCabecera2 = new Campaigns();
            string CampaignName = EditText1.Value;
        
            ObtenerCabecera2 = tr.ObtenerCabeceraCampania(dt, EditText0.Value, CampaignName,
                CodUsuario, CodAsignacion);
            // ObtenerCabecera2
            string JsonObtenerCabezera = JsonConvert.SerializeObject(ObtenerCabecera2);

            IRestResponse responsde;
            Forxap.Framework.ServiceLayer.Methods Methods = new Forxap.Framework.ServiceLayer.Methods();
            dynamic entrada = JsonObtenerCabezera;
            responsde = Methods.POST("Campaigns", entrada.ToString());
            dynamic m = JsonConvert.DeserializeObject(responsde.Content.ToString());
            EditText2.Value = "";
            if (responsde.StatusCode.ToString() == "Created")
            {
                StaticText10.Caption = m["CampaignNumber"].ToString();
                EditText4.Value = m["CampaignNumber"].ToString();
                EditText2.Value = "CREADO";
            }
            else
            {
                Sb1Messages.ShowError(m["error"]["message"]["value"].ToString());
            }
        }
        public void FormatoGrilla(SAPbouiCOM.Grid Grid1)
        {
           // Grid1.AssignLineNro();
            Grid1.Columns.Item(0).Type = SAPbouiCOM.BoGridColumnType.gct_CheckBox;
            Grid1.Columns.Item(1).LinkedObjectType(Grid1, "Cod Cliente", "2");
            Grid1.AutoResizeColumns();
            Grid1.ReadOnlyColumns();
            Grid1.Columns.Item(0).Editable = true;
        }
        List<Data> ListtransferDocumentDetalls2 = new List<Data>();
        public void Get_Cliente_GiroNegocio(SAPbouiCOM.DataTable oDatatable,SAPbouiCOM.Grid Grid1, SAPbouiCOM.Form oForm, string Categoria,
           SAPbouiCOM.StaticText StaticText17, SAPbouiCOM.StaticText StaticText20, SAPbouiCOM.StaticText StaticText21,SAPbouiCOM.EditText EditText0)
        {
            Sb1Messages.ShowWarning("Cargando Clientes");
            try
            {
               
                string strHANA = "";

                strHANA = string.Format(" CALL P_VIS_ADDON_ENVIO_SMS_GET_CLIENTES_GIRO_NEGOCIO('{0}')", Categoria);

                oDatatable = oForm.DataSources.DataTables.Item("DT_0");
                oForm.Freeze(true);
                oDatatable.ExecuteQuery(strHANA);
                FormatoGrilla(Grid1);

                int contado = 0;
                int contado_Correctos = 0;
                int contado_Incorrectos = 0;
                contado = Grid1.Rows.Count;
                for (int oRows = 0; oRows < contado; oRows++)
                {

                    Data transferDocumentDetalls2 = new Data();
                    if (Convert.ToString(Grid1.DataTable.GetValue("*", oRows)) == "N")
                    {
                        Grid1.SetRowBackColor(oRows, 198164156);
                        contado_Correctos += 1;
                    }
                    else
                    {
                        string s = EditText0.Value.ToString();
                       
                        contado_Incorrectos += 1;
                        transferDocumentDetalls2.Mensaje = s.Replace("..", "\n");
                        /* "¡VISTONY!\n" +
                       "Trae algo nuevo para ti" + "\n" +
                       "Solo debes  descargar nuestra App VistoPlus y lle\u0301" + "vate grandes premios." + "\n\n" +
                       "#Vistony #TecnologiaQueGeneraConfianza." + "\n\n" +
                       "https://bit.ly/3L7TBNH";*/
                        transferDocumentDetalls2.NumeroTelf = "51"+Convert.ToString(Grid1.DataTable.GetValue("Telefono", oRows));
                        ListtransferDocumentDetalls2.Add(transferDocumentDetalls2);
                        
                    }

                }

                oForm.Freeze(false);
                StaticText17.Caption = Convert.ToString(contado);
                StaticText20.Caption = Convert.ToString(contado_Correctos);
                StaticText21.Caption = Convert.ToString(contado_Incorrectos);

                Sb1Messages.ShowSuccess("Se cargaron todos los clientes");

            }
            catch (Exception EX)
            {
                Sb1Messages.ShowError(string.Format(EX.ToString()));
            }
        }

    }
}
