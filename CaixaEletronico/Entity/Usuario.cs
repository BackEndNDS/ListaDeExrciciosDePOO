namespace CaixaEletronico.Entity;

public class Usuario
{
    public Usuario(string nome, string senha, decimal saldo = 0)
    {
        Nome = nome;
        Senha = senha;
        Saldo = saldo;
        Usuarios = new List<Usuario>();
    }
    
    public string Nome { get; set; }
    public string Senha { get; set; }
    public decimal Saldo { get; set; }
    public List<Usuario> Usuarios { get; set; }
}