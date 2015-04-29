using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TS15V2.UI.APP.util
{
    /// <summary>
    /// Clase estatica que contiene la variables globales para el aplicativo.
    /// </summary>
    public static class VariablesGlobales
    {
        // Variables de sesion
        public const String SESSION_TRANSFORMADOR = "SESSION_TRANSFORMADOR";
        public const String SESION_CLIENTE = "SESION_CLIENTE";
        public const String SESION_PROCESO_PRUEBA = "SESION_PROCESO_PRUEBA";
        public const String SESION_PRUEBA_NTC3396 = "SESION_PRUEBA_NTC3396";
        public const String SESION_PRUEBA_NTC1465 = "SESION_PRUEBA_NTC1465";
        public const String SESION_PRUEBA_NTC375 = "SESION_PRUEBA_NTC375";
        public const String SESION_PRUEBA_NTC1031 = "SESION_PRUEBA_NTC1031";
        public const String SESION_PRUEBA_NTC1005 = "SESION_PRUEBA_NTC1005";
        // Gestión Protocolo
        public const byte RESULTADO_PRUEBAS_EXITOSA = 1;
        public const byte RESULTADO_PRUEBAS_NO_EXITOSA = 2;
        // Variables generales
        public const byte ESTADO_ACTIVO = 1;
        public const byte ESTADO_TERMINADO = 2;


    }//end VariableGlobales

}//end namespace util