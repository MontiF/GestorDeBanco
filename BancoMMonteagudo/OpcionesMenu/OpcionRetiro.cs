using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{
    internal class OpcionRetiro : IOpcionMenu
    {
        public string ObtenerTexto() => "2. Realizar Retiro";
        public void Ejecutar() => Program.realizarRetiro(Program.cuentaSesionActiva);
    }
}
