using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.BL.abstractBL;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.DAL.gestion_transformador;
using TS15.Common.Generated;
using TS15.Common.util;

namespace TS15.BL.gestion_transformador
{
    public class BOOrdenTrabajo : BOGenerico, IGestionable
    {
        public BOOrdenTrabajo()
        {
            GenericoDAO = new DAOOrdenTrabajo();
        }

        public EntityObject ConsultarXId(int id)
        {
            return ((DAOOrdenTrabajo)GenericoDAO).ConsultarXId(id);
        }

        public tfr_ordentrabajo ConsultarXPedido(int pedido)
        {
            return ((DAOOrdenTrabajo)GenericoDAO).ConsultarXPedido(pedido);
        }

        public bool Modificar(EntityObject entidad)
        {
            return ((DAOOrdenTrabajo)GenericoDAO).Modificar(entidad);
        }

        public bool CerrarOrdenTrabajoXPedido(int pedido)
        {
            tfr_ordentrabajo orden = ((DAOOrdenTrabajo)GenericoDAO).ConsultarXPedido(pedido);
            orden.estado = VariablesGlobales.ESTADO_TERMINADO;
            return Modificar(orden);
        }

        public bool Eliminar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(EntityObject entidad)
        {
            return ((DAOOrdenTrabajo)GenericoDAO).Crear(entidad);
        }

        public List<EntityObject> Consultar()
        {
            return ((DAOOrdenTrabajo)GenericoDAO).Consultar();
        }

        internal int ObtenerConsecutivo()
        {
            int maximo = 1;

            if (Consultar().Count > 0)
                maximo = ((DAOOrdenTrabajo)GenericoDAO).ObtenerConsecutivo();

            return maximo;
        }
    }
}
