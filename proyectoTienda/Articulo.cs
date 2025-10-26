class Articulo
{
    public uint Codigo { get; set; }
    public string? Descripcion { get; set; }
    public double PrecioUnitario { get; set; }
    public uint Stock { get; set; }


    public Articulo(uint codigo, string? descripcion, double precioUnitario, uint stock)
    {
        Codigo = codigo;
        Descripcion = descripcion;
        PrecioUnitario = precioUnitario;
        Stock = stock;
    }
}