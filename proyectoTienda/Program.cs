namespace proyectoTienda;

class Program
{
    // Agregar al inicio de la clase Program
    private static Random rnd = new Random();

    private static string[] descripciones = {
    "ARROZ", "LECHE", "PAN", "HUEVOS", "CARNE", "POLLO", "PESCADO",
    "MANZANA", "PLATANO", "ZANAHORIA", "TOMATE", "CEBOLLA", "PAPA",
    "YOGURT", "QUESO", "JAMON", "ACEITE", "SAL", "AZUCAR", "CAFE",
    "GALLETAS", "PASTA", "ATUN", "FRIJOLES", "LENTEJAS", "CHOCOLATE"
};

    private static Articulo GenerarArticuloAleatorio()
    {
        uint codigo = (uint)rnd.Next(1000, 9999);
        string descripcion = descripciones[rnd.Next(descripciones.Length)];
        double precio = Math.Round(rnd.NextDouble() * 100 + 1, 2);
        uint stock = (uint)rnd.Next(1, 100);

        return new Articulo(codigo, descripcion, precio, stock);
    }

    // Reemplazar el método Main actual con este:
    static void Main(string[] args)
    {
        const int CANTIDAD = 50;

        Articulo[] articulosPerecederos = new Articulo[CANTIDAD];
        Articulo[] articulosImperecederos = new Articulo[CANTIDAD];
        Articulo[] unionSimple = new Articulo[CANTIDAD * 2];
        Articulo[] unionOrdenada = new Articulo[CANTIDAD * 2];

        // Generar artículos aleatorios
        for (int i = 0; i < CANTIDAD; i++)
        {
            articulosPerecederos[i] = GenerarArticuloAleatorio();
            articulosImperecederos[i] = GenerarArticuloAleatorio();
        }

        Console.WriteLine("\n=== SIMULACIÓN CON 50 ARTÍCULOS DE CADA TIPO ===\n");

        mostrarArticulos(articulosPerecederos, "PERECEDEROS");
        mostrarArticulos(articulosImperecederos, "IMPERECEDEROS");

        unirSimplemente(unionSimple, articulosPerecederos, articulosImperecederos);
        mostrarArticulos(unionSimple, "UNION SIMPLE");

        unirOrdenadamente(unionOrdenada, articulosPerecederos, articulosImperecederos);
        mostrarArticulos(unionOrdenada, "UNION ORDENADA");

        // Verificaciones adicionales
        Console.WriteLine("\n=== VERIFICACIONES ===");
        Console.WriteLine($"Total artículos en unión simple: {unionSimple.Length}");
        Console.WriteLine($"Total artículos en unión ordenada: {unionOrdenada.Length}");
        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadKey();
    }





    /* static void Main(string[] args)
    {
        Console.Write("Ingrsa la cantidad de articulos PERECEDEROS: ");
        uint cantidadPerecederos = Convert.ToUInt32(Console.ReadLine());
        Console.Write("Ingrsa la cantidad de articulos IMPERECEDEROS: ");
        uint cantidadImperecederos = Convert.ToUInt32(Console.ReadLine());


        Articulo[] articulosPerecederos = new Articulo[cantidadPerecederos];
        Articulo[] articulosImperecederos = new Articulo[cantidadImperecederos];
        Articulo[] unionSimple = new Articulo[cantidadPerecederos + cantidadImperecederos];
        Articulo[] unionOrdenada = new Articulo[cantidadPerecederos + cantidadImperecederos];


        addArticulos(articulosPerecederos, "PERECEDEROS");
        addArticulos(articulosImperecederos, "IMPERECEDEROS");
        mostrarArticulos(articulosPerecederos, "PERECEDEROS");
        mostrarArticulos(articulosImperecederos, "IMPERECEDEROS");
        unirSimplemente(unionSimple, articulosPerecederos, articulosImperecederos);
        mostrarArticulos(unionSimple, "UNION SIMPLE");
        unirOrdenadamente(unionOrdenada, articulosPerecederos, articulosImperecederos);
        mostrarArticulos(unionOrdenada, "UNION ORDENADA");

    } */


    private static void addArticulos(Articulo[] articulos, string tipoArticulo)
    {
        Console.WriteLine($"\nInserta datos de los articulos {tipoArticulo}:");
        for (int i = 0; i < articulos.Length; i++)
        {
            Console.WriteLine($"\nArticulo {i + 1}:");
            Console.Write("Codigo: ");
            uint codigo = Convert.ToUInt32(Console.ReadLine());
            Console.Write("Descripcion: ");
            string? descripcion = Console.ReadLine()?.ToUpper();
            Console.Write("Precio Unitario: ");
            double precioUnitario = Convert.ToDouble(Console.ReadLine());
            Console.Write("Stock: ");
            uint stock = Convert.ToUInt32(Console.ReadLine());

            articulos[i] = new Articulo(codigo, descripcion, precioUnitario, stock);
        }
    }

    private static void mostrarArticulos(Articulo[] articulos, string tipoArticulo)
    {
        int k = 1;
        Console.WriteLine($"\n\t---- Lista de articulos {tipoArticulo} ----\n");
        Console.WriteLine($"{"N°"}\t{"CODIGO",4}\t{"DESCRIPCION",15}\t{"PRECIO UNIT.",15}\t{"STOCK",9}");
        Console.WriteLine("------------------------------------------------------");
        foreach (var articulo in articulos)
        {
            Console.WriteLine($"{k++}\t{articulo.Codigo,4}\t{articulo.Descripcion,15}\t{articulo.PrecioUnitario,15}\t{articulo.Stock,9}");
        }
    }

    private static void unirSimplemente(Articulo[] union, Articulo[] arreglo1, Articulo[] arreglo2)
    {
        int cont = 0;
        for (int i = 0; i < arreglo1.Length; i++)

            union[cont++] = arreglo1[i];

        for (int i = 0; i < arreglo2.Length; i++)

            union[cont++] = arreglo2[i];

    }

    private static void unirOrdenadamente(Articulo[] unionOrdenada, Articulo[] lista1, Articulo[] lista2)
    {
        int contList1 = 0;
        int contList2 = 0;
        int contUnion = 0;

        ordenar(lista1);
        ordenar(lista2);

        while ((contList1 < lista1.Length)
                && (contList2 < lista2.Length))
        {
            if (string.Compare(lista1[contList1].Descripcion, lista2[contList2].Descripcion) < 0)
            {
                unionOrdenada[contUnion++] = lista1[contList1++];
            }
            else
            {
                unionOrdenada[contUnion++] = lista2[contList2++];
            }
        }

        while (contList1 < lista1.Length)
        {
            unionOrdenada[contUnion++] = lista1[contList1++];
        }

        while (contList2 < lista2.Length)
        {
            unionOrdenada[contUnion++] = lista2[contList2++];
        }
    }

    private static void intercambiar(ref Articulo articulo1, ref Articulo articulo2)
    {
        Articulo aux = articulo1;
        articulo1 = articulo2;
        articulo2 = aux;
    }
    private static void ordenar(Articulo[] articulos)
    {
        int limite = articulos.Length - 1;
        int resultadoDeComparacion;
        bool hayIntercambio;
        do
        {
            hayIntercambio = false;
            for (int i = 0; i < limite; i++)
            {
                resultadoDeComparacion = string.Compare(articulos[i].Descripcion, articulos[i + 1].Descripcion);
                if (resultadoDeComparacion > 0)
                {
                    intercambiar(ref articulos[i], ref articulos[i + 1]);
                    hayIntercambio = true;
                }
            }
            limite--;
        } while (hayIntercambio);
    }

}
