///////////////////////////////////////////////////////////
//  UtilParametros.cs
//  Implementation of the Class UtilParametros
//  Generated by Enterprise Architect
//  Created on:      03-may.-2015 21:55:52 p. m.
//  Original author: william_cuadros
///////////////////////////////////////////////////////////




namespace TS15.Common.util {
	public static class UtilParametros {

		/// 
		/// <param name="consecutivoParametro"></param>
        public static string ValidarResultado(byte? consecutivoParametro)
        {
            // Validación del valor a colocar en el campo resultado.
            return consecutivoParametro != null ?
                (consecutivoParametro == VariablesGlobales.RESULTADO_PRUEBAS_EXITOSA ? VariablesGlobales.RESULTADO_PRUEBAS_EXITOSA_LABEL : VariablesGlobales.RESULTADO_PRUEBAS_NO_EXITOSA_LABEL)
                : VariablesGlobales.RESULTADO_SIN_RESULTADO_LABEL;
		}

        public static string ValidarEstado(byte? consecutivoParametro)
        {
            // Validación del valor estado: ACTIVO o TERMINADO.
            return consecutivoParametro != null ?
                (consecutivoParametro.Equals(VariablesGlobales.ESTADO_ACTIVO) ? VariablesGlobales.ESTADO_ACTIVO_LABEL : VariablesGlobales.ESTADO_TERMINADO_LABEL)
                : VariablesGlobales.ESTADO_SIN_ESTADO_LABEL;
        }
                
    }//end UtilParametros

}//end namespace util