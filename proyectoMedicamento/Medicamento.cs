class Medicamento
{
    public int Codigo { get; set; }
    public string? Descripcion { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public double Precio { get; set; }
    public int Stock { get; set; }

    public Medicamento(int codigo, string? descripcion, DateTime fechaVencimiento, double precio, int stock)
    {
        Codigo = codigo;
        Descripcion = descripcion;
        FechaVencimiento = fechaVencimiento;
        Precio = precio;
        Stock = stock;
    }
}