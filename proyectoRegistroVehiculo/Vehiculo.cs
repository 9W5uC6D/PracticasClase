class Vehiculo
{
    public string? Marca { get; set; }
    public int Modelo { get; set; }
    public DateTime FechaRegistro { get; set; }
    public string? Tipo { get; set; }
    public string? Placa { get; set; }
    public int Cilindrada { get; set; }

    public Vehiculo(string marca, int modelo, DateTime fechaRegistro, string tipo, string placa, int cilindrada)
    {
        Marca = marca;
        Modelo = modelo;
        FechaRegistro = fechaRegistro;
        Tipo = tipo;
        Placa = placa;
        Cilindrada = cilindrada;
    }


}