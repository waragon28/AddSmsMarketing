using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;
using Forxap.Framework.Extensions;
using Forxap.Banco.UI.Constans;

namespace Forxap.Banco.UI.Win.Configuracion
{
    [FormAttribute(AddonWinForms.frmParametros, "Configuracion/frmParametrizacion.b1f")]
    class frmParametrizacion : UserFormBase
    {
        public frmParametrizacion()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.Button1.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.Button1_ClickBefore);
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("5").Specific));
            this.Folder0 = ((SAPbouiCOM.Folder)(this.GetItem("Item_5").Specific));
            this.Folder1 = ((SAPbouiCOM.Folder)(this.GetItem("Item_6").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("Item_12").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("Item_13").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_14").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_15").Specific));
            this.CheckBox2 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_16").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_17").Specific));
            this.CheckBox3 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_18").Specific));
            this.CheckBox4 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_19").Specific));
            this.CheckBox5 = ((SAPbouiCOM.CheckBox)(this.GetItem("Item_20").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_21").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_22").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_23").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_24").Specific));
            this.OptionBtn0 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_25").Specific));
            this.OptionBtn1 = ((SAPbouiCOM.OptionBtn)(this.GetItem("Item_26").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("Item_27").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("Item_28").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("Item_29").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_30").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_31").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_32").Specific));
           
            this.LinkedButton1 = ((SAPbouiCOM.LinkedButton)(this.GetItem("Item_35").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.Button Button0;

        private void OnCustomInitialize()
        {
            Folder0.Select();
            oForm = Application.SBO_Application.Forms.Item(this.UIAPIRawForm.UniqueID);

            // inicializo la tabla de parametrizaciones
           if (  Utils.InitConfig() );
            // ahora debo posicionar la  pantalla con el UDO con el code "CONFIG"

            oForm.Mode = SAPbouiCOM.BoFormMode.fm_FIND_MODE;
            // ahora busco el Code = CONFIG
            oForm.SetEditText("5", "CONFIG");
            // ahora le doy click al boton  Buscar 
            oForm.Items.Item("1").Click();
         

            //StaticText4.SetUnderline();
            //StaticText8.SetUnderline();
        }

        public static SAPbouiCOM.Form oForm { get; set; }
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.Folder Folder0;
        private SAPbouiCOM.Folder Folder1;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.CheckBox CheckBox2;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.CheckBox CheckBox3;
        private SAPbouiCOM.CheckBox CheckBox4;
        private SAPbouiCOM.CheckBox CheckBox5;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.OptionBtn OptionBtn0;
        private SAPbouiCOM.OptionBtn OptionBtn1;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.LinkedButton LinkedButton1;

        private void Button1_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            throw new System.NotImplementedException();

        }
    }
}
