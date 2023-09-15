using EspacioEntidades;
using System.Linq;

enum Estado
{
    pendiente,
    aceptado,
    cancelado
}

namespace EspacioEntidades
{
    public class Pedido
    {
        private int nro;
        private string obs;
        private Cliente cliente;
        private Estado estado;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        private Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado Estado { get => estado; set => estado = value; }

        public Pedido(int nro, string obs, string nombre, string direccion, long telefono, string datosReferenciaDireccion)
        {
            this.Nro = nro;
            this.Obs = obs;
            this.estado = Estado.pendiente;
            cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);//esto es porque es composicion
        }

        //metodos

        public string verDatosCliente()
        {
            return cliente.Nombre + "-" + cliente.Telefono
             + "-" + Cliente.Direccion + "-" + Cliente.DatosReferenciaDireccion; ;
        }


        public string verDireccionCliente()
        {
            return cliente.Direccion;
        }

        public void AceptarPedido()
        {
            estado=Estado.aceptado;
        }
        public void CancelarPedido()
        {
            estado=Estado.cancelado;
        }

    }


}