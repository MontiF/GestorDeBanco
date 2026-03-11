using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{
    internal class OpcionSalirCuenta : IOpcionMenu
    {
        public string ObtenerTexto() => "5. Salir";
        public void Ejecutar() => Console.WriteLine("Cerrando sesión...");
    }
}
