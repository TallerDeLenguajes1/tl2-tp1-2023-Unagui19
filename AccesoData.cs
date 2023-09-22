using EspacioEntidades;
namespace EspacioAccesoData
{
    public abstract class AccesoDato
    {
        public abstract List<Cadete> LeerCadetes();
        public abstract List<Cadeteria> LeerCadeterias();
    }

}


// public string GenerarInforme()
// {
//     string cuerpo = "";

//     cuerpo = cadete.Nombre + "; " + cadete.jornalACobrar() + "; " + cadete.ListadoPedidos.Count();

//     return cuerpo;
// }



