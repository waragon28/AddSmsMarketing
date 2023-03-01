using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SAPbouiCOM.Framework;

namespace Vistony.EnvioMasivo.Win.Asistentes
{
    [FormAttribute("Vistony.EnvioMasivo.Win.Asistentes.PrevisualizarSMS", "Asistentes/PrevisualizarSMS.b1f")]
    class PrevisualizarSMS : UserFormBase
    {
        public PrevisualizarSMS()
        {
        }

        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        public string MsmPrevisualizar { get; set; }
        public PrevisualizarSMS( string oForm, string   Mensaje)
        {
            strOwnerForm = oForm;
            MsmPrevisualizar = Mensaje;
            EditText7.Value = MsmPrevisualizar;
        }
        public string strOwnerForm { get; set; }
        
        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("Item_7").Specific));
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_1").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void OnCustomInitialize()
        {

        }
        

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.StaticText StaticText0;
    }
}
