Aplicación BANCO 
Desarrolla una aplicación de consola para un banco que gestione diferentes tipos de cuentas bancarias. La aplicación debe permitir crear, gestionar y realizar operaciones en las cuentas. Los tipos de cuentas que debes implementar son: 
Cuenta Corriente: Permite depósitos, retiros y tiene un límite de deuda. Permite retiros hasta el saldo disponible más el límite de deuda, determinado por el programa para todas las cuentas. Si se intenta retirar más allá del límite de deuda, se muestra un mensaje de fondos insuficientes. Trasferencia entre cuentas cuesta 3% 
Cuenta de Ahorros: Permite depósitos, retiros y genera intereses anuales. Permite un máximo de 3 retiros mensuales. Si se intenta retirar más de 3 veces en un mes, se muestra un mensaje indicando que se ha alcanzado el límite de retiros mensuales. Genera un interés del 3% anualmente (crea una función para ser llamada una vez al año), Trasferencia entre cuentas cuesta 2% 
El número de las cuentas debe ser un numero entero que se autoincremente en 1 cada vez que agregas una cuenta nueva al banco. 
El programa debe mostrar el siguiente menú y poder realizar todas estas gestiones: 
Bienvenido al Banco XYZ 
Seleccione una opción: 
Crear Cuenta (dar a escoger el tipo) 
Realizar Depósito 
Realizar Retiro		 
Mostrar Saldo 
Trasferir dinero a otra cuenta 
Salir 
Nota: todo se guarda en memoria al cerrar la aplicación hay que volver a crearlo 
