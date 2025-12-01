namespace proyectoSumatoria;

class Program
{
    static void Main(string[] args)
    {
        string num1, num2;
        int[] suma = null;
        int numMayor, numMenor;
        Console.Write("Inngresa un numero: ");
        num1 = Console.ReadLine();
        Console.Write("\nInngresa un numero: ");
        num2 = Console.ReadLine();


        if (num1.Length >= num2.Length)
        {
            numMayor = num1.Length;
            numMenor = num2.Length;
            sumar(num1, num2, ref suma);
        }
        else
        {
            numMayor = num2.Length;
            numMenor = num1.Length;
            sumar(num2, num1, ref suma);
        }
    }


    private static void sumar(string numMayor, string numMenor, ref int[] suma)
    {
        suma = new int[numMayor.Length + 1];
        int adicional = 0, sumaM = 0;
        string sumaMomentanea = null;
        for (int i = numMayor.Length; i > 0; i--)
        {
            if (i > numMenor.Length)
            {
                suma[i - 1] = Convert.ToInt32(numMayor[i].ToString());
            }
            else
            {
                sumaM = int.Parse(numMayor[i].ToString()) + int.Parse(numMenor[i].ToString()) + adicional;
                sumaMomentanea = Convert.ToString(sumaM);
                if (sumaM >= 10)
                {
                    adicional = Convert.ToInt32(sumaMomentanea[0].ToString());
                    suma[i] = Convert.ToInt32(sumaMomentanea[1].ToString());

                }
                else
                {
                    adicional = 0;
                    suma[i] = sumaM;
                }
            }
        }
        int start = (suma[0] == 0) ? 1 : 0;
        Console.Write("Resultado: ");
        for (int i = start; i < suma.Length; i++)
        {
            Console.Write(suma[i]);
        }
        Console.Write("\n");
    }



}
