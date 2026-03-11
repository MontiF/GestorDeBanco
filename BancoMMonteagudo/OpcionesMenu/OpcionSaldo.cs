using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{
    internal class OpcionSaldo : IOpcionMenu
    {
        public string ObtenerTexto() => "3. Mostrar Saldo";
        public void Ejecutar() => Program.mostrarSaldo(Program.cuentaSesionActiva);
    }
}