using System;
using System.Collections.Generic;
using System.Text;

using SAPbouiCOM.Framework;

using Forxap.Framework.Extensions;
using Forxap.Framework.Constants;
using Forxap.Framework.UI;

using Vistony.Distribucion.Constans;





using Vistony.Distribucion.Win.UltimaMilla;
using Vistony.EnvioMasivo.Win.Asistentes;

namespace Vistony.Distribucion.Win
{
    public class MainMenuEvent
    {

        static SAPbouiCOM.Form oForm;

        /// <summary>
        /// Capturo los eventos del Menu del AddOn Iker One

        /// <param name="pVal"></param>
        /// <param name="BubbleEvent"></param>
        public void SB1_Application_MainMenuEvent(ref SAPbouiCOM.MenuEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;

            try
            {
                if (pVal.BeforeAction)
                {
                    switch (pVal.MenuUID)
                    {

                        #region   Modulos/EnvioMasivo
                        case AddonMenuItem.vis_EnvioMasivo:
                            {
                                onShowEnvioMasivo();
                            }
                            break;
                        #endregion

                        default:
                            break;

                    } // fin dl switch

                }// fin del IF


            }

            catch (Exception ex)
            {
                Application.SBO_Application.MessageBox(ex.ToString(), 1, "Ok", "", "");
            }
        }/// fin del  metodo




        // integración de SelesForce con SAP

        private void OnShowInicializar()
        {
            try
            {
                //frmInicializar form  = new  frmInicializar();
                //form.Show();
            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }
        

        private void onShowEnvioMasivo()
        {
            try
            {

                WzEnviosMasivosSMS wizard = new WzEnviosMasivosSMS();
               wizard.Show();

            }
            catch (Exception ex)
            {
                Forxap.Framework.UI.Sb1Messages.ShowError(ex.ToString());
            }
        }




    }// fin de la clase


}// fin del namespace
