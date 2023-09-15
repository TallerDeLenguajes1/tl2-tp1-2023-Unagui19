using EspacioEntidades;
using EspacioAccesoData;

accesoData data = new accesoData();
List<Cadeteria> cadeteria = data.LeerCadeterias();


Console.WriteLine("\t-----Cadeteria-----");
Console.WriteLine("\n1)Alta de pedido");
Console.WriteLine("\n2)Asignar pedido a cadete");
Console.WriteLine("\n3)Cambiar estado de pedido");
Console.WriteLine("\n4)Reasignar pedido");

int opcion;
string x=Console.ReadLine();
bool ingreso = int.TryParse(x,out opcion);

while(!ingreso || opcion<=0 || opcion>4)
{
    Console.WriteLine("\nIngreso una valor invalido. Vuelva a intentarlo:");
    x=Console.ReadLine();
}

if (opcion==1)
{
    Console.WriteLine("\tPedido:");
    Console.WriteLine("\n Nombre del cliente: ");
    string nombreCliente=Console.ReadLine();
    Console.WriteLine("\nDireccion: ");
    string direccionCliente=Console.ReadLine();
    Console.WriteLine("\nTelefono: ");
    string telCliente=Console.ReadLine();
    Console.WriteLine("\nDatos de referencia: ");
    string datosRefCliente=Console.ReadLine();
    Console.WriteLine("\nAlguna observacion?: ");
    string obsPedido=Console.ReadLine();
}
else if(opcion==2)
{
    Console.WriteLine("Id de cadete a asignarle el pedido: ");
    int id;
    string y=Console.ReadLine();
    bool ingresoId = int.TryParse(y,out id);
    if (ingresoId)
    {
        foreach (var item in cadeteria)
        {
            if (item.BuscarporCadetePorId(id)!=null)
            {
                item.AsignarPedido();
            }
        }
    }
    Console.WriteLine(" ");
    Console.WriteLine("\nDireccion: ");
    string direccionCliente=Console.ReadLine();
}
else if(opcion==3)
{

}
else
{

}