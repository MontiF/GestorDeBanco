using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace BancoMMonteagudo
{
    internal class Opcion1 : IOpcionMenu
    {
        public string ObtenerTexto() => "1. Iniciar sesion";
        public void Ejecutar() => Program.inicioSesion();
    }
}