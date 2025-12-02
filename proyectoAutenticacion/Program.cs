namespace proyectoAutenticacion;

class Program
{
    static void Main(string[] args)
    {
        List<Empleado> listaDeEmpleados = new List<Empleado>();

        //AGREGAR EMPLEADOS
        listaDeEmpleados.Add(new Empleado(100, "Juanito"));
        listaDeEmpleados.Add(new Empleado(200, "Adrian"));

        //AGREGAR ROL A EMPLEADOS
        foreach (Empleado empleado in listaDeEmpleados)
        {
            if (empleado.Nombre == "Juanito") empleado.ListaDeRol.Add(new Rol(1111, "tipo1"));

            else if (empleado.Nombre == "Adrian") empleado.ListaDeRol.Add(new Rol(2222, "tipo2"));


        }

        //MOSTRAR LISTA DE EMPLEADO (CI  - NOMBRE - ROL)
        foreach (Empleado empleado in listaDeEmpleados)
        {
            Console.WriteLine($"\n-------------------------------------------");
            Console.WriteLine("EMPLEADO");
            Console.WriteLine($"CI: {empleado.Ci}");
            Console.WriteLine($"Nombre: {empleado.Nombre}");
            Console.WriteLine("ROL DEL EMPLEADO");
            foreach (Rol rol in empleado.ListaDeRol)
            {
                Console.WriteLine($"Codigo:{rol.CodigoRol}\t\tDescripcion: {rol.Descripcion}");
                Console.WriteLine($"-------------------------------------------");
            }
        }
    }
}
