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


        public Cadeteria(string nombre, string telefono)
        {
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.ListadoCadetes = new List<Cadete>();
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }

        public Pedido crearPedido(string nombre, string direc, double telefono, string referencias, string obs)
        {
            Pedido nuevoPedido = new Pedido(nombre, direc, telefono, referencias, obs);
            return nuevoPedido;
        }

        public void AsignarPedido(int id, Pedido pedido) //asigna un pedido a un cadete
        {
            Cadete cadete = this.listadoCadetes.First(cadete => cadete.Id == id);
            CambiarEstado(pedido.Nro, 1);//1 acepta pedido
            cadete.AgregarPedido(pedido);
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
            foreach (var item in listadoCadetes)
            {
                foreach (var item2 in item.ListadoPedidos)
                {
                    if (item2.Nro == numeroPedido)
                    {
                        if (estado == 1)
                        {
                            item2.AceptarPedido();
                        }
                        else
                        {
                            item2.CancelarPedido();
                        }
                    }
                }
            }
        }
        public Cadete BuscarporCadetePorId(int id)
        {
            Cadete cadete = this.listadoCadetes.FirstOrDefault(cadete => cadete.Id == id);
            return cadete;
        }

    }
}