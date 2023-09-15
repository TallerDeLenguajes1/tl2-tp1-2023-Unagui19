using EspacioEntidades;
using EspacioAccesoData;
using System.Data.Common;

accesoData data = new accesoData();
List<Cadeteria> cadeterias = data.LeerCadeterias();
List<Cadete> cadetes = data.LeerCadetes();
int repetir = 1;

Console.WriteLine("\t-----Cadeteria-----");
Console.WriteLine("Elegir cadeteria:\n");
for (int i = 0; i < cadeterias.Count(); i++)
{
    Console.WriteLine($"{i + 1})" + cadeterias[i].Nombre);
}
int opcionCadeteria;
string z = Console.ReadLine();
bool ingreso1 = int.TryParse(z, out opcionCadeteria);

while (opcionCadeteria > cadeterias.Count() || !ingreso1 || opcionCadeteria <= 0)
{
    Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
    z = Console.ReadLine();
}

while (repetir == 1)
{
    Console.WriteLine("\t-----Cadeteria " + cadeterias[opcionCadeteria].Nombre + "-----");
    Console.WriteLine("\n1)Alta de pedido");
    Console.WriteLine("\n2)Cambiar estado de pedido");
    Console.WriteLine("\n3)Reasignar pedido");

    cadeterias[opcionCadeteria].ListadoCadetes = cadetes;

    int opcion;
    string x = Console.ReadLine();
    bool ingreso2 = int.TryParse(x, out opcion);

    while (!ingreso2 || opcion <= 0 || opcion > 3)
    {
        Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
        x = Console.ReadLine();
    }

    if (opcion == 1)
    {
        Console.WriteLine("\tPedido:");
        Console.WriteLine("\n Nombre del cliente: ");
        string nombreCliente = Console.ReadLine();
        Console.WriteLine("\nDireccion: ");
        string direccionCliente = Console.ReadLine();
        Console.WriteLine("\nTelefono: ");
        string telCliente = Console.ReadLine();
        Console.WriteLine("\nDatos de referencia: ");
        string datosRefCliente = Console.ReadLine();
        Console.WriteLine("\nAlguna observacion?: ");
        string obsPedido = Console.ReadLine();

        Console.WriteLine("Id de cadete a asignarle el pedido: ");
        int id;
        string y = Console.ReadLine();
        bool ingresoId5 = int.TryParse(y, out id);
        if (ingresoId5)
        {
            foreach (var item in cadeterias)
            {
                if (item.BuscarporCadetePorId(id) != null)
                {
                    item.AsignarPedido(id, cadeterias[opcionCadeteria].crearPedido(nombreCliente, direccionCliente, int.Parse(telCliente), datosRefCliente, obsPedido));
                }
            }
        }

    }
    else if (opcion == 2)
    {
        Console.WriteLine("\nIngrese numero de pedido: ");
        int numeroPedido;
        string j = Console.ReadLine();
        bool ingreso3 = int.TryParse(j, out numeroPedido);
        while (!ingreso3)
        {
            Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
            j = Console.ReadLine();
        }

        foreach (var item in cadeterias[opcionCadeteria].ListadoCadetes)
        {
            foreach (var item2 in item.ListadoPedidos)
            {
                if (item2.Nro == numeroPedido)
                {
                    Console.WriteLine("\nEstado actual del Pedido: " + item2.Estado);
                    Console.WriteLine("\n Desea cambiar el estado del pedido?:(1-si, 2-no)");
                    int confirmacion;
                    string k = Console.ReadLine();
                    bool ingreso4 = int.TryParse(k, out confirmacion);
                    if (confirmacion == 1)
                    {
                        cadeterias[opcionCadeteria].CambiarEstado(numeroPedido, confirmacion);
                    }
                    else
                    {
                        cadeterias[opcionCadeteria].CambiarEstado(numeroPedido, confirmacion);
                    }

                }
            }
        }
    }
    else
    {
        Console.WriteLine("\tReasignar pedido:");
        Console.WriteLine("\nId de cadete a asignarle el pedido: ");
        int idAsignando, idQuitar;
        string p = Console.ReadLine();
        bool ingresoId = int.TryParse(p, out idAsignando);
        Console.WriteLine("\nId de cadete a quitarle el pedido: ");
        string q = Console.ReadLine();
        bool ingresoId2 = int.TryParse(p, out idQuitar);
        Console.WriteLine("\nIngrese numero de pedido: ");
        int numeroPedido2;
        string xy = Console.ReadLine();
        bool ingreso5 = int.TryParse(xy, out numeroPedido2);

        if (ingresoId2 && ingresoId)
        {
            cadeterias[opcionCadeteria].ReasignarCadete(idAsignando, idQuitar, numeroPedido2);
        }
    }
    Console.WriteLine("Desea continuar? (1-Si, 2-No)");
    string continuar = Console.ReadLine();
    bool ingresado = int.TryParse(continuar, out repetir);
    while (!ingresado && repetir < 1 && repetir < 2)
    {
        Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
        continuar = Console.ReadLine();
    }
    data.GenerarInforme(cadeterias[opcionCadeteria]);
}






