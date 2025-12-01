namespace proyectoNotasEstudiantes;

class Program
{
    private static Random r;
    private static int numObjetosRandom;

      static void Main(string[] args)

        {

            List<Alumno> listadeAlumnos = new List<Alumno>();

            obtenerNombresDeLosAlumnos(listadeAlumnos);

           

            Console.WriteLine("\nAlumnos registrados:");

            foreach (var alumno in listadeAlumnos)

            {

                Console.WriteLine($"- {alumno.Nombre}");

            }
        
            generarNotaParaLosAlumnos(listadeAlumnos);

            mostarnotasDelosAlumnos(listadeAlumnos);

        }

       

        public static void crearObjetoRandom()

        {          

            numObjetosRamndom++;

            if(numObjetosRamndom == 1)

                r = new Random();

        }

       

        public static int generarunaNota()

        {

            return r.Next(30,101) ;

        }

       

        static void obtenerNombresDeLosAlumnos(List<Alumno> listadeAlumnos)

        {

            int resultadodeComparacion;

            string nombrealum = string.Empty;


            do

            {

                Console.Write("Nombre del alumno (fin para continuar): ");

                nombrealum = Console.ReadLine();

                resultadodeComparacion = string.Compare(nombrealum, "fin");

               

                if(resultadodeComparacion == 0)

                {

                    Console.WriteLine($"Se han introducido {listadeAlumnos.Count} alumnos");

                }

                else if (!string.IsNullOrWhiteSpace(nombrealum))

                {

                    listadeAlumnos.Add(new Alumno(nombrealum));

                }

               

            } while(resultadodeComparacion != 0);

        }
    
        static void generarNotaParaLosAlumnos(List<Alumno> listadeAlumnos)

        {

            int suma;

            crearObjetoRandom();

            foreach(Alumno alumno in listadeAlumnos)

            {

                for(int i = 0; i < 5; i++)

                {

                    alumno.ListaNotas.Add(generarunaNota());

                }

                suma = 0;

                foreach (int nota in alumno.ListaNotas)

                {

                    suma += nota;

                }

                alumno.NotaFinal = suma / 4;

            }

        }

       

        static void mostarnotasDelosAlumnos(List<Alumno> listadeAlumnos)

        {

            Console.WriteLine("\n\n--- NOTAS DE LOS ALUMNOS ---");

           

            Console.WriteLine("---------------------------------------------------");

           

            foreach(Alumno alumno in listadeAlumnos)

            {

                Console.Write($"{alumno.Nombre}\t\t");

                Console.Write(string.Join(", ", alumno.ListaNotas));

                Console.Write($"\t\t{alumno.NotaFinal:F1}\t\t");

               

                if(alumno.NotaFinal >= 61)

                {

                    Console.Write("APROBADO");

                }

                else

                {

                    Console.Write("REPROBADO");

                }

                Console.WriteLine();

            }

        }

    }

