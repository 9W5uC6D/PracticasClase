class Empleado
{
    public int Ci { set; get; }
    public string Nombre { set; get; }
    public List<Rol> ListaDeRol { set; get; }
    public Empleado(int ci, string nombre)
    {
        Ci = ci;
        Nombre = nombre;
        ListaDeRol = new List<Rol>();
    }
}