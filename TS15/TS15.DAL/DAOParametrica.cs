using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.Common.RawObjects;

namespace TS15.DAL
{
    public class DAOParametrica
    {
        public static List<gen_parametrica> ConsultarParametros(string tipo, dbTS15Entities contexto, RawError error)
        {
            try
            {
                return contexto.gen_parametrica.Where(p => p.tipo == tipo).OrderBy(p => p.tipo).ToList();
            }

            catch (Exception ex)
            {
                error.Message = "Ocurrio un error en : DAOParametrica.ConsultarParametros" + ex.Message;
                error.Error = true;
                return null;
            }
        }

        public static List<gen_parametrica> ConsultarParametrosSuministro(string tipo, dbTS15Entities contexto, RawError error)
        {
            try
            {
                return contexto.gen_parametrica.Where(p => p.tipo == tipo && (p.consecutivo == 1 || p.consecutivo == 2)).OrderBy(p => p.tipo).ToList();
            }

            catch (Exception ex)
            {
                error.Message = "Ocurrio un error en : DAOParametrica.ConsultarParametrosSuministro" + ex.Message;
                error.Error = true;
                return null;
            }
        }

        public static List<gen_parametrica> ConsultarTipoSolictudSS(string tipo, dbTS15Entities contexto, RawError error)
        {
            try
            {
                return contexto.gen_parametrica.Where(p => p.tipo == tipo && (p.consecutivo == 1 || p.consecutivo == 2)).OrderBy(p => p.tipo).ToList();
            }

            catch (Exception ex)
            {
                error.Message = "Ocurrio un error en : DAOParametrica.ConsultarTipoSolictudSS" + ex.Message;
                error.Error = true;
                return null;
            }
        }
    }
}
