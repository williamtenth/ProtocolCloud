﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TS15.DAL.abstractDAL;
using System.Data.Objects.DataClasses;
using TS15.Common.Generated;

namespace TS15.DAL.gestion_cliente
{
    public class DAOPedido : DAOGenerico
    {
        public bool Crear(EntityObject entidad)
        {
            cli_pedido pedidoObject = (cli_pedido)entidad;
            SingletonDatos.Contexto.cli_pedido.AddObject(pedidoObject);
            SingletonDatos.Contexto.SaveChanges();

            return true;
        }

        public List<cli_pedido> Consultar()
        {
            return SingletonDatos.Contexto.cli_pedido.OrderByDescending(p => p.fechasolicitud).ToList();
        }

        public int ObtenerConsecutivo()
        {
            var a = (from p in SingletonDatos.Contexto.cli_pedido
                     select p.consecutivo).Max();

            Int32 consecutivo = Convert.ToInt32(a);

            return consecutivo != null ? consecutivo + 1 : 0;

            //return Convert.ToInt32(a) + 1;
        }

        public EntityObject ConsultarXId(int idSolicitud)
        {
            return SingletonDatos.Contexto.cli_pedido.Where(p => p.id == idSolicitud).FirstOrDefault();
        }

        public void Actualizar(cli_pedido pedidoObject)
        {
            SingletonDatos.Contexto.SaveChanges();
        }

        public List<cli_pedido> ConsultarSolitcitudes(int pIdTransformador, int tipoSolicitud)
        {
            return SingletonDatos.Contexto.cli_pedido.Where(p => p.transformador_id == pIdTransformador && p.tipsolicitud == tipoSolicitud)
                .OrderByDescending(p => p.fechasolicitud).ToList();
        }

        public cli_pedido ConsultarXIdTransformador(int idTransformador)
        {
            return SingletonDatos.Contexto.cli_pedido.Where(p => p.transformador_id == idTransformador).SingleOrDefault();
        }

        public cli_pedido ConsultarXConsecutivo(int consecutivo)
        {
            return SingletonDatos.Contexto.cli_pedido.Where(p => p.consecutivo == consecutivo).FirstOrDefault();
        }
    }
}
