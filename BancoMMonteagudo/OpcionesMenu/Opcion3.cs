using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace BancoMMonteagudo
{
    internal class Opcion3 : IOpcionMenu
    {
        public string ObtenerTexto() => "3. Salir";
        public void Ejecutar() => Console.WriteLine("Has salido");
    }
}