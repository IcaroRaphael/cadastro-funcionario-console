List<Dictionary<string, string>> funcionarios = new List<Dictionary<string, string>>();

bool executa = true;
while (executa)
{
    try
    {
        MostrarOpcoes();
        Console.Write("Escolha: ");
        int escolha = int.Parse(Console.ReadLine());
        switch (escolha)
        {
            case 1:
                CadastrarFuncionario();
                break;
            case 2:
                Console.WriteLine("Visualizando funcionarios");
                break;
            case 3:
                Console.WriteLine("Atualizando funcionario");
                break;
            case 4:
                Console.WriteLine("Deletando funcionario");
                break;
            case 5:
                executa = false;
                break;
            default:
                Console.WriteLine("OPÇÃO INVÁLIDA!");
                break;
        }
    }
    catch(Exception e)
    {
        Console.WriteLine("Opção Inválida");
    }
    Console.ReadKey();
}

void MostrarOpcoes()
{
    Console.Clear();
    Console.WriteLine("## Cadastro de Funcionário ##\n");
    Console.WriteLine("1 - Cadastrar Funcionário");
    Console.WriteLine("2 - Visualizar Funcionários");
    Console.WriteLine("3 - Atualizar Funcionário");
    Console.WriteLine("4 - Deletar Funcionário");
    Console.WriteLine("5 - Sair do Programa");
}

void CadastrarFuncionario()
{
    Console.Clear();
    Console.WriteLine("## Cadastrando Funcionário ##");

    Console.WriteLine("Insira os dados do Funcionário");
    Console.Write("CPF (xxx.xxx.xxx-xx): ");
    string cpf = Console.ReadLine();
    if (Util.VerificarCpfCadastrado(funcionarios, cpf))
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Cargo: ");
        string cargo = Console.ReadLine();
        string salario = Util.VerificarSalario();
        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();
        Console.WriteLine("FUNCIONÁRIO CADASTRADO COM SUCESSO!");
        funcionarios.Add(new Dictionary<string, string>{
            {"CPF", cpf},
            {"NOME", nome},
            {"CARGO", cargo},
            {"SALARIO", salario},
            {"TELEFONE", telefone}
            });
    }
    else
    {
        Console.WriteLine("CPF JÁ CADASTRADO!");
    }
}