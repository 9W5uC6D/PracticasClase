namespace proyectoAutenticacion;

class Program
{
    static void Main(string[] args)
    {
        //LISTA DE EMPLEADOS
        List<Empleado> listaDeEmpleados = new List<Empleado>();


        //AGREGAR DATOS A LA LISTA ---> RADLINE()
        Empleado empleado = null;
        Usuario usuario = null;
        Rol rol = null;
        bool terminar;
        do
        {
            terminar = true;
            Console.WriteLine("\nAGREGAR DATOS DE EMPLEADO");
            Console.Write("CI: ");
            int ci = int.Parse(Console.ReadLine());
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            empleado = new Empleado(ci, nombre);
            listaDeEmpleados.Add(empleado);
            Console.Write("\nAGREGAR USUARIO AL EMPLEADO? (S/N) ");
            string p = Console.ReadLine().ToLower();
            if (p == "s")
            {
                do
                {
                    Console.Write("Nick: ");
                    string nick = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    usuario = new Usuario(nick, password);
                    empleado.ListaDeUsuarios.Add(usuario);
                    Console.Write("\nAGREGAR OTRO USUARIO AL EMPLEADO? (S/N) ");
                    p = Console.ReadLine().ToLower();
                } while (p == "s");
                Console.Write("\nAGREGAR ROL(ES) AL EMPLEADO? (S/N) ");
                p = Console.ReadLine().ToLower();
                if (p == "s")
                {
                    do
                    {
                        Console.Write("Codigo Rol: ");
                        int codigoRol = int.Parse(Console.ReadLine());
                        Console.Write("Descripcion: ");
                        string descripcion = Console.ReadLine();
                        rol = new Rol(codigoRol, descripcion);
                        usuario.ListaDeRol.Add(rol);
                        Console.Write("\nAGREGAR OTRO ROL AL EMPLEADO? (S/N) ");
                        p = Console.ReadLine().ToLower();
                    } while (p == "s");
                }
            }
            Console.Write("\nAGREGAR OTRO EMPLEADO? (S/N) ");
            p = Console.ReadLine().ToLower();
            if (p == "n")
            {
                terminar = false;
            }
        } while (terminar);


        //MOSTRAR LISTA DE EMPLEADO(CI  -NOMBRE - ROL)
        foreach (Empleado e in listaDeEmpleados)
        {
            Console.WriteLine($"\n-------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("EMPLEADO");
            Console.ResetColor();
            Console.WriteLine($"Nombre: {e.Nombre}\tCI: {e.Ci}");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("USUARIO/S DEL EMPLEADO");
            Console.ResetColor();
            foreach (Usuario u in e.ListaDeUsuarios)
            {
                Console.WriteLine($"Codigo:{u.Nick}\tDescripcion: {u.Nick}");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("ROL(ES) DEL USUARIO");
                Console.ResetColor();
                foreach (Rol r in u.ListaDeRol)
                {
                    Console.WriteLine($"Codigo:{r.CodigoRol}\tDescripcion: {r.Descripcion}");
                }
            }
        }
    }
}
