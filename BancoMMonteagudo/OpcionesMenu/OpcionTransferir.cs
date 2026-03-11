using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{
    internal class OpcionTransferir : IOpcionMenu
    {
        public string ObtenerTexto() => "4. Transferir a otra cuenta";
        public void Ejecutar() => Program.transferir(Program.cuentaSesionActiva);
    }
}
