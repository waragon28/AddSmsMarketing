using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Vistony.Distribucion.Win;
using Vistony.Masivo.DAL;
using Vistony.EnvioMasivo.BO;
using Newtonsoft.Json;
using Forxap.Framework.UI;
using RestSharp;
using Forxap.Framework.Extensions;
using SAPbobsCOM;
using Vistony.Distribucion.Constans;
using System.Threading;
using Vistony.EnvioMasivo.BLL;

namespace Vistony.EnvioMasivo.Win.Asistentes
{
    [FormAttribute("Vis_EnviosMasivo", "Asistentes/WzEnviosMasivosSMS.b1f")]
    class WzEnviosMasivosSMS : UserFormBase
    {
        public WzEnviosMasivosSMS()
        {
        }
        public string strOwnerForm { get; set; }
        public string MensajePreview { get; set; }
        string RespuestMensaje;

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.Button Button2;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.Grid Grid0;
        private SAPbouiCOM.StaticText StaticText13;
        private SAPbouiCOM.StaticText StaticText14;
        private SAPbouiCOM.StaticText StaticText15;
        private SAPbouiCOM.StaticText StaticText16;
        private SAPbouiCOM.StaticText StaticText17;
        private SAPbouiCOM.EditText EditText0;
        SAPbouiCOM.DataTable oDatatable;
        private SAPbouiCOM.StaticText StaticText11;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText12;
        private SAPbouiCOM.StaticText StaticText18;
        private SAPbouiCOM.StaticText StaticText19;
        private SAPbouiCOM.StaticText StaticText20;
        private SAPbouiCOM.StaticText StaticText21;
        public SAPbouiCOM.Form oForm;
        public int PaneLevel { get; set; }
        public int PaneMax = 4;
        public string usuario = Sb1Globals.UserName;
        public string CodUsuario;
        public string CodAsignacion;
        public string Msm = "";

        Envios_Masivo_BL tr = new Envios_Masivo_BL();
        private void PriorPane()
        {
            if (oForm.PaneLevel + 1 >= 2)
            {
                oForm.PaneLevel -= 1;
            }
            if (oForm.PaneLevel == 2)
            {
                Button0.Item.Enabled = true;
            }
            if (oForm.PaneLevel == 1)
            {
                Button1.Item.Enabled = false;

                oForm.PaneLevel = 1;
                // Button1.Item.Enabled = false;
            }
            if (oForm.PaneLevel == 0)
            {
                //Button1.Item.Enabled = false;
                oForm.PaneLevel = 1;
            }
            if (oForm.PaneLevel == 3)
            {
                oForm.PaneLevel = 2;
                // Button0.Item.Enabled = true;

            }
        }
        private void NextPane()
        {
            Button1.Item.Enabled = true;
            if (PaneLevel < PaneMax)
            {
                oForm.PaneLevel += 1;
            }
            if (oForm.PaneLevel == 1)
            {
                oForm.PaneLevel = 1;
            }
            if (oForm.PaneLevel == 2)
            {
                // Button1.Item.Enabled = true;
                oForm.PaneLevel = 2;
            }
            if (oForm.PaneLevel == 3)
            {
                if (OptionBtn0.Selected)
                {
                    oForm.PaneLevel = 3;
                    GetGiroNegocio(ref ComboBox0);
                    EditText0.Value = "¡VISTONY!.." +
                                           "Trae algo nuevo para ti.."+
                                           "Solo debes  descargar nuestra App VistoPlus y lle\u0301" + "vate grandes premios...." +
                                           "#Vistony #TecnologiaQueGeneraConfianza...."+
                                           "https://bit.ly/3L7TBNH";

                  //  string s = "This is the first line.This is the second line.";
                  //  s = s.Replace(".", ".\n");
                }
            }
           
            if (oForm.PaneLevel==4)
            {
                if (EditText1.Value!="")
                {
                    oForm.PaneLevel =3;
                    var Message = Sb1Messages.ShowMessageBox("Se generara la siguiente campaña " + EditText1.Value+"\n"+" ¿Desea Continuar?");
                    if (Message==2 || Message == 3)
                    {
                        oForm.PaneLevel = 3;
                    }
                    else
                    {
                        oForm.Freeze(true);
                        update_POST_SMS();
                        oForm.PaneLevel = 3;
                        Button0.Item.Enabled = false;
                        Button1.Item.Enabled = false;
                    }
                }
                else
                {
                    oForm.PaneLevel =3;
                    Sb1Messages.ShowError("Ingresar nombre de campaña");
                }

            }


        }
        public void GetGiroNegocio(ref SAPbouiCOM.ComboBox combobox)
        {
            SAPbobsCOM.Recordset oRecordSet = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            string strSQL = string.Empty;

            strSQL = string.Format("CALL P_VIS_ADDON_ENVIO_SMS_GETGIRO_NEGOCIO()");
            Dictionary<string, string> listObject;

            if (combobox != null)
            {
                combobox.RemoveValidValues();
                listObject = Forxap.Framework.DI.Sb1Users.GetListFromSQL(strSQL);
                foreach (var item in listObject)
                {
                    combobox.ValidValues.Add(item.Key, item.Value);
                }
                combobox.Item.DisplayDesc = true;
            }

        }
        public void CargarCodUsuario()
        {
            try
            {
                SAPbobsCOM.Recordset recordset = null;

                recordset = (Recordset)Sb1Globals.oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                if (recordset == null)
                {

                }
                string StrHANA = string.Empty;
                StrHANA = string.Format("CALL P_VIS_ADDON_ENVIO_SMS_GET_EMPLEADO('{0}')", usuario);

                recordset.DoQuery(StrHANA);
                CodUsuario = recordset.Fields.Item("Code").Value.ToString();
                CodAsignacion = recordset.Fields.Item("CodUser").Value.ToString();
            }
            catch (Exception E)
            {
                Sb1Messages.ShowError(E.ToString());
            }
           
        }

        /*EJECUCION EN SEGUNDO PLANO*/
        private void mythread_Get_Cliente_GiroNegocio()
        {

            // Display the name of the
            // current working thread
            Console.WriteLine("In progress thread is: {0}", Thread.CurrentThread.Name);


            //throw new System.NotImplementedException();
            tr.Get_Cliente_GiroNegocio(oDatatable,Grid0, oForm, ComboBox0.Value, StaticText17, StaticText20, StaticText21,EditText0);

            Console.WriteLine("Completed thread is: {0}", Thread.CurrentThread.Name);
        }
        public void update_Get_Cliente_GiroNegocio()
        {
            // Creating and initializing thread
            Thread mythr = new Thread(mythread_Get_Cliente_GiroNegocio);

            // Name of the thread is Geek thread
            mythr.Name = "Geek thread";
            mythr.Start();

            // IsBackground is the property
            // of Thread which allows thread
            // to run in the background
            mythr.IsBackground = true;

            Console.WriteLine("Main Thread Ends!!");

            ///////////////////////////////
        }
        private void mythread_POST_SMS()
        {
            Console.WriteLine("In progress thread is: {0}", Thread.CurrentThread.Name);
            Sb1Messages.ShowWarning("Ejecutando envio de mensaje");
            tr.EnviarSMS(EditText2);
            RespuestMensaje = EditText2.Value;
            if (RespuestMensaje=="OK")
            {
                Sb1Messages.ShowWarning("Generando Campaña "+"");
                CargarCodUsuario();
                if (CodUsuario!="" && CodAsignacion!="")
                {
                    EditText2.Value = "";
                    Sb1Messages.ShowWarning("Validando Campaña " + "");
                    tr.GenerarCampania(Grid0, EditText1, EditText0, CodUsuario, CodAsignacion, EditText2, StaticText10,EditText4);
                    if (EditText2.Value == "CREADO")
                    {
                        Sb1Messages.ShowSuccess("Se Envio Correctamente el mensaje");
                        oForm.Freeze(false);
                        oForm.PaneLevel = 4;
                    }
                  }
                else
                {
                    Sb1Messages.ShowWarning("Validar configuracion del usuario "+usuario);
                }
              
            }
            else
            {
                Sb1Messages.ShowError(RespuestMensaje);
            }

            Console.WriteLine("Completed thread is: {0}", Thread.CurrentThread.Name);
        }
        public void update_POST_SMS()
        {
            // Creating and initializing thread
            Thread mythr = new Thread(mythread_POST_SMS);

            // Name of the thread is Geek thread
            mythr.Name = "Geek thread";
            mythr.Start();

            // IsBackground is the property
            // of Thread which allows thread
            // to run in the background
            mythr.IsBackground = true;

            Console.WriteLine("Main Thread Ends!!");

            ///////////////////////////////
        }
        
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_3").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("Item_7").Specific));
            this.Button0.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button0_ClickAfter);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("Item_8").Specific));
            this.Button1.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button1_ClickAfter);
            this.Button2 = ((SAPbouiCOM.Button)(this.GetItem("Item_9").Specific));
            this.Button2.ClickAfter += new SAPbouiCOM._IButtonEvents_ClickAfterEventHandler(this.Button2_ClickAfter);
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_10").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_11").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_12").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_13").Specific));
            this.ComboBox0.ComboSelectBefore += new SAPbouiCOM._IComboBoxEvents_ComboSelectBeforeEventHandler(this.ComboBox0_ComboSelectBefore);
            this.ComboBox0.ComboSelectAfter += new SAPbouiCOM._IComboBoxEvents_ComboSelectAfterEventHandler(this.ComboBox0_ComboSelectAfter);
            this.ComboBox0.ClickAfter += new SAPbouiCOM._IComboBoxEvents_ClickAfterEventHandler(this.ComboBox0_ClickAfter);
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.Grid0 = ((SAPbouiCOM.Grid)(this.GetItem("Item_16").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_17").Specific));
            this.StaticText11 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_20").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_21").Specific));
            this.StaticText12 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.StaticText13 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.StaticText14 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.StaticText15 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_25").Specific));
            this.StaticText16 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_26").Specific));
            this.StaticText17 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_27").Specific));
            this.StaticText18 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_28").Specific));
            this.StaticText19 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_29").Specific));
            this.StaticText20 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_30").Specific));
            this.StaticText21 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_31").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("Item_32").Specific));
            this.EditText2.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText2_ClickAfter);
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_33").Specific));
            this.EditText4.ClickAfter += new SAPbouiCOM._IEditTextEvents_ClickAfterEventHandler(this.EditText4_ClickAfter);
            this.LinkedButton0 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_15").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_36").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new SAPbouiCOM.Framework.FormBase.LoadAfterHandler(this.Form_LoadAfter);
            this.ClickAfter += new ClickAfterHandler(this.Form_ClickAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void OnCustomInitialize()
        {
            oForm = SAPbouiCOM.Framework.Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);
            oForm.ScreenCenter();
            OptionBtn0.GroupWith("Item_19");
            OptionBtn0.Selected = true;
            StaticText5.SetBold();
            StaticText6.Item.Height = 50;
            StaticText6.SetBold();
            StaticText13.SetBold();
            StaticText7.SetBold();
            StaticText7.Item.Height = 50;
            OptionBtn0.Item.Width = 180;
        }



        private void Button2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            oForm.Close();
        }

        private void Button1_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            PriorPane();
        }

        private void Button0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
            NextPane();
        }

        

        private void Button3_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();

        }

        private void Button3_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {

        }

        private void ComboBox0_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();
           
        }

        private void ComboBox0_ComboSelectAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            StaticText17.Caption = "0";
            StaticText20.Caption = "0";
            StaticText21.Caption = "0";
            update_Get_Cliente_GiroNegocio();
        }


        private void ComboBox0_ComboSelectBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            //throw new System.NotImplementedException();

        }

        private void Button4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
           
        }

        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.LinkedButton LinkedButton0;
        private SAPbouiCOM.EditText EditText4;

        private void EditText2_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            

        }

        private void EditText4_ClickAfter(object sboObject, SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }

        private SAPbouiCOM.StaticText StaticText10;

        private void Form_ClickAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
            //throw new System.NotImplementedException();

        }
    }
}
