using linq;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
clsQueries consultas = new clsQueries();
menu();
bool final = false;
int seleccion = 0;
string condicion = string.Empty;
while (!final)
{
    seleccion = Convert.ToInt32(Console.ReadLine());
    switch(seleccion)
    {
        case 1:
            Console.WriteLine("SELECT");
            Console.Write("Buscar por juego: ");
            condicion = Console.ReadLine();
            ImprimirLista(consultas.linqWHERE(condicion));
            Console.ReadLine();
            menu();
            break;
        case 2:
            Console.WriteLine("CONTAINS");
            Console.Write("El titulo del juego contiene: ");
            condicion = Console.ReadLine();
            ImprimirLista(consultas.linqContains(condicion));
            Console.ReadLine();
            menu();
            break;
        case 3:
            Console.WriteLine("ALL");
            Console.Write("Escribe una plataforma: ");
            condicion = Console.ReadLine();
            Console.WriteLine($"Todos los juegos son de esta plataforma {condicion}? - {consultas.linqAll(condicion)}");
            Console.ReadLine();
            menu();
            break;
        case 4:
            Console.WriteLine("ANY");
            Console.Write("Escribe un año de publicaicon: ");
            condicion = Console.ReadLine();
            Console.WriteLine($"Algun videojuego fue publicado en el año {condicion}? - {consultas.linqAny(condicion)}");
            Console.ReadLine();
            menu();
            break;
        case 5:
            Console.WriteLine("ORDER BY");
            Console.Write("Los juegos se ordenan de forma ascendente");
            ImprimirLista(consultas.linqOrderBy());
            Console.ReadLine();
            menu();
            break;
        case 6:
            Console.WriteLine("ORDER BY DESCENDING");
            Console.Write("Los juegos se ordenan de forma descendente");
            ImprimirLista(consultas.linqOrderByDescending());
            Console.ReadLine();
            menu();
            break;
        case 7:
            Console.WriteLine("TAKE");
            Console.Write("La lista tomara los primeros tres registros");
            ImprimirLista(consultas.linqTake());
            Console.ReadLine();
            menu();
            break;
        case 8:
            Console.WriteLine("SKIP");
            Console.Write("Los juegos se brincara los primeros 5 registros");
            ImprimirLista(consultas.linqSkip());
            Console.ReadLine();
            menu();
            break;
        case 9:
            Console.WriteLine("COUNT");
            Console.WriteLine($"Numero de registros de una tabla int - {consultas.linqCount()}");
            Console.ReadLine();
            menu();
            break;
        case 10:
            Console.WriteLine("COUNT LONG");
            Console.WriteLine($"Numero de registros de una tabla long - {consultas.linqLongCount()}");
            Console.ReadLine();
            menu();
            break;
        case 11:
            Console.WriteLine("MIN");
            Console.WriteLine($"La calificacion menor es - {consultas.linqMin()}");
            Console.ReadLine();
            menu();
            break;
        case 12:
            Console.WriteLine("MIN BY");
            var userMin = consultas.linqMinBy();
            Console.WriteLine($"El jugador mas joven es: {userMin.Nombre_Usuario} con {userMin.Edad} años");
            Console.ReadLine();
            menu();
            break;
        case 13:
            Console.WriteLine("MAX");
            Console.WriteLine($"La mayor calificacion es - {consultas.linqMin()}");
            Console.ReadLine();
            menu();
            break;
        case 14:
            Console.WriteLine("MAX BY");
            var userMax = consultas.linqMinBy();
            Console.WriteLine($"El jugador mas viejo es: {userMax.Nombre_Usuario} con {userMax.Edad} años");
            Console.ReadLine();
            menu();
            break;
        case 15:
            Console.WriteLine("SUM");
            Console.Write("Juego favorito: ");
            condicion = Console.ReadLine();
            Console.WriteLine($"Numero de horas jugadas por semana cuando el juego favorito es {condicion} son {consultas.linqSum(condicion)} horas");
            Console.ReadLine();
            menu();
            break;
        case 16:
            Console.WriteLine("AGREGGATE");
            Console.Write("Plataforma: ");
            condicion = Console.ReadLine();
            Console.WriteLine($"Juegos de la plataforma: {condicion} son: {consultas.linqAggregate(condicion)}");
            Console.ReadLine();
            menu();
            break;
        case 17:
            Console.WriteLine("AVERAGE");
            Console.WriteLine($"La edad media de los usuarios es: {consultas.linqAverage()}");
            Console.ReadLine();
            menu();
            break;
        case 18:
            Console.WriteLine("GROUP BY");
            Console.Write("Juegos agrupados por año de lanzamiento: \n");
            ImprimirGrupo(consultas.linqGroupBy());
            break;
        case 19:
            Console.WriteLine("TOLOOKUP");
            Console.Write("Juegos agrupados por alfabeto: \n");
            var diccionarioLookUp = consultas.linqToLookup();
            ImprimirDiccionario(diccionarioLookUp);
            break;
        case 20:
            Console.WriteLine("INNER JOIN");
            ImprimirLista(consultas.VideoJuegos());
            break;
        case 21:
            Console.WriteLine("LEFT JOIN");
            ImprimirLista(consultas.VideoJuegos());
            break;
        case 22:
            Console.WriteLine("RIGTH JOIN");
            ImprimirLista(consultas.VideoJuegos());
            break;
        case 23:
            Console.WriteLine("LIMPIAR");
            Console.Clear();
            menu();
            break;
    }
}

//Todos los juegos de playstation
ImprimirLista(consultas.VideoJuegos());
void menu()
{
    //Menu
    Console.WriteLine("Las consultas se hacen de dos colecciones de datos JSON con información de videojuegos");
    Console.WriteLine("Menu:");
    Console.WriteLine("1 - SELECT");
    Console.WriteLine("2 - CONTAINS");
    Console.WriteLine("3 - ALL");
    Console.WriteLine("4 - ANY");
    Console.WriteLine("5 - ORDER BY");
    Console.WriteLine("6 - ORDER BY DESCENDING");
    Console.WriteLine("7 - TAKE");
    Console.WriteLine("8 - SKIP");
    Console.WriteLine("9 - COUNT");
    Console.WriteLine("10 - COUNT LONG");
    Console.WriteLine("11 - MIN");
    Console.WriteLine("12 - MIN BY");
    Console.WriteLine("13 - MAX");
    Console.WriteLine("14 - MAX BY");
    Console.WriteLine("15 - SUM");
    Console.WriteLine("16 - AGREGGATE");
    Console.WriteLine("17 - AVERAGE");
    Console.WriteLine("18 - GROUP BY");
    Console.WriteLine("19 - LOOKUP");
    Console.WriteLine("20 - INNER JOIN");
    Console.WriteLine("21 - LEFT JOIN");
    Console.WriteLine("22 - RIGTH JOIN");
    Console.WriteLine("23 - LIMPIAR");

    Console.Write("Selecciona una opción:");
}

void ImprimirLista(IEnumerable<Game> listaDeJuegos)
{
    Console.WriteLine("{0, -35} {1, -50} {2, -25} {3, -25}\n", "Titulo", "Plataforma", "Desarrollador", "Genero");
    foreach (var item in listaDeJuegos)
    {
        Console.WriteLine("{0, -35} {1, -50} {2, -25} {3, -25}", item.Titulo, string.Join(", ", item.Plataforma), item.Desarrollador, item.Genero);
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int, Game>> listaDeJuegos)
{
    foreach(var grupo in listaDeJuegos)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0, -35} {1, -50} {2, -25}", item.Titulo, string.Join(", ", item.Plataforma), item.Calificacion);
        }
    }
}

void ImprimirDiccionario(ILookup<char, Game> listaDeJuegos)
{
    foreach (IGrouping<char, Game> Grupo in listaDeJuegos)
    {
        Console.WriteLine(Grupo.Key);
        foreach (Game str in Grupo)
            Console.WriteLine("    {0}", str.Titulo);
    }
}


//"titulo": "Metal Gear Solid",
//    "desarrollador": "Konami",
//    "editor": "Konami",
//    "fecha_lanzamiento": "1998-09-03",
//    "genero": [ "Acción", "Sigilo" ],
//    "plataforma": [ "PlayStation" ]