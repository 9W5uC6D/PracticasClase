class Rol
{
    public int CodigoRol { set; get; }
    public string Descripcion { set; get; }
    public Rol(int codigoRol, string descripcion)
    {
        CodigoRol = codigoRol;
        Descripcion = descripcion;
    }
}