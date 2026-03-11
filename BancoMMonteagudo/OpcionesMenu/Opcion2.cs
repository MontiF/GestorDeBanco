using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace BancoMMonteagudo
{
    internal class Opcion2 : IOpcionMenu
    {
        public string ObtenerTexto() => "2. Registrarse";
        public void Ejecutar() => Program.registro();
    }
}