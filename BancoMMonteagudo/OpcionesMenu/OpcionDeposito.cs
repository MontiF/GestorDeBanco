using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{
    internal class OpcionDeposito : IOpcionMenu
    {
        public string ObtenerTexto() => "1. Realizar Deposito";
        public void Ejecutar() => Program.realizarDeposito(Program.cuentaSesionActiva);
    }
}
