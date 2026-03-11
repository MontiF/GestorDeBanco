using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{
    internal class CuentaCorriente : Cuenta
    {
        public override double limiteDeuda { get; set; } = 1000;
        public override double costeTransferencia { get; set; } = 0.03;

        public CuentaCorriente(int id, string titular, string password, double saldo) : base(id, titular, password, saldo)
        {

        }
    }

}
