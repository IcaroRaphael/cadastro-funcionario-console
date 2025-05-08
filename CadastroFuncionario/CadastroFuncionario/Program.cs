using System.Text.RegularExpressions;

List<Dictionary<string, string>> funcionarios = new List<Dictionary<string, string>>();

bool executa = true;
while (executa)
{
    int escolha = Menu();
    switch (escolha)
    {
        case 1:
            CadastrarFuncionario();
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
            Console.ReadKey();
            break;
        case 2:
            VisualizarFuncionarios();
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
            Console.ReadKey();
            break;
        case 3:
            AtualizarFuncionario();
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
            Console.ReadKey();
            break;
        case 4:
            DeletarFuncionario();
            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu...");
            Console.ReadKey();
            break;
        case 5:
            Console.WriteLine("\nPressione qualquer tecla sair do programa...");
            Console.ReadKey();
            Console.WriteLine("Finalizando programa...");
            executa = false;
            break;
        default:
            Console.WriteLine("OPÇÃO INVÁLIDA.");
            Console.WriteLine("\nPressione qualquer tecla para tentar novamente...");
            Console.ReadKey();
            break;
    }
}


void CadastrarFuncionario()
{
    Console.Clear();
    Console.WriteLine("## CADASTRANDO FUNCIONÁRIO ##\n");
    if (ConfirmaEscolha())
    {
        string nome = ValidarNome();
        string cargo = ValidarCargo();
        string salario = ValidarSalario();
        funcionarios.Add(new Dictionary<string, string>{
            {"NOME", nome},
            {"CARGO", cargo},
            {"SALARIO", salario}
            });
    }
    else
    {
        Console.WriteLine("CADASTRO CANCELADO.");
    }
}

void VisualizarFuncionarios()
{
    Console.Clear();
    if (funcionarios.Count > 0)
    {
        Console.WriteLine("## VISUALIZANDO FUNCIONÁRIOS ##\n");
        Console.WriteLine("----------");
        for (int i = 0; i < funcionarios.Count; i++)
        {
            Console.WriteLine($"ID: {i}");
            foreach (var campo in funcionarios[i])
            {
                Console.WriteLine($"{campo.Key}: {campo.Value}");
            }
            Console.WriteLine("----------");
        }
    }
    else
    {
        Console.WriteLine("NENHUM FUNCIONÁRIO CADASTRADO.");
    }
}

void AtualizarFuncionario()
{
    Console.Clear();
    if (funcionarios.Count > 0)
    {
        Console.WriteLine("\n## ATUALIZANDO FUNCIONÁRIO ##");
        if (ConfirmaEscolha())
        {
            VisualizarFuncionarios();
            Console.WriteLine("\n## ATUALIZANDO FUNCIONÁRIO ##");
            int id = ValidarId();

            bool executaAtualizarFuncionario = true;
            while (executaAtualizarFuncionario)
            {
                int escolha = MenuAtualizar();
                switch (escolha)
                {
                    case 1:
                        funcionarios[id]["NOME"] = ValidarNome();
                        Console.WriteLine("NOME ATUALIZADO COM SUCESSO.");
                        executaAtualizarFuncionario = false;
                        break;
                    case 2:
                        funcionarios[id]["CARGO"] = ValidarCargo();
                        Console.WriteLine("CARGO ATUALIZADO COM SUCESSO.");
                        executaAtualizarFuncionario = false;
                        break;
                    case 3:
                        funcionarios[id]["SALARIO"] = ValidarSalario();
                        Console.WriteLine("SALARIO ATUALIZADO COM SUCESSO.");
                        executaAtualizarFuncionario = false;
                        break;
                    default:
                        Console.WriteLine("OPÇÃO INVÁLIDA.");
                        Console.WriteLine("\nPressione qualquer tecla para tentar novamente...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("ATUALIZAÇÃO CANCELADA.");
        }
    }
    else
    {
        Console.WriteLine("NENHUM FUNCIONÁRIO CADASTRADO.");
    }
}

void DeletarFuncionario()
{
    Console.Clear();
    if (funcionarios.Count > 0)
    {
        Console.WriteLine("\n## DELETANDO FUNCIONÁRIO ##");
        if (ConfirmaEscolha())
        {
            VisualizarFuncionarios();
            Console.WriteLine("\n## DELETANDO FUNCIONÁRIO ##");
            int id = ValidarId();
            funcionarios.RemoveAt(id);
            Console.WriteLine("FUNCIONÁRIO DELETADO COM SUCESSO.");
        }
        else
        {
            Console.WriteLine("DELEÇÃO CANCELADA.");
        }
    }
    else
    {
        Console.WriteLine("NENHUM FUNCIONÁRIO CADASTRADO.");
    }
}

int Menu()
{
    int num = 0;
    Console.Clear();
    Console.WriteLine("## Cadastro de Funcionário ##\n");
    Console.WriteLine("1 - Cadastrar Funcionário");
    Console.WriteLine("2 - Visualizar Funcionários");
    Console.WriteLine("3 - Atualizar Funcionário");
    Console.WriteLine("4 - Deletar Funcionário");
    Console.WriteLine("5 - Sair do Programa");
    Console.Write("Escolha: ");
    if (int.TryParse(Console.ReadLine(), out num))
    {
        return num;
    }
    return num;
}

int MenuAtualizar()
{
    int num = 0;
    Console.Clear();
    Console.WriteLine("ESCOLHA O CAMPO QUE DESEJA ATUALIZAR");
    Console.WriteLine("1 - NOME");
    Console.WriteLine("2 - CARGO");
    Console.WriteLine("3 - SALARIO");
    Console.Write("Escolha: ");
    if (int.TryParse(Console.ReadLine(), out num))
    {
        return num;
    }
    return num;
}

int ValidarId()
{
    int id;
    while (true)
    {
        Console.Write("ID: ");
        if (int.TryParse(Console.ReadLine(), out id))
        {
            if (id >= 0 && id < funcionarios.Count)
            {
                return id;
            }
            else
            {
                Console.WriteLine("ID NÃO EXISTE. POR FAVOR INSIRA NOVAMENTE.");
            }
        }
        else
        {
            Console.WriteLine("ID PRECISA SER UM NÚMERO INTEIRO. POR FAVOR INSIRA NOVAMENTE.");
        }
    }
}

string ValidarSalario()
{
    double salarioValidado = 0;
    bool executarValidarSalario = true;
    while (executarValidarSalario)
    {
        Console.Write("SALARIO: ");
        if (double.TryParse(Console.ReadLine(), out salarioValidado))
        {
            executarValidarSalario = false;
        }
        else
        {
            Console.WriteLine("INSIRA APENAS NÚMEROS.");
        }
    }
    return string.Format($"{salarioValidado:C}");
}

string ValidarNome()
{
    while (true)
    {
        Console.Write("NOME: ");
        string nome = Console.ReadLine();
        string pegaNumeros = new Regex(@"[^\d]").Replace(nome, @"");
        string nomeSemEspaco = nome.Replace(" ", "");

        if (pegaNumeros.Length == 0)
        {
            if (nomeSemEspaco.Length >= 3)
            {
                return nome;
            }
            else
            {
                Console.WriteLine("NOME PRECISA POSSUIR AO MENOS 3 LETRAS.");
            }
        }
        else
        {
            Console.WriteLine("NOME NÃO PODE POSSUIR NÚMEROS.");
        }
    }
}

string ValidarCargo()
{
    while (true)
    {
        Console.Write("CARGO: ");
        string cargo = Console.ReadLine();
        string pegaNumeros = new Regex(@"[^\d]").Replace(cargo, @"");
        string cargoSemEspaco = cargo.Replace(" ", "");

        if (pegaNumeros.Length == 0)
        {
            if (cargoSemEspaco.Length >= 3)
            {
                return cargo;
            }
            else
            {
                Console.WriteLine("CARGO PRECISA POSSUIR AO MENOS 3 LETRAS.");
            }
        }
        else
        {
            Console.WriteLine("CARGO NÃO PODE POSSUIR NÚMEROS.");
        }
    }
}

bool ConfirmaEscolha()
{
    Console.Write("DESEJA REALMENTE CONTINUAR? [\"SIM\" para continuar]: ");
    string escolha = Console.ReadLine().ToUpper();
    if (escolha == "SIM")
    {
        return true;
    }
    return false;
}
