namespace proyectoMejoresNotas;

class Alumno
{
    public string Nombre { set; get; }
    public List<int> ListaDeNotas { set; get; }
    public int NotaFinal { set; get; }

    public Alumno(string nombre)
    {
        Nombre = nombre;
        ListaDeNotas = new List<int>();
        NotaFinal = 0;
    }
}
class Program
{
    private static Random r;
    private static int objsCreados;
    static void Main(string[] args)
    {
        List<Alumno> listaAlumnos = new List<Alumno>();
        creacionObj();
        addNombreEstudiantes(listaAlumnos);
        //mostrarNombres(listaAlumnos);
        generarNotaParaLosAlumnos(listaAlumnos);
        mostrarNotasAlumnos(listaAlumnos);
        mejoresNotas(listaAlumnos);

    }
    private static void creacionObj()
    {
        objsCreados++;
        if (objsCreados == 1) r = new Random();
    }

    private static void addNombreEstudiantes(List<Alumno> listaAlumnos)
    {
        int i = 1;
        bool finalizar = true;
        string nombreAlumno = string.Empty;
        do
        {
            Console.WriteLine($"\nIngresa el nombre del Alumno N° {i++}");
            Console.Write("Nombre: ");
            listaAlumnos.Add(new Alumno(Console.ReadLine()));
            Console.Write($"\nAgregar a otro alumno? (s/n) : ");
            nombreAlumno = Console.ReadLine();
            finalizar = nombreAlumno == "S" || nombreAlumno == "s" ? true : false;
        } while (finalizar);
    }
    private static void generarNotaParaLosAlumnos(List<Alumno> listadeAlumnos)
    {
        Console.Write("Ingrese la cantidad de notas a generar: ");
        int cantidadDeNotas = Convert.ToInt32(Console.ReadLine());
        foreach (var alumno in listadeAlumnos)
        {
            for (int i = 0; i < cantidadDeNotas; i++)
            {
                alumno.ListaDeNotas.Add(generarNota());
            }
        }
    }
    private static void mostrarNotasAlumnos(List<Alumno> listadeAlumnos)
    {
        Console.WriteLine("\n\n--- NOTAS DE LOS ALUMNOS ---");
        Console.WriteLine("----------------------------------");
        foreach (Alumno alumno in listadeAlumnos)
        {
            Console.WriteLine($"{alumno.Nombre}\t\t");
            Console.WriteLine(string.Join(", ", alumno.ListaDeNotas));
            if (alumno.NotaFinal != 0)
            {
                Console.WriteLine($"Promedio: {alumno.NotaFinal}\n");
            }
            else
            {
                Console.WriteLine("");
            }
        }
    }
    private static void mejoresNotas(List<Alumno> listadeAlumnos)
    {
        Console.Write("Ingrese la cantidad de mejores notas que quiera contar: ");
        int cantidadDeNotas = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"\n\n--- MJORES {cantidadDeNotas} NOTAS DE LOS ALUMNOS ---\n");
        foreach (var alumno in listadeAlumnos)
        {
            int suma = 0;
            alumno.ListaDeNotas.Sort();
            alumno.ListaDeNotas.Reverse();
            Console.WriteLine($"{alumno.Nombre}");
            for (int i = 0; i < cantidadDeNotas; i++)
            {
                Console.Write($"{alumno.ListaDeNotas[i]} ");
                suma += alumno.ListaDeNotas[i];
            }
            double promedio = suma / cantidadDeNotas;
            Console.WriteLine($"\nPromedio: {promedio:F2}");
            if (promedio > 60)
            {
                Console.WriteLine("APROBADO\n");
            }
            else
            {
                Console.WriteLine("REPROBADO\n");
            }
        }
    }



    private static int generarNota()
    {
        return r.Next(30, 101);
    }
    private static void mostrarNombres(List<Alumno> listaAlumnos)
    {
        Console.WriteLine("LISTA DE NOMBRES");
        foreach (var alumno in listaAlumnos)
        {
            Console.WriteLine(alumno.Nombre);
        }
    }
}
