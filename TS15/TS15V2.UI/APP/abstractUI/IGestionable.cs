///////////////////////////////////////////////////////////
//  IGestionable.cs
//  Implementation of the Interface IGestionable
//  Generated by Enterprise Architect
//  Created on:      14-abr.-2015 10:08:07 a. m.
//  Original author: asuspc
///////////////////////////////////////////////////////////





using System;
namespace TS15V2.UI.APP.abstractUI
{
	public interface IGestionable  {

        void Crear(object sender, EventArgs e);

        void Eliminar(object sender, EventArgs e);

        void Modificar(object sender, EventArgs e);

        void Guardar(object sender, EventArgs e);

        void Cancelar(object sender, EventArgs e);
	}//end IGestionable

}//end namespace abstracUI