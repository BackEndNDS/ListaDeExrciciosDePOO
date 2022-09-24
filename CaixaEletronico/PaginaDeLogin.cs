using CaixaEletronico.Entity;

namespace CaixaEletronico;

public static class PaginaDeLogin
{
    public static void Main(string[] args)
    {
        var usuarioList = new List<Usuario>();
        
        TelaInicial(usuarioList);
    }

    public static void TelaInicial(List<Usuario>? usuarioList)
    {
        Console.Clear();
        
        Console.WriteLine("===== Caixa eletrônico =====");
        Console.WriteLine("1- Acessar caixa");
        Console.WriteLine("2- Cadastrar novo usuário");
        Console.WriteLine("0- Exit");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 0: Environment.Exit(0); break;

            case 1:
            {
                if (usuarioList.Count == 0)
                {
                    Console.Clear();
                    
                    Console.WriteLine("\nO sistema deve conter ao menos um usuário para funcionar!");
                    
                    Thread.Sleep(3000);
                    
                    TelaInicial(usuarioList);
                }
                
                AcessarCaixa(usuarioList); 
                
            } break;
            
            case 2:
            {
                var usuario = new Usuario("", "");

                CadastrarUsuario(usuario);
                
                usuarioList.Add(usuario);
                
                Console.WriteLine("\nUsário cadastrado com sucesso");
                
                Thread.Sleep(3000);
                
                TelaInicial(usuarioList);
                
            } break;
            
            default: TelaInicial(usuarioList); break;
        }
    }

    public static Usuario CadastrarUsuario(Usuario usuario)
    {
        Console.Clear();
        
        Console.WriteLine("===== Cadastrar usuário =====");
        Console.WriteLine("Informe o seu nome: ");
        var nome = Console.ReadLine();
        Console.WriteLine("Informe uma senha: ");
        var senha = Console.ReadLine();

        usuario.Nome = nome;
        usuario.Senha = senha;

        if (usuario.Nome == string.Empty || usuario.Senha == string.Empty)
        {
            Console.WriteLine("\nUm ou mais campos estão inválidos! Por favor corrija-os");
            Thread.Sleep(3000);
            CadastrarUsuario(usuario);
        } 
        
        return usuario;
    }

    public static void AcessarCaixa(List<Usuario> usuarioList)
    {
        Console.Clear();

        var usuarioLogado = Login(usuarioList);
        
        Console.WriteLine("===== SysCaixa =====");
        Console.WriteLine("1- Depositar");
        Console.WriteLine("2- Sacar");
        Console.WriteLine("3- Verificar Saldo");
        Console.WriteLine("0- Voltar");
        
        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 0: TelaInicial(usuarioList); break;
            
            case 1:
            {
                Depositar(usuarioLogado);
                
                Console.WriteLine("\nValor depositado com sucesso!");

                var opcaoOperacao = ContinuarOperacao();

                if (opcaoOperacao == 1)
                {
                    AcessarCaixa(usuarioList);
                } 
                if (opcaoOperacao == 2)
                {
                    TelaInicial(usuarioList);
                }
                
            } break;
            
            case 2:
            {
                Sacar(usuarioLogado);
                
                Console.WriteLine("\nValor sacado com sucesso!");

                var opcaoOperacao = ContinuarOperacao();

                if (opcaoOperacao == 1)
                {
                    AcessarCaixa(usuarioList);
                } 
                if (opcaoOperacao == 2)
                {
                    TelaInicial(usuarioList);
                }
            } break;

            case 3:
            {
                VerificarSaldo(usuarioLogado);
                
                var opcaoOperacao = ContinuarOperacao();

                if (opcaoOperacao == 1)
                {
                    AcessarCaixa(usuarioList);
                } 
                if (opcaoOperacao == 2)
                {
                    TelaInicial(usuarioList);
                }
                
            } break;
            
            default: AcessarCaixa(usuarioList); break;
        }
    }

    public static Usuario Depositar(Usuario usuario)
    {
        Console.Clear();
        
        Console.WriteLine("===== Depositar =====");
        Console.WriteLine("Informe o valor a ser depositado: ");
        decimal valor = decimal.Parse(Console.ReadLine());

        if (valor < 0 || valor.ToString() == string.Empty)
        {
            Console.WriteLine("\nO valor inserido não pode ser nulo ou negativo! Por favor tente novamente");
            
            Thread.Sleep(3000);
            
            Depositar(usuario);
        }

        usuario.Saldo = usuario.Saldo + valor;
        
        Console.WriteLine($"\nSaldo atual: {usuario.Saldo}");
        
        Thread.Sleep(3000);

        return usuario;
    }

    public static Usuario Sacar(Usuario usuario)
    {
        Console.Clear();
        
        Console.WriteLine("===== Sacar =====");
        Console.WriteLine("Informe um valor a ser sacado: ");
        decimal valor = decimal.Parse(Console.ReadLine());

        if (valor < 0 || valor.ToString() == string.Empty)
        {
            Console.WriteLine("\nO valor inserido não pode ser nulo ou negativo! Por favor tente novamente");
            
            Thread.Sleep(3000);
            
            Sacar(usuario);
        }

        if (valor > usuario.Saldo)
        {
            Console.WriteLine("\nVocê não tem saldo o suficiente para concluir a operação! Por favor tente novamente");
            
            Thread.Sleep(3000);
            
            Sacar(usuario);
        }

        usuario.Saldo = usuario.Saldo - valor;
        
        Console.WriteLine($"\nSaldo atual: {usuario.Saldo}");
        
        Thread.Sleep(3000);

        return usuario;
    }

    public static void VerificarSaldo(Usuario usuario)
    {
        Console.Clear();
        
        Console.WriteLine("===== Veerificar saldo =====");
        Console.WriteLine("Usuario: ");
        var nomeUsuario = Console.ReadLine();
        Console.WriteLine("Senha: ");
        var senha = Console.ReadLine();

        if (nomeUsuario != usuario.Nome || senha != usuario.Senha)
        {
            Console.WriteLine("\nUm ou mais campos estão incorretos! Por favor corrija-os");
            
            Thread.Sleep(3000);

            VerificarSaldo(usuario);
        }
        
        Console.WriteLine($"\nSaldo atual: {usuario.Saldo}");
        
        Thread.Sleep(3000);
    }

    public static Usuario Login(List<Usuario> usuarioList)
    {
        Console.Clear();
        
        Console.WriteLine("===== Login =====");
        Console.WriteLine("Usuario: ");
        var nome = Console.ReadLine();
        Console.WriteLine("Senha: ");
        var senha = Console.ReadLine();

        var usuarioExistente = usuarioList.Find(u => u.Nome == nome && u.Senha == senha);

        if (usuarioExistente == null)
        {
            Console.WriteLine("\nUm ou mais campos estão errados! Por favor tente novamente");
            
            Thread.Sleep(3000);
            
            Login(usuarioList);
        }

        Console.WriteLine($"\nBem vindo {usuarioExistente!.Nome}!");
        
        Thread.Sleep(3000);
        
        Console.Clear(); 
        
        return usuarioExistente;
    }

    public static int ContinuarOperacao()
    {
        Console.Clear();
        
        Console.WriteLine("Deseja continuar a operação?");
        Console.WriteLine("1- Sim");
        Console.WriteLine("2- Não");
        int opcao = int.Parse(Console.ReadLine());

        if (opcao < 1 || opcao > 2 )
        {
            Console.WriteLine("\nPor favor informe um valor válido!");
            ContinuarOperacao();
        }
        return opcao;
    }
}