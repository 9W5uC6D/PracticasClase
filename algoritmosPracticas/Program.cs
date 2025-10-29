namespace algoritmosPracticas;

class Program
{
    // Usar un Random compartido evita repetición al crear arrays rápidos
    private static Random rnd = new Random();

    static void Main(string[] args)
    {
        int tam = 12;     // capacidad total del array
        int used = 8;     // cuántas posiciones están realmente llenas
        int i = 2;        // índice donde insertar
        int v = 99;       // valor a insertar

        // Crear array con capacidad 'tam' pero solo llenar las primeras 'used' posiciones
        int[] arr = new int[tam];
        for (int k = 0; k < used; k++)
        {
            arr[k] = rnd.Next(0, 101);
        }

        Console.WriteLine("Array inicial (solo posiciones usadas):");
        MostrarArray(arr, used);


        // Desplazar elementos usados a la derecha para hacer espacio
        for (int j = used - 1; j >= i; j--)
        {
            arr[j + 1] = arr[j];
        }

        arr[i] = v;
        used++; // ahora hay una posición más usada
        Console.WriteLine($"\nArray después de insertar {v} en posición {i}:");
        MostrarArray(arr, used);
    }


    // Crea y devuelve un array de 'tamaño' con números aleatorios en [minValue, maxValue]
    private static int[] CrearArrayAleatorio(int tamaño, int minValue, int maxValue)
    {
        if (tamaño < 0) throw new ArgumentException("El tamaño debe ser >= 0", nameof(tamaño));
        if (minValue > maxValue) throw new ArgumentException("minValue debe ser <= maxValue");

        int[] resultado = new int[tamaño];
        for (int i = 0; i < tamaño; i++)
        {
            resultado[i] = rnd.Next(minValue, maxValue + 1);
        }
        return resultado;
    }

    // Muestra el array indicando el índice y el valor (solo hasta 'used' posiciones)
    private static void MostrarArray(int[] arr, int used)
    {
        for (int i = 0; i < used; i++)
        {
            Console.WriteLine($"[{i}] = {arr[i]}");
        }
    }

    // Mantengo el método original por compatibilidad si se necesita
    private static void MostrarArray(int[] arr)
    {
        MostrarArray(arr, arr.Length);
    }
}
