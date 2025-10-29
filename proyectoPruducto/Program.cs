using System.Reflection.Metadata;

namespace proyectoPruducto;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\t--- Ingresa los datos del producto ---");
        Console.Write("Nombre: ");
        string? nombre = Console.ReadLine()?.ToUpper();
        Console.WriteLine($"Ingrese la fecha de vencimiento del producto \" {nombre} \"");
        Console.Write("Año: ");
        int año = Convert.ToInt32(Console.ReadLine());
        Console.Write("Mes: ");
        int mes = Convert.ToInt32(Console.ReadLine());
        Console.Write("Día: ");
        int dia = Convert.ToInt32(Console.ReadLine());
        DateTime fechaVencimiento = new DateTime(año, mes, dia);

        var pructo = new Producto(nombre, fechaVencimiento);
        VencimientoMensaje(pructo);



    }

    public static bool vencimiento(Producto producto)
    {

        DateTime fechaActual = DateTime.Now;
        DateTime fechaVenProducto = producto.FechaVencimiento;
        bool vencido = false;
        if (fechaActual.Year > fechaVenProducto.Year)
        {
            vencido = true;
        }
        else if (fechaActual.Month > fechaVenProducto.Month)
        {
            vencido = true;
        }
        else if (fechaActual.Day > fechaVenProducto.Day)
        {
            vencido = true;
        }

        return vencido;


    }

    public static void VencimientoMensaje(Producto producto)
    {
        DateTime fechaActual = DateTime.Now;
        DateTime fechaVenProducto = producto.FechaVencimiento;
        if (vencimiento(producto.FechaVencimiento))
        {
            Console.WriteLine($"El producto {producto.Nombre} está vencido.");
            Console.WriteLine($"La fecha de vencimiento es: {fechaVenProducto.Day}/{fechaVenProducto.Month}/{fechaVenProducto.Year}");
            Console.WriteLine($"La fecha actual es: {fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}");
        }
        else
        {
            Console.WriteLine($"El producto {producto.Nombre} NO está vencido.");
            Console.WriteLine($"La fecha de vencimiento es: {fechaVenProducto.Day}/{fechaVenProducto.Month}/{fechaVenProducto.Year}");
            Console.WriteLine($"La fecha actual es: {fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}");
        }
    }


}
