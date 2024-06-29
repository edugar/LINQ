public class User
{
    public int Id { get; }
    public string Nombre_Usuario { get; set; }
    public int Edad { get; set; }
    public string Pais { get; set; }
    public string[] Juegos_Favoritos { get; set; }
    public int Horas_Jugadas_Semana { get; set; }
    public DateTime Miembro_Desde { get; set; }
    public string[] Logros { get; set; }
    public string Descripcion { get; set; }
}