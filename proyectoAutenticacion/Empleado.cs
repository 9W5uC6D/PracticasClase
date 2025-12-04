class Empleado
{
    public int Ci { set; get; }
    public string Nombre { set; get; }
    public List<Usuario> ListaDeUsuarios { set; get; }
    public Empleado(int ci, string nombre)
    {
        Ci = ci;
        Nombre = nombre;
        ListaDeUsuarios = new List<Usuario>();
    }
}