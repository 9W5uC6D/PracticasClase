namespace proyectoMedicamento;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingresa la cantidad de medicamentos a registrar: ");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        Medicamento[] medicamentos = new Medicamento[cantidad];


        leerDatosDeLosMedicamentos(medicamentos);
        mostrarMedicamentos(medicamentos);
        mostrarMedicamentosProximosAVencer(medicamentos);
        mostrarMedicamentosVencidos(medicamentos);
    }


    public static void leerDatosDeLosMedicamentos(Medicamento[] medicamentos)
    {

        int codigo = 0, stock = 0;
        double precio = 0.0;
        string descripcion = "";
        DateTime fechaVencimiento = DateTime.MinValue;

        for (int i = 0; i < medicamentos.Length; i++)
        {
            bool medicamentoValido = false;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine($"\nIngrese los datos del medicamento N° {i + 1}");
                Console.ResetColor();

                Console.Write("Código: ");

                if (!int.TryParse(Console.ReadLine()!, out codigo))
                {
                    Console.WriteLine("Código inválido. Intente de nuevo.");
                    continue;
                }

                Console.Write("Descripcion: ");
                descripcion = Console.ReadLine()!.ToUpper();

                Console.Write("Fecha de vencimiento (DIA-MES-AÑO): ");

                if (!DateTime.TryParse(Console.ReadLine()!, out fechaVencimiento))
                {
                    Console.WriteLine("Fecha inválida. Intente de nuevo.");
                    continue;
                }

                Console.Write("Precio: ");

                if (!double.TryParse(Console.ReadLine()!, out precio))
                {
                    Console.WriteLine("Precio inválido. Intente de nuevo.");
                    continue;
                }

                Console.Write("Stock: ");

                if (!int.TryParse(Console.ReadLine()!, out stock))
                {
                    Console.WriteLine("Stock inválido. Intente de nuevo.");
                    continue;
                }
                medicamentoValido = true;
            } while (!medicamentoValido);

            medicamentos[i] = new Medicamento(codigo, descripcion, fechaVencimiento, precio, stock);
        }
    }

    public static void mostrarMedicamentos(Medicamento[] medicamentos)
    {
        ordenar(medicamentos);

        int k = 1;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n{"",20}---- LISTA DE MEDICAMENTOS REGISTRADOS ----\n");
        Console.WriteLine($"{"N°"}\t{"código",6}\t{"descripción",15}\t{"fech. de venc.",20}\t{"precio unit.",12}\t{"stock",6}\n");
        Console.ResetColor();
        foreach (var medicamento in medicamentos)
        {
            string fechaFormateada = medicamento.FechaVencimiento.ToString("dd MMM yyyy");
            Console.WriteLine($"{k}\t{medicamento.Codigo,6}\t{medicamento.Descripcion,15}\t{fechaFormateada,20}\t{medicamento.Precio,12:F2}\t{medicamento.Stock,6}");
            k++;
        }
    }

    public static void mostrarMedicamentosProximosAVencer(Medicamento[] medicamentos)
    {
        int fechaActual = DateTime.Now.DayOfYear;

        int k = 1;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n\n{"",26}---- LISTA DE MEDICAMENTOS POR VENCER EN 30 DÍAS ----\n");
        Console.WriteLine($"{"N°"}\t{"código",6}\t{"descripción",15}\t{"fech. de venc.",20}\t{"días res",8}\t{"precio unit.",12}\t{"stock",6}\n");
        Console.ResetColor();
        foreach (var medicamento in medicamentos)
        {

            int diasRestantes = medicamento.FechaVencimiento.DayOfYear - fechaActual;
            if (diasRestantes <= 30 && diasRestantes > 0)
            {
                string fechaFormateada = medicamento.FechaVencimiento.ToString("dd MMM yyyy");
                Console.WriteLine($"{k}\t{medicamento.Codigo,6}\t{medicamento.Descripcion,15}\t{fechaFormateada,20}\t{diasRestantes,8}\t{medicamento.Precio,12:F2}\t{medicamento.Stock,6}");
                k++;
            }
        }

    }

    public static void mostrarMedicamentosVencidos(Medicamento[] medicamentos)
    {
        int k = 1;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n\n{"",26}---- LISTA DE MEDICAMENTOS VENCIDOS ----\n");
        Console.WriteLine($"{"N°"}\t{"código",6}\t{"descripción",15}\t{"fech. de venc.",20}\t{"precio unit.",12}\t{"stock",6}\n");
        Console.ResetColor();
        foreach (var medicamento in medicamentos)
        {
            if (medicamento.FechaVencimiento < DateTime.Now || medicamento.FechaVencimiento.Date == DateTime.Now.Date)
            {
                string fechaFormateada = medicamento.FechaVencimiento.ToString("dd MMM yyyy");
                Console.WriteLine($"{k}\t{medicamento.Codigo,6}\t{medicamento.Descripcion,15}\t{fechaFormateada,20}\t{medicamento.Precio,12:F2}\t{medicamento.Stock,6}");
                k++;
            }
        }
    }



    private static void intercambiar(ref Medicamento meidcamento1, ref Medicamento meidcamento2)
    {
        Medicamento aux = meidcamento1;
        meidcamento1 = meidcamento2;
        meidcamento2 = aux;
    }
    private static void ordenar(Medicamento[] medicamentos)
    {
        int limite = medicamentos.Length - 1;
        int resultadoDeComparacion;
        bool hayIntercambio;
        do
        {
            hayIntercambio = false;
            for (int i = 0; i < limite; i++)
            {
                resultadoDeComparacion = DateTime.Compare(medicamentos[i].FechaVencimiento, medicamentos[i + 1].FechaVencimiento);
                if (resultadoDeComparacion > 0)
                {
                    intercambiar(ref medicamentos[i], ref medicamentos[i + 1]);
                    hayIntercambio = true;
                }
            }
            limite--;
        } while (hayIntercambio);
    }






}
