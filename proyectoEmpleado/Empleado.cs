class Empleado
{
    public uint Ci { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }


    public Empleado(uint ci, string nombre, DateTime fechaNacimiento)
    {
        Ci = ci;
        Nombre = nombre;
        FechaNacimiento = fechaNacimiento;
    }
}