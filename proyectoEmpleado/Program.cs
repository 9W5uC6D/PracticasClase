namespace proyectoEmpleado;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese la cantidad de empleados: ");
        uint cantidad = Convert.ToUInt32(Console.ReadLine());

        Empleado[] empleados = new Empleado[cantidad];
        DateTime[] fechasNacimiento = new DateTime[cantidad];

        leerDatosEmpleados(empleados, fechasNacimiento);
        mostrarEmpleados(empleados, fechasNacimiento);

    }

    static void leerDatosEmpleados(Empleado[] empleados, DateTime[] fechasNacimiento)
    {
        for (int i = 0; i < empleados.Length; i++)
        {
            Console.WriteLine($"\nIngrese los datos del empleado {i + 1}:");

            Console.Write("CI: ");
            uint ci = Convert.ToUInt32(Console.ReadLine());

            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();

            Console.Write("Año de Nacimiento: ");
            int anioNacimiento = Convert.ToInt32(Console.ReadLine());

            Console.Write("Mes de Nacimiento: ");
            int mesNacimiento = Convert.ToInt32(Console.ReadLine());

            Console.Write("Día de Nacimiento: ");
            int diaNacimiento = Convert.ToInt32(Console.ReadLine());

            fechasNacimiento[i] = new DateTime(anioNacimiento, mesNacimiento, diaNacimiento);

            empleados[i] = new Empleado(ci, nombre, fechasNacimiento[i]);
        }
    }
    static void mostrarEmpleados(Empleado[] empleados, DateTime[] fechasNacimiento)
    {
        Console.WriteLine("\nDatos de los empleados ingresados:");
        Console.WriteLine("=====================================");
        Console.WriteLine($"{"CI",-10}\t{"Nombre",-20}\t{"Edad",-5}");
        for (int i = 0; i < empleados.Length; i++)
        {
            Console.WriteLine($"{empleados[i].Ci,-10}\t{empleados[i].Nombre,-20}\t{DateTime.Now.Year - fechasNacimiento[i].Year,-5}");
        }
    }

}
