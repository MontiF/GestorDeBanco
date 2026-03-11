using System.ComponentModel.Design;
using System.Globalization;
using System.Reflection;
using System;
using System.IO;

namespace BancoMMonteagudo
{
    internal class Program
    {
        public static Cuenta cuentaSesionActiva;

        static List<Cuenta> cuentas = new List<Cuenta>();

        static List<IOpcionMenu> opcionesMenu = new List<IOpcionMenu> {
            new Opcion1(),
            new Opcion2(),
            new Opcion3()
        };
        static List<IOpcionMenu> opcionesMenu2 = new List<IOpcionMenu>()
        {
            new OpcionDeposito(),
            new OpcionRetiro(),
            new OpcionSaldo(),
            new OpcionTransferir(),
            new OpcionSalirCuenta()
        };

        static void Main(string[] args)
        {
            _ = GestionarInteresesAsync();

            Console.WriteLine("Bienvenido al banco XYZ");

            MenuOpciones("OpcionesMenuInicial", 1);

        }

        public static void registro()
        {
            Console.WriteLine("Registro");
            string nombre = GestionarPeticion("Ingrese el nombre");
            if (string.IsNullOrEmpty(nombre))
            {
                Console.WriteLine("Nombre no valido");
                return;
            }
            string password = GestionarPeticion("Ingrese la contraseña");
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Contraseña no valida");
                return;
            }

            string elegido = GestionarPeticion("Que cuenta desea tener: 1. Ahorro 2. Corriente");
            int.TryParse(elegido, out int cuenta);
            if (cuenta != 1 && cuenta != 2)
            {
                Console.WriteLine("Tipo de cuenta no valido");
            }

            int id = cuentas.Count + 1;
            if (cuenta == 1)
            {
                CuentaAhorro nuevaCuenta = new CuentaAhorro(id, nombre, password, 0);
                cuentas.Add(nuevaCuenta);
            }
            else
            {
                CuentaCorriente nuevaCuenta = new CuentaCorriente(id, nombre, password, 0);
                cuentas.Add(nuevaCuenta);
            }


            Console.WriteLine("Registro exitoso");
            return;
        }

        public static void inicioSesion()
        {
            Console.WriteLine("Iniciar Sesion");
            int intentos = 0;
            int nombreEncontrado = 0;
            Cuenta cuentaIniciada = null;
            while (true)
            {
                string nombre = GestionarPeticion("Ingrese el nombre del titular de la cuenta");
                if (string.IsNullOrEmpty(nombre))
                {
                    Console.WriteLine("Nombre no valido");
                    intentos++;
                    if (intentos >= 3)
                    {
                        Console.WriteLine("Demasiados intentos fallidos");
                        return;
                    }
                    continue;
                }
                for (int i = 0; i < cuentas.Count; i++)
                {
                    if (cuentas[i].titular == nombre)
                    {
                        nombreEncontrado = 1;
                        cuentaIniciada = cuentas[i];
                        break;
                    }
                }
                if (nombreEncontrado == 0)
                {
                    Console.WriteLine("Nombre no encontrado");
                    intentos++;
                    if (intentos >= 3)
                    {
                        Console.WriteLine("Demasiados intentos fallidos");
                        return;
                    }
                    continue;
                }
                string password = GestionarPeticion("Ingrese su contraseña");
                if (string.IsNullOrEmpty(password))
                {
                    Console.WriteLine("Contraseña no valida");
                    intentos++;
                    if (intentos >= 3)
                    {
                        Console.WriteLine("Demasiados intentos fallidos");
                        return;
                    }
                    continue;
                }
                if (cuentaIniciada.password != password)
                {
                    Console.WriteLine("Contraseña incorrecta");
                    intentos++;
                    if (intentos >= 3)
                    {
                        Console.WriteLine("Demasiados intentos fallidos");
                        return;
                    }
                    continue;
                }
                else
                {
                    Console.WriteLine("Inicio de sesion exitoso");
                    break;
                }
            }
            menuInicial(cuentaIniciada);
            return;
        }

        public static void menuInicial(Cuenta cuenta)
        {
            cuentaSesionActiva = cuenta;
            MenuOpciones("OpcionesMenuCuenta", 2);
            cuentaSesionActiva = null;
        }

        public static void realizarDeposito(Cuenta cuenta)
        {
            string cantidadDepositar = GestionarPeticion("Ingrese la cantidad que desea depositar");
            double.TryParse(cantidadDepositar, out double cantidad);
            if (cantidad <= 0)
            {
                Console.WriteLine("Cantidad no valida");
                return;
            }
            cuenta.saldo += cantidad;
            Console.WriteLine("Deposito exitoso");
            return;
        }
        public static void realizarRetiro(Cuenta cuenta)
        {
            if (cuenta.retirosMensuales == 1)
            {
                Console.WriteLine("Has alcanzado el limite de retiros mensuales");
                return;
            }
            string cantidadRetiro = GestionarPeticion("Ingrese la cantidad que desea retirar");
            double.TryParse(cantidadRetiro, out double cantidad);
            if (cantidad <= 0)
            {
                Console.WriteLine("Cantidad no valida");
                return;
            }
            if (cantidad > cuenta.saldo + cuenta.limiteDeuda)
            {
                Console.WriteLine("Saldo insuficiente");
                return;
            }
            cuenta.saldo -= cantidad;
            Console.WriteLine("Retiro exitoso");
            cuenta.retirosMensuales--;
            return;
        }
        public static void mostrarSaldo(Cuenta cuenta)
        {
            Console.WriteLine("Su saldo es: " + cuenta.saldo);
            return;
        }

        public static void transferir(Cuenta cuenta)
        {
            Cuenta cuentaDestino = null;
            Console.WriteLine("Ingrese el id de la cuenta a la que quieres transferir");
            Console.WriteLine("Cuentas disponibles:");
            for (int i = 0; i < cuentas.Count; i++)
            {
                Console.WriteLine("Id: " + cuentas[i].id + " Titular: " + cuentas[i].titular);
            }
            int.TryParse(Console.ReadLine(), out int idDestino);
            if (idDestino < 0 || idDestino == null)
            {
                Console.WriteLine("Id no valido");
            }
            if (idDestino == cuenta.id)
            {
                Console.WriteLine("No puedes transferir a tu propia cuenta");
                return;
            }
            for (int i = 0; i < cuentas.Count; i++)
            {
                if (cuentas[i].id == idDestino)
                {
                    cuentaDestino = cuentas[i];
                    break;
                }
            }
            if (cuentaDestino == null)
            {
                Console.WriteLine("Cuenta destino no encontrada");
                return;
            }
            string cantidadTranferir = GestionarPeticion("Ingrese la cantidad a transferir");
            double.TryParse(cantidadTranferir, out double cantidad);
            if (cantidad <= 0)
            {
                Console.WriteLine("Cantidad no valida");
                return;
            }
            double totalDescontar = cantidad + (cantidad * cuenta.costeTransferencia);
            if (totalDescontar > cuenta.saldo + cuenta.limiteDeuda)
            {
                Console.WriteLine("Saldo insuficiente");
                return;
            }
            cuenta.saldo -= totalDescontar;
            cuentaDestino.saldo += cantidad;
            Console.WriteLine("Transferencia exitosa");
            Console.WriteLine("Se le ha retirado de su cuenta: " + totalDescontar);
        }

        public static async Task GestionarInteresesAsync()
        {
            while (true)
            {
                DateTime targetDate = DateTime.Now.AddYears(1);
                TimeSpan delay = targetDate - DateTime.Now;

                await Task.Delay(60000);
                foreach (var cuenta in cuentas)
                {
                    if (cuenta is CuentaAhorro cuentaAhorro)
                    {
                        cuentaAhorro.AplicarInteresAnual();
                    }
                }

                Console.WriteLine("Se han aplicado los intereses anuales a las cuentas de ahorro");
            }
        }

        public static string GestionarPeticion(string fraseAMostrar)
        {
            Console.WriteLine(fraseAMostrar);
            return Console.ReadLine();
        }

        public static void MenuOpciones(string pathMenu, int numeroMenu)
        {
            int eleccion = 0;
            if (numeroMenu == 1)
            {
                do
                {
                    foreach (var opcion in opcionesMenu)
                    {
                        Console.WriteLine(opcion.ObtenerTexto());
                    }

                    if (int.TryParse(Console.ReadLine(), out eleccion))
                    {
                        if (eleccion >= 1 && eleccion <= opcionesMenu.Count)
                        {
                            opcionesMenu[eleccion - 1].Ejecutar();
                        }
                        else if (eleccion != 3)
                        {
                            Console.WriteLine("Opcion no valida");
                        }
                    }
                } while (eleccion != 3);
            }
            else
            {
                do
                {
                    foreach (var opcion in opcionesMenu2)
                    {
                        Console.WriteLine(opcion.ObtenerTexto());
                    }

                    if (int.TryParse(Console.ReadLine(), out eleccion))
                    {
                        if (eleccion >= 1 && eleccion <= opcionesMenu2.Count)
                        {
                            opcionesMenu2[eleccion - 1].Ejecutar();
                        }
                        else if (eleccion != 5)
                        {
                            Console.WriteLine("Opcion no valida");
                        }
                    }
                } while (eleccion != 5);
            }
        }
    }
}

