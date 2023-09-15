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
        private static int nro;
        private Cliente cliente;
        private string obs;
        private Estado estado;

        public int Nro { get => nro; set => nro = value; }
        public string Obs { get => obs; set => obs = value; }
        private Cliente Cliente { get => cliente; set => cliente = value; }
        internal Estado Estado { get => estado; set => estado = value; }

        public Pedido( string nombre, string direccion, long telefono, string datosReferenciaDireccion, string obs)
        {
            this.Nro++;
            this.estado = Estado.pendiente;
            cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);//esto es porque es composicion
            this.Obs = obs;
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