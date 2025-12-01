namespace oyectoRegistroVehiculo;

class Program
{
    static void Main(string[] args)
    {


        Vehiculo[] vehiculos = new Vehiculo[15];

        // 1. CAMIONETA
        vehiculos[0] = new Vehiculo(
            marca: "TOYOTA",
            modelo: 2024,
            fechaRegistro: new DateTime(2024, 10, 20),
            tipo: "CAMIONETA",
            placa: "ABC-123",
            cilindrada: 2500
        );

        // 2. MOTOCICLETA
        vehiculos[1] = new Vehiculo(
            marca: "HONDA",
            modelo: 2023,
            fechaRegistro: new DateTime(2023, 05, 15),
            tipo: "MOTOCICLETA",
            placa: "MOTO-456",
            cilindrada: 150
        );

        // 3. VAGONETA
        vehiculos[2] = new Vehiculo(
            marca: "NISSAN",
            modelo: 2018,
            fechaRegistro: new DateTime(2018, 01, 10),
            tipo: "VAGONETA",
            placa: "XYZ-789",
            cilindrada: 1600
        );

        // 4. CAMIONETA
        vehiculos[3] = new Vehiculo(
            marca: "FORD",
            modelo: 2022,
            fechaRegistro: new DateTime(2024, 02, 29),
            tipo: "CAMIONETA",
            placa: "DEF-001",
            cilindrada: 3000
        );

        // 5. MOTOCICLETA
        vehiculos[4] = new Vehiculo(
            marca: "SUZUKI",
            modelo: 2021,
            fechaRegistro: new DateTime(2021, 07, 07),
            tipo: "MOTOCICLETA",
            placa: "MOTO-999",
            cilindrada: 200
        );

        // --- 10 VEHÍCULOS ADICIONALES PARA ORDENAMIENTO ---

        // 6. VAGONETA
        vehiculos[5] = new Vehiculo(
            marca: "CHEVROLET",
            modelo: 2015,
            fechaRegistro: new DateTime(2015, 03, 01),
            tipo: "VAGONETA",
            placa: "GTR-007",
            cilindrada: 1400
        );

        // 7. CAMIONETA
        vehiculos[6] = new Vehiculo(
            marca: "MITSUBISHI",
            modelo: 2020,
            fechaRegistro: new DateTime(2020, 11, 25),
            tipo: "CAMIONETA",
            placa: "LND-111",
            cilindrada: 2800
        );

        // 8. MOTOCICLETA
        vehiculos[7] = new Vehiculo(
            marca: "YAMAHA",
            modelo: 2024,
            fechaRegistro: new DateTime(2024, 08, 10),
            tipo: "MOTOCICLETA",
            placa: "YMH-234",
            cilindrada: 350
        );

        // 9. VAGONETA
        vehiculos[8] = new Vehiculo(
            marca: "HYUNDAI",
            modelo: 2019,
            fechaRegistro: new DateTime(2019, 06, 17),
            tipo: "VAGONETA",
            placa: "HDA-555",
            cilindrada: 1800
        );

        // 10. CAMIONETA
        vehiculos[9] = new Vehiculo(
            marca: "DODGE",
            modelo: 2023,
            fechaRegistro: new DateTime(2023, 09, 01),
            tipo: "CAMIONETA",
            placa: "DGE-777",
            cilindrada: 4000
        );

        // 11. MOTOCICLETA
        vehiculos[10] = new Vehiculo(
            marca: "KAWASAKI",
            modelo: 2020,
            fechaRegistro: new DateTime(2020, 04, 04),
            tipo: "MOTOCICLETA",
            placa: "KWK-888",
            cilindrada: 450
        );

        // 12. VAGONETA
        vehiculos[11] = new Vehiculo(
            marca: "KIA",
            modelo: 2017,
            fechaRegistro: new DateTime(2017, 12, 12),
            tipo: "VAGONETA",
            placa: "KIA-321",
            cilindrada: 1600 // Duplicado en cilindrada
        );

        // 13. CAMIONETA
        vehiculos[12] = new Vehiculo(
            marca: "NISSAN",
            modelo: 2021,
            fechaRegistro: new DateTime(2021, 01, 01),
            tipo: "CAMIONETA",
            placa: "NSX-000",
            cilindrada: 2000
        );

        // 14. VAGONETA
        vehiculos[13] = new Vehiculo(
            marca: "RENAULT",
            modelo: 2024,
            fechaRegistro: new DateTime(2024, 05, 05),
            tipo: "VAGONETA",
            placa: "RNL-444",
            cilindrada: 1200
        );

        // 15. MOTOCICLETA
        vehiculos[14] = new Vehiculo(
            marca: "BMW",
            modelo: 2023,
            fechaRegistro: new DateTime(2023, 11, 11),
            tipo: "MOTOCICLETA",
            placa: "BMW-100",
            cilindrada: 900
        );


        // Console.Write("Cuantos vehiculos desea registrar?: ");
        // int numRegistros = int.Parse(Console.ReadLine());
        // Vehiculo[] vehiculos = new Vehiculo[numRegistros];
        // registrarVehiculo(vehiculos);

        mostrarListaRegistroGeneral(vehiculos);
        mostrarListaRegistroPorTipo(vehiculos);


    }



    private static void registrarVehiculo(Vehiculo[] vehiculos)
    {
        bool correcto;
        int cilindrada, modelo, tipoEleccion;
        string marca, tipo, placa;
        DateTime fechaRegistro;
        for (int i = 0; i < vehiculos.Length; i++)
        {
            Console.WriteLine($"\nIngrese los datos del vehiculo N° {i + 1}");

            Console.Write("\nMarca: ");
            marca = Console.ReadLine().ToUpper();
            do
            {
                Console.Write("Modelo: ");
                correcto = int.TryParse(Console.ReadLine(), out modelo);
                if (!correcto)
                {
                    Console.WriteLine("Ingresa un modelo valido");
                }
            } while (!correcto);
            do
            {
                Console.Write("Fecha de Registro (Dia/Mes/Año): ");
                correcto = DateTime.TryParse(Console.ReadLine(), out fechaRegistro);
                if (!correcto)
                {
                    Console.WriteLine("Ingresa una fecha valida");
                }
            } while (!correcto);
            do
            {
                Console.Write("Tipo (vagoneta(1), motocicleta(2), automóvil(3), camioneta(4)): ");
                correcto = int.TryParse(Console.ReadLine(), out tipoEleccion);
                if (correcto && tipoEleccion > 0 && tipoEleccion < 5)
                {
                    switch (tipoEleccion)
                    {
                        case 1:
                            tipo = "VAGONETA";
                            correcto = true;
                            break;
                        case 2:
                            tipo = "MOTOCICLETA";
                            correcto = true;
                            break;
                        case 3:
                            tipo = "AUTOMÓVIL";
                            correcto = true;
                            break;
                        case 4:
                            tipo = "CAMIONETA";
                            correcto = true;
                            break;
                        default:
                            correcto = false;
                            tipo = "";
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ingresa un tipo valido");
                    correcto = false;
                    tipo = "";
                }
            } while (!correcto);
            Console.Write("Placa: ");
            placa = Console.ReadLine().ToUpper();
            do
            {
                Console.Write("Cilindrada: ");
                correcto = int.TryParse(Console.ReadLine(), out cilindrada);
                if (!correcto)
                {
                    Console.WriteLine("Ingresa una cilindrada numerica valida");
                }
            } while (!correcto);

            vehiculos[i] = new Vehiculo(marca, modelo, fechaRegistro, tipo, placa, cilindrada);
        }
    }

    private static void mostrarListaRegistroGeneral(Vehiculo[] vehiculos)
    {

        ordenar(vehiculos);
        Console.WriteLine("\n\n\t\t--- LISTA DE VEHÍCULOS REGISTRADOS ---");

        Console.WriteLine($"\n{"Marca",10}{"Modelo",8}{"F. Reg.",15}{"Tipo",15}{"Placa",15}{"Cilindrada",15}");
        Console.WriteLine("==================================================================================");

        foreach (var vehiculo in vehiculos)
        {
            string fechaFormato = vehiculo.FechaRegistro.ToString("dd-MM-yyyy");
            Console.WriteLine($"{vehiculo.Marca,10}{vehiculo.Modelo,8}{fechaFormato,15}{vehiculo.Tipo,15}{vehiculo.Placa,15}{vehiculo.Cilindrada,15}");
        }
    }

    private static void mostrarListaRegistroPorTipo(Vehiculo[] vehiculos)
    {
        int tipoEleccion = 0;
        string? tipo = string.Empty;
        for (int i = 0; i < 4; i++)
        {
            tipoEleccion++;
            switch (tipoEleccion)
            {
                case 1:
                    tipo = "CAMIONETA";
                    break;
                case 2:
                    tipo = "MOTOCICLETA";
                    break;
                case 3:
                    tipo = "AUTOMÓVIL";
                    break;
                case 4:
                    tipo = "VAGONETA";
                    break;
            }

            Console.WriteLine($"\n\n\t\t\t--- LISTA DE VEHÍCULOS TIPO {tipo}---");
            Console.WriteLine($"\n{"Marca",10}{"Modelo",8}{"F. Reg.",15}{"Tipo",15}{"Placa",15}{"Cilindrada",15}");
            Console.WriteLine("==================================================================================");

            foreach (var vehiculo in vehiculos)
            {
                if (vehiculo.Tipo == tipo)
                {
                    string fechaFormato = vehiculo.FechaRegistro.ToString("dd-MM-yyyy");
                    Console.WriteLine($"{vehiculo.Marca,10}{vehiculo.Modelo,8}{fechaFormato,15}{vehiculo.Tipo,15}{vehiculo.Placa,15}{vehiculo.Cilindrada,15}");
                }
            }
        }
    }

    private static void intercambiar(ref Vehiculo vehiculo1, ref Vehiculo vehiculo2)
    {
        Vehiculo aux = vehiculo1;
        vehiculo1 = vehiculo2;
        vehiculo2 = aux;
    }

    private static void ordenar(Vehiculo[] vehiculos)
    {
        int limite = vehiculos.Length - 1;
        bool hayIntercambio;
        do
        {
            hayIntercambio = false;
            for (int i = 0; i < limite; i++)
            {

                if (vehiculos[i].Modelo < vehiculos[i + 1].Modelo)
                {
                    intercambiar(ref vehiculos[i], ref vehiculos[i + 1]);
                    hayIntercambio = true;
                }
            }
            limite--;
        } while (hayIntercambio);
    }




}
