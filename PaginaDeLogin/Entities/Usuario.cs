using System.Security.Cryptography;

namespace PaginaDeLogin.Entities;

public class Usuario
{
    public Usuario(string name, string senha)
    {
        Nome = name;
        Senha = senha;
        List<Usuario> usuarios = new List<Usuario>();
    }

    public string Nome { get; set; }
    public string Senha { get; set; }
}