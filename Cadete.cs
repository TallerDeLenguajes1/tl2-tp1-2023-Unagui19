using EspacioEntidades;

namespace EspacioEntidades
{
    public class Cadete
    {
        private int id;
        private string? nombre;
        private string direccion;
        private double telefono;
        private List<Pedido> listadoPedidos;


        public int Id { get => id; set => id = value; }
        public string? Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public double Telefono { get => telefono; set => telefono = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Cadete(int id, string? nombre, string direccion, double telefono)
        {
            this.id = id;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.listadoPedidos = new List<Pedido>();
        }


        public double jornalACobrar()
        {
            int contador = 0;
            foreach (var item in listadoPedidos)
            {
                if (item.Estado == Estado.aceptado)
                {
                    contador++;
                }
            }
            return 500 * contador;
        }

        public void EliminarPedido(int numero)
        {
            Pedido pedido = listadoPedidos.FirstOrDefault(pedido => pedido.Nro == numero, null);
            if (pedido != null)
            {
                listadoPedidos.Remove(pedido);
            }

        }

        public void AgregarPedido(Pedido pedido)
        {
            listadoPedidos.Add(pedido);
        }
    }


}