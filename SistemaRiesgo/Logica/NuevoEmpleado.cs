using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SistemaRiesgo.Models;

namespace SistemaRiesgo.Logica
{
    public class NuevoEmpleado
    {
        #region "PATRON SINGLETON"
        private static NuevoEmpleado objEmpleado = null;
        private NuevoEmpleado() { }
        public static NuevoEmpleado getInstance(){

            if (objEmpleado == null)
            {

                objEmpleado = new NuevoEmpleado();

            }
            return objEmpleado;
        }

        public bool RegistrarEmpleado(Empleado objEmpleado)
        {
            
            //Falta modificar
            return true;

           

        }

    }
}