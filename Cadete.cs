using EspacioEntidades;

namespace EspacioEntidades
{
    class Cadete
    {
        private int id;
        private string? nombre;
        private string direccion;
        private int telefono;
        private List<Pedido> listadoPedidos;

        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        private List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public double jornalACobrar()
        {

            return 0;
        }
        public void MostrarDatos()
        {
            return ;
        }
        public void EliminarPedido(Pedido pedido, int numero)
        {
            listadoPedidos.Contains(pedido);
        }
        
        public void AgregarPedido(Pedido pedido)
        {
            if (listadoPedidos!=null)
            {
                numerumer
            }
            listadoPedidos.Add(pedido);
        }
    }

    
}