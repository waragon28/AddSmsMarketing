using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vistony.Distribucion.Constans
{
    public class AddonMessageInfo
    {

        public const string AddonName = "Addon Vistony Envio Masivo SMS ";

        public const string SAPNotRunning = AddonName + "SAP Business One, no se encuentra corriendo ";
        
        public const string StartLoading = AddonName + "Iniciando Carga ..." ;
        public const string FinishLoading = AddonName + "Carga Finalizada ...";

        public const string Message001 = AddonName + "Iniciando Carga de Menu...";
        public const string Message002 = AddonName + "Finalizado Carga de Menu...";
        public const string Message003 = AddonName + "Error al Cargar el Menu";
        
        public const string Message004 = AddonName + "Iniciando Carga de Tablas...";
        public const string Message005 = AddonName + "Finalizado Carga de Tablas...";
        public const string Message006 = AddonName + "Error al Cargar Tablas...";
 
        public const string Message007 = AddonName + "Iniciando Carga de Campos...";
        public const string Message008 = AddonName + "Finalizado Carga de Campos...";
        public const string Message009 = AddonName + "Error al Cargar Campos...";

        public const string Message010 = AddonName + "Iniciando Registro de Objetos de Usuario...";
        public const string Message011 = AddonName + "Finalizado Registro de Objetos de Usuario...";
        public const string Message012 = AddonName + "Error al Registrar Objeto de Usuario...";

        public const string Message013 = AddonName + "Iniciando Carga de Permisos de usuario...";
        public const string Message014 = AddonName + "Finalizado Carga de Permisos de Usuario...";
        public const string Message015 = AddonName + "Error al Cargar permisos de Usuario...";

        public const string Message016 = AddonName + "Iniciando Carga de Scripts de usuario...";
        public const string Message017 = AddonName + "Finalizado Carga de Scripts de Usuario...";
        public const string Message018 = AddonName + "Error al Cargar scripts de Usuario...";

        public const string Message019 = AddonName + "Iniciando Carga de Icono ...";
        public const string Message020 = AddonName + "Finalizado Carga de Icono...";
        public const string Message021 = AddonName + "Error al Cargar icono de Addon...";        


        public const string Message100 = "Seleccione la fecha desde";
        public const string Message101 = "Seleccione la fecha hasta";
        public const string Message102 = "Seleccione Trabajador";
        public const string Message103 = "Seleccione Estado";
        public const string Message104 = "Seleccione Unidad de negocio";
        public const string Message105 = "Seleccione Código de Vendedor";

        public const string Message106 = "Seleccione Estado";
        
        public const string Message107 = "¿Está seguro de Anular los {0} documentos seleccionados?";
        


        public const string Message120 = "Fecha Desde no puede ser inferior a : {0} ";
        public const string Message121 = "Fecha Hasta no puede ser superior a : {0} ";
        public const string Message122 = "Siguiente >";
        public const string Message123 = "Finalizar";


        public const string Message200 = "la serie debe tener  {0} digitos";
        public const string Message201 = "Correlativo Inicial  de tener  {0} digitos";
        public const string Message202 = "Correlativo Final  de tener  {0} digitos";
        public const string Message203 = "Correlativo Siguiente  de tener  {0} digitos";
        public const string Message204 = "El Tipo de documento es requerido";
        public const string Message205 = "La descripción es requerido";
        public const string Message206 = "Se debe ingresar el detalle del documento";
        public const string Message207 = "Se debe ingresar el código de SN";

        public const string Message300 = "Las Entregas marcadas deben tener Estado de Despacho en Sin Programar o Volver a Programar";
        public const string Message301 = "No Marcó ningún registro";
        public const string Message302 = "Error en rango de fechas establecido";

        public const string Message303 = "Seleccione Chofer";
        public const string Message304 = "Seleccione Placa";
        public const string Message305 = "Seleccione Ayudante";
        public const string Message306 = "Seleccione Fecha";
        public const string Message307 = "¿Seguro de hacer la programación de los documentos marcados?";
        public const string Message308 = "Asignación de Chofer Culminada";
        public const string Message309 = "¿Seguro de cambiar el estado de despacho a Entregado para los documentos marcados?";
        public const string Message310 = "Proceso Culminado";
        public const string Message311 = "¿Seguro de cambiar el estado de despacho a Entregado para los documentos marcados?";
        public const string Message312 = "Debe seleccionar un tipo de Ocurrencia";
        public const string Message313 = "Debe seleccionar un tipo de Estado";
        public const string Message314 = "Debe seleccionar una opción a programar";
        public const string Message315 = "Debe seleccionar data a programar";

        public const string Message316 = "Seleccione un tipo de CONSOLIDADO";
        public const string Message317 = "¿Está Seguro de grabar al {0} a los registros marcados?";


        public const string QueryStatusDelivery = "CALL SP_VIS_GETSTATUSDELIVERY()";
        public const string QueryListSuccess = "CALL SP_VIS_DIS_LIST_OCURRENCIAS()";
        public const string QueryConsolited = "CALL SP_VIS_DIS_GETSTATE()";
        public const string QueryDays = "CALL SP_VIS_DIS_GETDAYS()";
    }// fin de la clase


}// fin del namespace
