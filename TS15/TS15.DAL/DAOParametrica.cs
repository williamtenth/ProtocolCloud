using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.Common.Generated;
using TS15.Common.RawObjects;
using TS15.DAL.abstractDAL;

namespace TS15.DAL
{
    public class DAOParametrica : DAOGenerico
    {
        public List<gen_parametrica> ConsultarParametros(string tipo)
        {
            try
            {
                return SingletonDatos.Contexto.gen_parametrica.Where(p => p.tipo == tipo).OrderBy(p => p.tipo).ToList();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<gen_parametrica> ConsultarTipoSolictudSS(string tipo)
        {
            try
            {
                return SingletonDatos.Contexto.gen_parametrica.Where(p => p.tipo == tipo && (p.consecutivo == 1 || p.consecutivo == 2)).OrderBy(p => p.tipo).ToList();
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public List<gen_parametrica> ConsultarParametrosSuministro(string tipo)
        {
            try
            {
                return SingletonDatos.Contexto.gen_parametrica.Where(p => p.tipo == tipo && (p.consecutivo == 1 || p.consecutivo == 2)).OrderBy(p => p.tipo).ToList();
            }

            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
