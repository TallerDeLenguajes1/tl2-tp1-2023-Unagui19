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
                cadeterias.Add(new Cadeteria(fields[0],fields[1]));

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
                cadetes.Add(new Cadete(int.Parse(fields[0]),fields[1],fields[2],int.Parse(fields[3])));
            }
            csv.Close();
            return cadetes;
        }
    }


        public string GenerarInforme() 
        {
            string intro = $"Cadeteria: {this.Nombre} | Teléfono: {this.}";
            string cuerpo = "";
            foreach (var cad in this.Cadetes)
            {
                cuerpo = cuerpo + cad.InformeCadete();
            }
            return intro + cuerpo;
        }

}
