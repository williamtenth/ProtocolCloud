using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.BL.abstractBL;
using TS15.Common.IService;
using TS15.DAL.gestion_transformador;
using System.Data.Objects.DataClasses;
using TS15.DAL.gestion_protocolo;
using TS15.Common.Generated;

namespace TS15.BL.gestion_protocolo
{
    public class BOProceso : BOGenerico, IGestionable, IProbable
    {

        public BOProceso()
        {
            GenericoDAO = new DAOProceso();
        }

        public EntityObject ConsultarXId(int id)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(EntityObject entidad)
        {
            return ((DAOProceso)GenericoDAO).Modificar(entidad);
        }

        public bool Eliminar(EntityObject entidad)
        {
            throw new NotImplementedException();
        }

        public bool Crear(EntityObject entidad)
        {
            return ((DAOProceso)GenericoDAO).Crear(entidad);
        }

        public bool CrearProceso(cli_pedido pedido, byte tipoProceso)
        {
            //CREA PROCESO DE PRUEBAS
            pro_proceso proceso = new pro_proceso();
            proceso.pedido_id = pedido.id;
            proceso.tipprocesop = tipoProceso;
            proceso.fecha = DateTime.Now;
            proceso.estado = 1; //Estado Activo
                                    
            return Crear(proceso);
        }

        public List<EntityObject> Consultar()
        {
            throw new NotImplementedException();
        }

        public pro_proceso ObternerProcesoXPedido(int pedido)
        {
            return ((DAOProceso)GenericoDAO).ObternerProcesoXPedido(pedido);
        }

        public pro_proceso ObternerProcesoActivoXPedido(int pedido)
        {
            return ((DAOProceso)GenericoDAO).ObternerProcesoActivoXPedido(pedido);
        }

        public bool Terminar(EntityObject entidad)
        {
            return ((DAOProceso)GenericoDAO).Terminar(entidad);
        }

        public EntityObject ObtenerUltimaPrueba(tfr_transformador transformador)
        {
            throw new NotImplementedException();
        }

        public pro_elementoprueba ObternerPruebasXProceso(int pedido)
        {
            throw new NotImplementedException();
        }

        
    }
}
