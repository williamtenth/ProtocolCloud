using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TS15.Common.util
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
        public const String SESION_PROCESO_LISTA_PRUEBAS = "SESION_PROCESO_LISTA_PRUEBA";
        public const String SESION_PRUEBA_NTC3396 = "SESION_PRUEBA_NTC3396";
        public const String SESION_PRUEBA_NTC1465 = "SESION_PRUEBA_NTC1465";
        public const String SESION_PRUEBA_NTC375 = "SESION_PRUEBA_NTC375";
        public const String SESION_PRUEBA_NTC1031 = "SESION_PRUEBA_NTC1031";
        public const String SESION_PRUEBA_NTC1005 = "SESION_PRUEBA_NTC1005";
        public const String SESION_PRUEBA_NTC471 = "SESION_PRUEBA_NTC471";
        public const String SESION_PRUEBA_NTC471_DETALLE = "SESION_PRUEBA_NTC471_DETALLE";
        public const String SESION_PRUEBA_NTC837 = "SESION_PRUEBA_NTC837";
        public const String SESION_CLIENTE_PEDIDO = "SESION_CLIENTE_PEDIDO";

        // Gestión protocolo
        public const byte RESULTADO_PRUEBAS_EXITOSA = 1;
        public const byte RESULTADO_PRUEBAS_NO_EXITOSA = 2;
        public const String RESULTADO_PRUEBAS_EXITOSA_LABEL = "Exitosa";
        public const String RESULTADO_PRUEBAS_NO_EXITOSA_LABEL = "No Exitosa";
        public const String RESULTADO_SIN_RESULTADO_LABEL = "Sin resultado";
        public const byte TIPO_PROCESO_PRELIMINARES = 1;
        public const byte TIPO_PROCESO_PROTOCOLO = 2;
        public const String PRUEBA_NTC3396 = "NTC 3396";
        public const String PRUEBA_NTC1465 = "NTC 1465";
        public const String PRUEBA_NTC375 = "NTC 375";
        public const String PRUEBA_NTC1031 = "NTC 1031";
        public const String PRUEBA_NTC1005 = "NTC 1005";
        public const String PRUEBA_NTC471 = "NTC 471";
        public const String PRUEBA_NTC837 = "NTC 837";
        
        // Variables generales
        public const byte ESTADO_ACTIVO = 1;
        public const byte ESTADO_TERMINADO = 2;

        // Tipos para gen_parametrica
        public const String GEN_PARAMETRICA_RESULTADO = "resultado";
        public const String GEN_PARAMETRICA_ESTADO = "estado";

    }//end VariableGlobales

}//end namespace util