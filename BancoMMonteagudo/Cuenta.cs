using System;
using System.Collections.Generic;
using System.Text;

namespace BancoMMonteagudo
{

    internal class Cuenta
    {
        public int id;
        public string titular;
        public string password;
        public double saldo;

        public virtual double costeTransferencia { get; set; } = 0;
        public virtual double limiteDeuda { get; set; } = 0;
        public virtual int retirosMensuales { get; set; } = 0;

        public virtual double interesesAnuales { get; set; } = 0;

        public Cuenta(int id, string titular, string password, double saldo)
        {
            this.id = id;
            this.titular = titular;
            this.password = password;
            this.saldo = saldo;
        }

    }

}
