using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Net;

namespace linq
{
    internal class clsQueries
    {
        private List<Game> videojuegos = new List<Game>();
        private List<User> usuarios = new List<User>();

        public clsQueries() 
        {
            string relativePath = "json/videojuegos.json";
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                this.videojuegos = JsonSerializer.Deserialize<List<Game>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            }

            using(StreamReader reader = new StreamReader("json/usuarios.json"))
            {
                string json = reader.ReadToEnd();
                this.usuarios = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        public IEnumerable<Game> VideoJuegos()
        {
            return videojuegos;
        }
        public IEnumerable<User> Usuarios()
        {
            return usuarios;
        }

        //WHERE
        public IEnumerable<Game> linqWHERE(string Condicion)
        {
            IEnumerable<Game> result;
            //Method syntax
            result = videojuegos.Where(p=> p.Titulo == Condicion);

            //Query syntax
            result = from p in videojuegos where p.Titulo == Condicion select p;

            return result;
        }

        //CONTAINS
        public IEnumerable<Game> linqContains(string Condicion)
        {
            IEnumerable<Game> result;
            //Method syntax
            result = videojuegos.Where(p => p.Titulo.Contains(Condicion));

            //Query syntax
            result = from p in videojuegos where p.Titulo.Contains(Condicion) select p;

            return result;
        }

        //ALL
        public bool linqAll(string Condicion)
        {
            bool result;
            //Method syntax
            result = videojuegos.All(p => p.Plataforma.Contains(Condicion));

            //Query syntax
            result = (from p in videojuegos select p).All(p => p.Plataforma.Contains(Condicion));

            return result;
        }

        //ANY
        public bool linqAny(string Condicion){
            bool result;
            //Method syntax
            result = videojuegos.Any(p => p.Fecha_lanzamiento.Year == Convert.ToInt32(Condicion));

            //Query syntax
            result = (from p in videojuegos where p.Fecha_lanzamiento.Year == Convert.ToInt32(Condicion) select p).Any();

            return result;
        }

        //ORDER BY
        public IEnumerable<Game> linqOrderBy()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = videojuegos.OrderBy(p => p.Titulo);

            //Query syntax
            result = from p in videojuegos orderby p.Titulo select p;

            return result;
        }

        //ORDER BY DESCENDING
        public IEnumerable<Game> linqOrderByDescending()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = videojuegos.OrderByDescending(p => p.Titulo);

            //Query syntax
            result = from p in videojuegos orderby p.Titulo descending select p;

            return result;
        }

        //TAKE
        public IEnumerable<Game> linqTake()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = videojuegos.Take(3).ToList();

            //Query syntax
            result = (from p in videojuegos orderby p.Titulo select p).Take(3);

            return result;
        }

        //SKIP
        public IEnumerable<Game> linqSkip()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = videojuegos.OrderBy(p => p.Titulo).Skip(5);

            //Query syntax
            result = (from p in videojuegos orderby p.Titulo select p).Skip(5);

            return result;
        }

        //SELECT
        public IEnumerable<Game> linqSelect()
        {
            IEnumerable<Game> result;
            //Method syntax
            result = videojuegos.Select(p => new Game { Titulo = p.Titulo, Plataforma = p.Plataforma, Desarrollador = "Method Syntax" });

            //Query syntax
            result = from p in videojuegos select new Game { Titulo = p.Titulo, Plataforma = p.Plataforma, Desarrollador  = "Query Syntax" };

            return result;
        }

        //COUNT
        public int linqCount()
        {
            int result;
            //Method syntax
            result = videojuegos.Count();

            //Query syntax
            result = (from p in videojuegos select p).Count();

            return result;
        }

        //LONG COUNT
        public long linqLongCount()
        {
            long result;
            //Method syntax
            result = videojuegos.LongCount();

            //Query syntax
            result = (from p in videojuegos select p).LongCount();

            return result;
        }

        //MIN
        public decimal linqMin()
        {
            decimal result;
            //Method syntax
            result = videojuegos.Min(p => p.Calificacion);

            //Query syntax
            result = (from p in videojuegos select p.Calificacion).Min();

            return result;
        }

        //MIN BY
        public User linqMinBy()
        {
            User result;
            //Method syntax
            result = usuarios.MinBy(p => p.Edad);

            //Query syntax
            result = (from p in usuarios select p).MinBy(q => q.Edad);

            return result;
        }

        //MAX
        public decimal linqMax()
        {
            decimal result;
            //Method syntax
            result = videojuegos.Max(p => p.Calificacion);

            //Query syntax
            result = (from p in videojuegos select p.Calificacion).Max();

            return result;
        }
        //MAX BY
        public User linqMaxBy()
        {
            User result;
            //Method syntax
            result = usuarios.MaxBy(p => p.Edad);

            //Query syntax
            result = (from p in usuarios select p).MaxBy(q => q.Edad);

            return result;
        }

        //SUM
        public int linqSum(String Condicion)
        {
            var totalHoras = 0;
            //Method syntax
            totalHoras = usuarios.Where(p => p.Juegos_Favoritos.Contains(Condicion)).Sum(q => q.Horas_Jugadas_Semana);

            //Query syntax
            totalHoras = (from p in usuarios where p.Juegos_Favoritos.Contains(Condicion) select p).Sum(q => q.Horas_Jugadas_Semana);

            return totalHoras;
        }

        //AGERGGATE
        public string linqAggregate(string Condicion)
        {
            var juegos = string.Empty;
            //Method syntax
            juegos = videojuegos
            .Where(p => p.Plataforma.Contains(Condicion))
            .Aggregate("\n", (titulosLibros, next) =>
            {
                if (titulosLibros != string.Empty)
                {
                    titulosLibros += " \n " + next.Titulo;
                }
                else
                {
                    titulosLibros += next.Titulo;
                }
                return titulosLibros;
            });

            //Query syntax
            juegos = (from p in videojuegos where p.Plataforma.Contains(Condicion) select p)
            .Aggregate("\n", (titulosLibros, next) =>
            {
                if (titulosLibros != string.Empty)
                {
                    titulosLibros += " \n " + next.Titulo;
                }
                else
                {
                    titulosLibros += next.Titulo;
                }
                return titulosLibros;
            });

            return juegos;
        }

        //AVERAGE
        public double linqAverage()
        {
            double Media = 0;
            //Method syntax
            Media = usuarios.Average(p => p.Edad);

            //Query syntax
            Media = (from p in usuarios select p).Average(p => p.Edad);

            return Media;
        }

        //GROUP BY
        public IEnumerable<IGrouping<int, Game>> linqGroupBy()
        {
            IEnumerable<IGrouping<int, Game>> result;
            //query method
            result = videojuegos.GroupBy(p => p.Fecha_lanzamiento.Year);

            //query expresion
            result =  (from p in videojuegos select p).GroupBy(q => q.Fecha_lanzamiento.Year);

            return result;
        }

        //LOOKUP
        public ILookup<char, Game> linqToLookup()
        {
            ILookup<char, Game> result;
            //query method
            result = videojuegos.OrderBy(p => p.Titulo).ToLookup(p => p.Titulo[0], p => p);

            //query expresion
            result =(from p in videojuegos orderby p.Titulo select p).ToLookup(p=> p.Titulo[0], p=> p);

            return result;
        }

        //JOIN
        public IEnumerable<Union> linqInnerJoin(string Condicion)
        {            
            //Method syntax
            var result = videojuegos
                .Where(j => j.Titulo.Contains(Condicion))
                .Join(usuarios, 
                j => j.Titulo,
                u => u.Juegos_Favoritos[0],
                (j, u) => new Union 
                {
                    IdJuego = j.Id,
                    Titulo = j.Titulo,
                    Fecha_lanzamiento = j.Fecha_lanzamiento,
                    Genero = j.Genero,
                    Precio = j.Precio,
                    Calificacion = j.Calificacion,
                    IdUsuario = u.Id,
                    Nombre_Usuario = u.Nombre_Usuario,
                    Horas_Jugadas_Semana = u.Horas_Jugadas_Semana
                });

            //Query syntax
            







            return result;
        }

        //LEFT JOIN

        //RIGTH JOIN
















    }
}
