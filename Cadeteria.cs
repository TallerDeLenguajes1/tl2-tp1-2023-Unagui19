using System.ComponentModel;
using EspacioEntidades;
using System.Linq;

namespace EspacioEntidades
{
    public class Cadeteria
    {
        private string nombre;
        private string telefono;
        private List<Cadete> listadoCadetes;
        private List<Pedido> listadoPedidos;


        public Cadeteria(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.ListadoCadetes = new List<Cadete>();
            this.ListadoPedidos = new List<Pedido>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
        public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

        public Pedido crearPedido(string nombre, string direc, double telefono, string referencias, string obs)
        {
            Pedido nuevoPedido = new Pedido(nombre, direc, telefono, referencias, obs);
            ListadoPedidos.Add(nuevoPedido);
            return nuevoPedido;
        }

        public void AsignarCadeteAPedido(int id, int numeroPedido) //asigna un cadete a un pedido ( tp3)
        {
            // Cadete cadete = this.listadoCadetes.First(cadete => cadete.Id == id);
            Cadete cadete = BuscarporCadetePorId(id);
            Pedido pedido = BuscarporPedidoPorNumero(numeroPedido);

            CambiarEstado(pedido.Nro, 1);//1 acepta pedido
            pedido.(pedido);
        }
        public void ReasignarCadete(int idCadete1, int idCadete2, int numeroPedido)
        {
            // Pedido pedido= .FirstOrDefault(pedido => cadete.Id == idCadete2);
            Pedido aux;
            foreach (var item in listadoCadetes)
            {
                if (item.Id == idCadete1)
                {
                    Pedido pedido = item.ListadoPedidos.FirstOrDefault(pedido => pedido.Nro == numeroPedido, null);
                    item.EliminarPedido(numeroPedido);
                    AsignarPedido(idCadete2, pedido);
                    break;
                }

            }


        }
        public void CambiarEstado(int numeroPedido, int estado)
        {
                foreach (var item in ListadoPedidos)
                {
                    if (item.Nro == numeroPedido)
                    {
                        if (estado == 1)
                        {
                            item.AceptarPedido();
                        }
                        else
                        {
                            item.CancelarPedido();
                        }
                    }
                }
        }
        public Cadete BuscarporCadetePorId(int id)
        {
            Cadete cadete = this.listadoCadetes.FirstOrDefault(cadete => cadete.Id == id);
            return cadete;
        }
        public Pedido BuscarporPedidoPorNumero(int nPedido)
        {
            Pedido pedido = this.listadoPedidos.FirstOrDefault(pedido => pedido.Nro == nPedido);
            return pedido;
        }

        public double jornalACobrar(int idCadete)
        {
            int contador = 0;
            // Cadete cadete = BuscarporCadetePorId(idCadete); 
            foreach (var pedido in listadoPedidos)
            {
                if (pedido.Cadete.Id==idCadete)
                {
                    contador++;
                }
            }
            return 500 * contador;
        }

    }
}