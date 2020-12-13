using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Persona
    {
        //Atributos de la clase
        public int Id;
        public string Apellido;
        public string Nombre;
        public string Telefono;
        public string CorreoElectronico;
        public string Direccion;
        public DateTime FechaNacimiento;
        public DateTime FechaRegistro;

        public void Hablar()
        {
            //hbla la persona
        }
    }
}
