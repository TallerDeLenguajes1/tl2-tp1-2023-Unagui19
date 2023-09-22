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
    
    Console.WriteLine("\t-----Cadeteria " + cadeterias[opcionCadeteria-1].Nombre + "-----");
    Console.WriteLine("\n1)Alta de pedido");
    Console.WriteLine("\n2)Cambiar estado de pedido");
    Console.WriteLine("\n3)Reasignar pedido");

    cadeterias[opcionCadeteria-1].ListadoCadetes = cadetes;

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
            Pedido pedido = cadeterias[opcionCadeteria-1].crearPedido(nombreCliente, direccionCliente, int.Parse(telCliente), datosRefCliente, obsPedido);
            if (cadeterias[opcionCadeteria-1].BuscarporCadetePorId(id) != null)
            {
                cadeterias[opcionCadeteria-1].AsignarCadeteAPedido(id,pedido.Nro);
            }
            else{
                Console.WriteLine("No existe un cadete con ese id");
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

        foreach (var pedido in cadeterias[opcionCadeteria-1].ListadoPedidos)
        {
            if (pedido.Nro == numeroPedido)
            {
                Console.WriteLine("\nEstado actual del Pedido: " + pedido.Estado);
                Console.WriteLine("\n Desea cambiar el estado del pedido?:(1-si, 2-no)");
                int confirmacion;
                string k = Console.ReadLine();
                bool ingreso4 = int.TryParse(k, out confirmacion);

                if (confirmacion == 1)
                {
                    cadeterias[opcionCadeteria-1].CambiarEstado(numeroPedido, (int)pedido.Estado);
                }
                else
                {
                    Console.WriteLine("No se realizara cambio de estado del pedido");
                }
            }
        }

    }
    else
    {
        Console.WriteLine("\tReasignar pedido:");
        Console.WriteLine("\nId de cadete a asignarle el pedido: ");
        int idAsignando;
        string p = Console.ReadLine();
        bool ingresoId = int.TryParse(p, out idAsignando);
        Console.WriteLine("Pedidos actuales: ");
        foreach (var item in cadeterias[opcionCadeteria].ListadoPedidos)
        {
            Console.WriteLine($"{item.Nro}");       
        }
        Console.WriteLine("");       
        Console.WriteLine("\nIngrese numero de pedido: ");
        int numeroPedidoReasignado;
        string xy = Console.ReadLine();
        bool ingreso5 = int.TryParse(xy, out numeroPedidoReasignado);

        if (ingreso5 && ingresoId)
        {
            cadeterias[opcionCadeteria-1].ReasignarCadete(idAsignando, numeroPedidoReasignado);
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
    data.GenerarInforme(cadeterias[opcionCadeteria-1]);
}






