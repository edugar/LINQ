using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace linq
{
    internal class clsQueries
    {
        private List<Game> juegosPS = new List<Game>();
        private List<Game> juegosXBOX = new List<Game>();

        public clsQueries() 
        {
            string relativePath = "json/videojuegosPS.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                this.juegosPS = JsonSerializer.Deserialize<List<Game>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            }

            using(StreamReader reader = new StreamReader("json/videojuegosXBOX.json"))
            {
                string json = reader.ReadToEnd();
                this.juegosXBOX = JsonSerializer.Deserialize<List<Game>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public IEnumerable<Game> JuegosPS()
        {
            return juegosPS;
        }
        public IEnumerable<Game> JuegosXbox()
        {
            return juegosXBOX;
        }

        //WHERE
        public IEnumerable<Game> linqWHERE(string Condicion)
        {
            IEnumerable<Game> result;
            //Method syntax
            result =  juegosPS.Where(p=> p.Titulo == Condicion);

            //Query syntax
            //result = from p in juegosPS where p.Titulo == Condicion select p;

            return result;
        }

        //CONTAINS
        public IEnumerable<Game> linqContains(string Condicion)
        {
            IEnumerable<Game> result;
            //Method syntax
            result = juegosXBOX.Where(p => p.Plataforma.Contains(Condicion));

            //Query syntax
            //result = from p in juegosXBOX where p.Plataforma.Contains(Condicion) select p;

            return result;
        }

        //ALL
        public bool linqAll(string Condicion)
        {
            bool result;
            //Method syntax
            result = juegosXBOX.All(p => p.Plataforma.Contains(Condicion));

            //Query syntax
            //result = (from p in juegosXBOX select p).All(p => p.Plataforma.Contains(Condicion));

            return result;
        }

        //ANY
        public bool linqAny(string Condicion){
            bool result;
            //Method syntax
            result = juegosXBOX.Any(p => p.Fecha_lanzamiento.Year == Convert.ToInt32(Condicion));

            //Query syntax
            //result = (from p in juegosXBOX where p.Fecha_lanzamiento.Year == Convert.ToInt32(Condicion) select p).Any();

            return result;
        }

        //ORDER BY

        //ORDER BY DESCENDING

        //TAKE

        //SKIP

        //SELECT

        //COUNT

        //LONG COUNT

        //MIN

        //MAX

        //MIN BY

        //MAX BY

        //SUM

        //AGERGGATE

        //AVERAGE

        //GROUP BY

        //LOOKUP

        //JOIN

        //LEFT JOIN

        //RIGTH JOIN
















    }
}
