class Producto
{
    public string? Nombre { get; set; }
    public DateTime FechaVencimiento { get; set; }

    public Producto(string? nombre, DateTime fechaVencimiento)
    {
        Nombre = nombre;
        FechaVencimiento = fechaVencimiento;
    }
}