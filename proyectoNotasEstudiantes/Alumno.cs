class Alumno
{
    public string Nombre { set; get; }
    public List<int> ListaDeNotas { set; get; }
    public int NotaFinal { set; get; }

    public Alumno(string nombre)
    {
        Nombre = nombre;
        ListaDeNotas = new List<int>();
    }
}