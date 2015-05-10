using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;
using TS15.Common.IService;
using TS15.Common.util;

namespace TS15.DAL.gestion_protocolo
{
    public class DAOProceso : DAOGenerico, IGestionable, IProbable
    {
        private IGestionable _DAOPruebasObject;

        public bool Crear(EntityObject entidad)
        {
            pro_proceso procesoObject = entidad as pro_proceso;
            SingletonDatos.Contexto.pro_proceso.AddObject(procesoObject);

            if (SingletonDatos.Contexto.SaveChanges() == 1)
            {
                CrearPruebas(procesoObject.id);
                return true;
            }
            return false;
        }

        private void CrearPruebas(int procesoId)
        {
            pro_proceso proceso = (pro_proceso)ConsultarXId(procesoId);
            int transformadorId = (int)proceso.cli_pedido.transformador_id;
            // ntc1005
            _DAOPruebasObject = new DAOProtocolo_NTC1005();
            pro_ntc1005 ntc1005 = new pro_ntc1005();
            ntc1005.transformador_id = transformadorId;
            ntc1005.proceso_id = proceso.id;
            ((DAOProtocolo_NTC1005)_DAOPruebasObject).Crear(ntc1005);
            // ntc1031
            _DAOPruebasObject = new DAOProtocolo_NTC1031();
            pro_ntc1031 ntc1031 = new pro_ntc1031();
            ntc1031.transformador_id = transformadorId;
            ntc1031.proceso_id = proceso.id;
            ((DAOProtocolo_NTC1031)_DAOPruebasObject).Crear(ntc1031);
            // ntc3396
            _DAOPruebasObject = new DAOProtocolo_NTC3396();
            pro_ntc3396 ntc3396 = new pro_ntc3396();
            ntc3396.transformador_id = transformadorId;
            ntc3396.proceso_id = proceso.id;
            ((DAOProtocolo_NTC3396)_DAOPruebasObject).Crear(ntc3396);
            // ntc375
            _DAOPruebasObject = new DAOProtocolo_NTC375();
            pro_ntc375 ntc375 = new pro_ntc375();
            ntc375.transformador_id = transformadorId;
            ntc375.proceso_id = proceso.id;
            ((DAOProtocolo_NTC375)_DAOPruebasObject).Crear(ntc375);
            // ntc471
            _DAOPruebasObject = new DAOProtocolo_NTC471();
            pro_ntc471 ntc471 = new pro_ntc471();
            ntc471.transformador_id = transformadorId;
            ntc471.proceso_id = proceso.id;
            ((DAOProtocolo_NTC471)_DAOPruebasObject).Crear(ntc471);
            // ntc837
            _DAOPruebasObject = new DAOProtocolo_NTC837();
            pro_ntc837 ntc837 = new pro_ntc837();
            ntc837.transformador_id = transformadorId;
            ntc837.proceso_id = proceso.id;
            ((DAOProtocolo_NTC837)_DAOPruebasObject).Crear(ntc837);
            // ntc1465
            _DAOPruebasObject = new DAOProtocoloNTC1465();
            pro_ntc1465 ntc1465 = new pro_ntc1465();
            ntc1465.transformador_id = transformadorId;
            ntc1465.proceso_id = proceso.id;
            ((DAOProtocoloNTC1465)_DAOPruebasObject).Crear(ntc1465);

        }

        public EntityObject ConsultarXId(int id)
        {
            pro_proceso resultado = SingletonDatos.Contexto.pro_proceso.Where(p => p.id == id).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Modificar(EntityObject entidad)
        {
            pro_proceso _entidad = (pro_proceso)entidad;
            pro_proceso resultado = (pro_proceso)ConsultarXId(_entidad.id);

            if (resultado != null && _entidad != null)
            {
                // Encabezado
                resultado.estado = _entidad.estado;
                resultado.resultado = _entidad.resultado;
                // Persistencia
                SingletonDatos.Contexto.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Eliminar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public pro_proceso ObternerProcesoXPedido(int pedido)
        {
            pro_proceso resultado = SingletonDatos.Contexto.pro_proceso.Where(p => p.pedido_id == pedido).SingleOrDefault();
            return resultado != null ? resultado : null;
        }

        public bool Terminar(EntityObject entidad)
        {
            ((pro_proceso)entidad).estado = VariablesGlobales.ESTADO_TERMINADO;
            return Modificar(entidad);
        }

        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            throw new NotImplementedException();
        }

        public pro_elementoprueba ObternerPruebasXProceso(int pedido)
        {
            throw new NotImplementedException();
        }

        public pro_proceso ObternerProcesoActivoXPedido(int pedido)
        {
            pro_proceso resultado = SingletonDatos.Contexto.pro_proceso.Where(p => p.pedido_id == pedido && p.estado == VariablesGlobales.ESTADO_ACTIVO).SingleOrDefault();
            return resultado != null ? resultado : null;
        }
    }
}
