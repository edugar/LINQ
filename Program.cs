using linq;
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
            Console.Write("Escribe el nombre del juego de PlayStation que quieres buscar: ");
            condicion = Console.ReadLine();
            ImprimirLista(consultas.linqWHERE(condicion));
            Console.ReadLine();
            menu();
            break;
        case 2:
            Console.WriteLine("CONTAINS");
            Console.Write("Escribe el nombre de la plataforma que quieres buscar: ");
            condicion = Console.ReadLine();
            ImprimirLista(consultas.linqContains(condicion));
            Console.ReadLine();
            menu();
            break;
        case 3:
            Console.WriteLine("ALL");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 4:
            Console.WriteLine("ANY");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 5:
            Console.WriteLine("ORDER BY");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 6:
            Console.WriteLine("ORDER BY DESCENDING");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 7:
            Console.WriteLine("TAKE");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 8:
            Console.WriteLine("SKIP");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 9:
            Console.WriteLine("COUNT");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 10:
            Console.WriteLine("COUNT LONG");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 11:
            Console.WriteLine("MIN");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 12:
            Console.WriteLine("MIN BY");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 13:
            Console.WriteLine("MAX");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 14:
            Console.WriteLine("MAX BY");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 15:
            Console.WriteLine("SUM");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 16:
            Console.WriteLine("AGREGGATE");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 17:
            Console.WriteLine("AVERAGE");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 18:
            Console.WriteLine("GROUP BY");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 19:
            Console.WriteLine("LOOKUP");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 20:
            Console.WriteLine("INNER JOIN");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 21:
            Console.WriteLine("LEFT JOIN");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 22:
            Console.WriteLine("RIGTH JOIN");
            ImprimirLista(consultas.JuegosPS());
            break;
        case 23:
            Console.WriteLine("LIMPIAR");
            Console.Clear();
            menu();
            break;
    }
}

//Todos los juegos de playstation
ImprimirLista(consultas.JuegosPS());
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
    Console.WriteLine("{0, -35} {1, -25} {2, -25} {3, -25}\n", "Titulo", "Plataforma", "Desarrollador", "Editor");
    foreach (var item in listaDeJuegos)
    {
        Console.WriteLine("{0, -35} {1, -25} {2, -25} {3, -25}", item.Titulo, string.Join(", ", item.Plataforma), item.Desarrollador, item.Editor);
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
            Console.WriteLine("{0, -35} {1, -25} {2, -25} {3, -25}", item.Titulo, string.Join(", ", item.Plataforma), item.Desarrollador, item.Editor );
        }
    }
}

void ImprimirDiccionario(ILookup<char, Game> listaDeJuegos, char letra)
{
    Console.WriteLine("{0, -35} {1, -25} {2, -25} {3, -25}\n", "Titulo", "Plataforma", "Desarrollador", "Editor");
    foreach(var item in listaDeJuegos[letra])
    {
        Console.WriteLine("{0, -35} {1, -25} {2, -25} {3, -25}", item.Titulo, string.Join(", ", item.Plataforma), item.Desarrollador, item.Editor);
    }
}


//"titulo": "Metal Gear Solid",
//    "desarrollador": "Konami",
//    "editor": "Konami",
//    "fecha_lanzamiento": "1998-09-03",
//    "genero": [ "Acción", "Sigilo" ],
//    "plataforma": [ "PlayStation" ]