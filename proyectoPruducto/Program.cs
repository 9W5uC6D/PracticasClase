using System.Reflection.Metadata;

namespace proyectoPruducto;

class Program
{
    static void Main(string[] args)
    {

        string nombre;
        bool esDatoValido;
        DateTime fechaVencimientoInput;
        Console.WriteLine("\t--- Ingresa los datos del producto ---");
        Console.Write("Nombre: ");
        nombre = Console.ReadLine()?.ToUpper();
        do
        {
            Console.Write($"Ingrese la fecha de vencimiento del producto \" {nombre} \"\n (día/mes/año):");
            string fechaInput = Console.ReadLine();

            esDatoValido = DateTime.TryParse(fechaInput, out fechaVencimientoInput);
            if (!esDatoValido)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("¡¡¡ERROR!!! ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Formato de fecha no válido o fecha imposible. Por favor, ingrésala correctamente (ej: AAAA-MM-DD o DD/MM/AAAA).");
                Console.ResetColor();
            }

        } while (!esDatoValido);


        var producto = new Producto(nombre, fechaVencimientoInput);
        VencimientoMensaje(producto);



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
        bool estaVencido = vencimiento(producto);
        if (estaVencido)
        {
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine($"El producto {producto.Nombre} está vencido.");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"\nLa fecha de vencimiento es: {fechaVenProducto.Day}/{fechaVenProducto.Month}/{fechaVenProducto.Year}");
            Console.WriteLine($"La fecha actual es: {fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}\n");
        }
        else
        {
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine($"El producto {producto.Nombre} NO está vencido.");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine($"\nLa fecha de vencimiento es: {fechaVenProducto.Day}/{fechaVenProducto.Month}/{fechaVenProducto.Year}");
            Console.WriteLine($"La fecha actual es: {fechaActual.Day}/{fechaActual.Month}/{fechaActual.Year}\n");
        }
    }


}
