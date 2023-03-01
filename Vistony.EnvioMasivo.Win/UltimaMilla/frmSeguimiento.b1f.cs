using SAPbouiCOM.Framework;
using System.Drawing;
using Forxap.Framework.Extensions;


using WebBrowser = SHDocVw.WebBrowser;




namespace Vistony.Distribucion.Win.UltimaMilla
{
    [FormAttribute("Vistony.Distribucion.Win.UltimaMilla.frmSeguimiento", "UltimaMilla/frmSeguimiento.b1f")]
    class frmSeguimiento : UserFormBase
    {
        SAPbouiCOM.Item oItemX;
        SHDocVw.WebBrowser oWebX;
        SAPbouiCOM.ActiveX oActiveX;
        
        public frmSeguimiento()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_0").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("Item_1").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_2").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("Item_3").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_4").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_5").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_6").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_7").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_8").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("Item_9").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
            this.LoadAfter += new LoadAfterHandler(this.Form_LoadAfter);

        }

        private void Form_LoadAfter(SAPbouiCOM.SBOItemEventArg pVal)
        {
           // throw new System.NotImplementedException();

        }

        private void OnCustomInitialize()
        {
            SetProgress(220, 310);
            SetNotExist();
            SetPercentage();

            //oItemX = this.UIAPIRawForm.Items.Add("Browser", SAPbouiCOM.BoFormItemTypes.it_ACTIVE_X);

            //oItemX.Height = this.UIAPIRawForm.Height - 400;

            //oItemX.Width = this.UIAPIRawForm.Width - 200;

            // oActiveX = oItem.Specific

            // oActiveX.ClassID = "Shell.Explorer.2"

            // oWeb = oActiveX.Object // i got error this line

            // oWeb.Navigate("http://emergys.co.in/")



        }

        private SAPbouiCOM.StaticText StaticText0;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;



        private void SetProgress(int progress,int count )
        {
            StaticText5.SetColor(Color.Blue);
            StaticText5.SetHeight(50);
            StaticText5.SetSize(50);
            StaticText5.Caption = string.Format("{0} / {1} ", progress, count);
            
        }

        private void SetNotExist()
        {
            StaticText4.SetColor(Color.Red);
            StaticText4.SetHeight(50);
            StaticText4.SetSize(50);
            StaticText4.Caption = "10";

        }

        private void SetPercentage()
        {
            StaticText7.SetHeight(50);
            StaticText7.SetSize(50);
            StaticText7.Caption = "92 %";

        }


        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
    }
}
