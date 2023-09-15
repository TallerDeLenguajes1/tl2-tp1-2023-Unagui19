using EspacioEntidades;
namespace EspacioAccesoData
{
    public class accesoData
    {
        public List<Cadeteria> LeerCadeterias()
        {
            List<Cadeteria> cadeterias = new List<Cadeteria>();
            var csv = new FileStream("Cadeteria.CSV", FileMode.Open);//abrir el archivo
            var sr = new StreamReader(csv);// para leer
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                string[] fields = linea.Split(',');//para leer cada uno de los elementos hasta la ","
                cadeterias.Add(new Cadeteria(fields[0], fields[1]));

            }
            csv.Close();
            return cadeterias;
        }

        public List<Cadete> LeerCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();
            var csv = new FileStream("Cadetes.CSV", FileMode.Open);//abrir el archivo
            var sr = new StreamReader(csv);// para leer
            while (!sr.EndOfStream)
            {
                string linea = sr.ReadLine();
                string[] fields = linea.Split(',');//para leer cada uno de los elementos hasta el ,
                // documento.Add(fields);            // string agregar = string.Join(";","cebolla");
                cadetes.Add(new Cadete(int.Parse(fields[0]), fields[1], fields[2], double.Parse(fields[3])));
            }
            csv.Close();
            return cadetes;
        }
        public void GenerarInforme(Cadeteria cadeteria)//genera un archivo .csv
        {
            FileStream fs = new FileStream("Informe.csv", FileMode.Create);
            using (StreamWriter writer = new StreamWriter(fs))
            {
                int i = 0, cantPedidosTotal = 0;
                double sumador = 0;
                // writer.WriteLine("Indice"+" "+"Nombre"+" "+"Extension");

                writer.WriteLine($"Cadeteria {cadeteria.Nombre} || telefono: {cadeteria.Telefono}\n");
                foreach (var item in cadeteria.ListadoCadetes)
                {
                    writer.WriteLine($"{item.Id}; Nombre: {item.Nombre}; monto:{item.jornalACobrar()}; Cantidad de pedidos: {item.ListadoPedidos.Count()}");
                    i++;
                    sumador += item.jornalACobrar();
                    cantPedidosTotal += item.ListadoPedidos.Count();
                }

                writer.WriteLine("");
                writer.WriteLine("Monto total: " + sumador);

                writer.WriteLine("Promedio de pedidos por cadete: " + (cantPedidosTotal / cadeteria.ListadoCadetes.Count()));
            }
        }
    }
}


// public string GenerarInforme()
// {
//     string cuerpo = "";

//     cuerpo = cadete.Nombre + "; " + cadete.jornalACobrar() + "; " + cadete.ListadoPedidos.Count();

//     return cuerpo;
// }



