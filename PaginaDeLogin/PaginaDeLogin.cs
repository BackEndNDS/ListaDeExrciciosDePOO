using PaginaDeLogin.Entities;

namespace PaginaDeLogin;

public static class PaginaDeLogin
{
    public static void Main(string[] args)
    {
        var usuarios = new List<Usuario>();
        
        TelaInicial(usuarios);
    }

    public static void TelaInicial(List<Usuario> usuarios)
    {
        Console.Clear();
        
        Console.WriteLine("===== Pagina de Login =====");
        Console.WriteLine("1- Login");
        Console.WriteLine("2- Signin");
        Console.WriteLine("0- Sair");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
            {
                Login(usuarios);
            } break;
            
            case 2:
            {
                var usuario = new Usuario("", "");

                usuario = Signin(usuario);
                
                usuarios.Add(usuario);
                
                Console.WriteLine("\nUsuário cadastrado com sucesso!");
                
                Thread.Sleep(3000);
                
                TelaInicial(usuarios);
            } break;
            
            case 0: System.Environment.Exit(0); break;
                
            default: TelaInicial(usuarios); break;
        }
    }

    public static void Login(List<Usuario> usuarios)
    {
        Console.Clear();
        
        if (usuarios.Count == 0)
        {
            Console.WriteLine("O sistema deve conter ao menos um usuário para funcioar!");
            Thread.Sleep(3000);
            TelaInicial(usuarios);
        }

        Console.WriteLine("===== Login =====");
        Console.WriteLine("Nome: ");
        var nome = Console.ReadLine();
        Console.WriteLine("Senha: ");
        var senha = Console.ReadLine();

        var usuario = usuarios.Find(u => u.Nome == nome && u.Senha == senha);

        if (usuario != null)
        {
            Console.WriteLine($"Bem vindo {usuario.Nome}!");
            Thread.Sleep(3000);
            return;
        }
        Console.WriteLine("\nUm ou mais campos estão incorretos! Por favor corrija-os");
        Thread.Sleep(3000);
        Login(usuarios);
    }

    public static Usuario Signin(Usuario usuario)
    {
        Console.Clear();
        
        Console.WriteLine("===== Signin =====");
        Console.WriteLine("Nome: ");
        usuario.Nome = Console.ReadLine();
        Console.WriteLine("Senha: ");
        usuario.Senha = Console.ReadLine();

        if (usuario.Nome == string.Empty || usuario.Senha == string.Empty)
        {
            Console.WriteLine("\nUm ou mais campos estão incorretos! Por favor corrija-os");
            Thread.Sleep(3000);
            Signin(usuario);
        }

        return usuario;
    }
}