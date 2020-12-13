using System;

namespace Entidades
{
    //Nombre de la clase
    public class Cliente : Persona
    {
        //Atributos de la clase
        //List<Compra> ListadoCompras;

        //Métodos Constructores
        public Cliente()
        {
            string valor = "Faltante";

            this.Apellido = valor;
            this.Nombre = valor;
            this.Telefono = valor;
            this.CorreoElectronico = valor;
            this.Direccion = valor;
        }

        public Cliente(string Nombre, string Apellido, string Telefono, DateTime FechaNacimiento)
        {
            this.Nombre = Nombre;
            this.Apellido = Apellido;
            this.Telefono = Telefono;
            this.FechaNacimiento = FechaNacimiento;
        }
    }
}
