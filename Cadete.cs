using PedidosSpace;

namespace CadeteSpace
{
    class Cadete
    {
        public int id;
        public string? nombre;
        public string direccion;
        public int telefono;
        public List<Pedido> listadoPedidos;
    }
}