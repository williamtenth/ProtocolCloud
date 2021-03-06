///////////////////////////////////////////////////////////
//  pro_elementoprueba.cs
//  Implementation of the Class pro_elementoprueba
//  Generated by Enterprise Architect
//  Created on:      01-may.-2015 22:34:39 p. m.
//  Original author: william_cuadros
///////////////////////////////////////////////////////////

using System;
using TS15.Common.IService;
using System.Data.Objects.DataClasses;
using TS15.Common.util;
namespace TS15.Common.Generated
{
    public class pro_elementoprueba
    {

        private string _nombre;
        private DateTime _fecha;
        private string _resultado;
        private String _estado;
        private EntityObject _prueba;

        public pro_elementoprueba()
        {

        }

        ~pro_elementoprueba()
        {

        }

        /// 
        /// <param name="nombre"></param>
        /// <param name="fecha"></param>
        /// <param name="Resultado"></param>
        public pro_elementoprueba(string nombre, EntityObject prueba)
        {
            _nombre = nombre;
            _prueba = prueba;
        }

        public pro_elementoprueba(string nombre, DateTime? fecha, byte? resultado, EntityObject prueba)
            : this(nombre, prueba)
        {
            if (fecha != null)
                _fecha = (DateTime)fecha;
            _resultado = UtilParametros.ValidarResultado(resultado);
        }

        public pro_elementoprueba(string nombre, DateTime? fecha, byte? resultado, byte? estado, EntityObject prueba)
            : this(nombre, fecha, resultado, prueba)
        {
            _estado = UtilParametros.ValidarEstado(estado);
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public DateTime Fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }

        public string Resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }

        public EntityObject Prueba
        {
            get { return _prueba; }
            set { _prueba = value; }
        }

        public String Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }


    }//end pro_elementoprueba

}//end namespace Generated