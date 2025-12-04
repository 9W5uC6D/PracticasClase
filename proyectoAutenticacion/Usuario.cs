class Usuario
{
    public string Nick { set; get; }
    public string Password { set; get; }
    public List<Rol> ListaDeRol { set; get; }
    public Usuario(string nick, string password)
    {
        Nick = nick;
        Password = password;
        ListaDeRol = new List<Rol>();
    }
}