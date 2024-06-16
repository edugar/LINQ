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
        public IEnumerable<Game> linqOrderBy()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = juegosXBOX.OrderBy(p => p.Titulo);

            //Query syntax
            result = from p in juegosXBOX orderby p.Titulo select p;

            return result;
        }

        //ORDER BY DESCENDING
        public IEnumerable<Game> linqOrderByDescending()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = juegosXBOX.OrderByDescending(p => p.Titulo);

            //Query syntax
            result = from p in juegosXBOX orderby p.Titulo descending select p;

            return result;
        }

        //TAKE
        public IEnumerable<Game> linqTake()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = juegosPS.Take(3).ToList();

            //Query syntax
            result = (from p in juegosPS orderby p.Titulo select p).Take(3);

            return result;
        }

        //SKIP
        public IEnumerable<Game> linqSkip()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = juegosPS.OrderBy(p => p.Titulo).Skip(5);

            //Query syntax
            result = (from p in juegosPS orderby p.Titulo select p).Skip(5);

            return result;
        }

        //SELECT
        public IEnumerable<Game> linqSelect()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = juegosPS.Select(p => new Game { Titulo = p.Titulo, Plataforma = p.Plataforma, Desarrollador = "Method Syntax" });

            //Query syntax
            result = from p in juegosPS select new Game { Titulo = p.Titulo, Plataforma = p.Plataforma, Desarrollador  = "Query Syntax" };

            return result;
        }

        //COUNT
        public int linqCount()
        {
            int result;
            //Method syntax
            result = juegosPS.Count();

            //Query syntax
            result = (from p in juegosPS select p).Count();

            return result;
        }

        //LONG COUNT
        public long linqLongCount()
        {
            long result;
            //Method syntax
            result = juegosPS.LongCount();

            //Query syntax
            result = (from p in juegosPS select p).LongCount();

            return result;
        }

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
