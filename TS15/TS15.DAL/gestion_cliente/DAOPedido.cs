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
            SingletonDatos.Contexto.AddTocli_pedido(pedidoObject);
            SingletonDatos.Contexto.SaveChanges();

            return true;
        }

        public List<cli_pedido> Consultar()
        {
            return SingletonDatos.Contexto.cli_pedido.ToList();
        }

        public int ObtenerConsecutivo()
        {
            var a = (from p in SingletonDatos.Contexto.cli_pedido
                     select p.consecutivo).Max();

            return Convert.ToInt32(a) + 1;
        }
    }
}
