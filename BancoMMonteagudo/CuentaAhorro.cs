using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{
    internal class CuentaAhorro : Cuenta
    {
        public override double interesesAnuales { get; set; } = 0.03;
        public override int retirosMensuales { get; set; } = 4;
        public override double costeTransferencia { get; set; } = 0.02;

        public CuentaAhorro(int id, string titular, string password, double saldo) : base(id, titular, password, saldo)
        {

        }
        public void AplicarInteresAnual()
        {
            this.saldo += this.saldo * this.interesesAnuales;
        }
    }

    
}
