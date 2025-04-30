using System;

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
    Console.Write("CPF: ");
    string cpf = Console.ReadLine();
    if (!CpfExiste(cpf))
    {
        Console.Write("NOME: ");
        string nome = Console.ReadLine();
        Console.Write("CARGO: ");
        string cargo = Console.ReadLine();
        string salario = ValidarSalario();
        Console.Write("TELEFONE: ");
        string telefone = Console.ReadLine();
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
        Console.WriteLine("CPF JÁ CADASTRADO.");
    }
}

void VisualizarFuncionarios()
{
    Console.Clear();
    Console.WriteLine("## VISUALIZANDO FUNCIONÁRIOS ##\n");
    if (funcionarios.Count == 0)
    {
        Console.WriteLine("NENHUM FUNCIONÁRIO CADASTRADO.");
    }
    else
    {
        Console.WriteLine("----------");
        foreach (var funcionario in funcionarios)
        {
            foreach (var campo in funcionario)
            {
                Console.WriteLine($"{campo.Key}: {campo.Value}");
            }
            Console.WriteLine("----------");
        }
    }
}

void AtualizarFuncionario()
{
    Console.Clear();
    Console.WriteLine("## ATUALIZANDO FUNCIONÁRIO ##\n");
    if (funcionarios.Count == 0)
    {
        Console.WriteLine("NENHUM FUNCIONÁRIO CADASTRADO.");
    }
    else
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();
        
        if (CpfExiste(cpf))
        {
            foreach(var funcionario in funcionarios)
            {
                if (funcionario["CPF"] == cpf)
                {
                    bool executar2 = true;
                    while (executar2)
                    {
                        int escolha = MenuAtualizar();
                        switch (escolha)
                        {
                            case 1:
                                Console.Write("NOME: ");
                                string nomeAtualizado = Console.ReadLine();
                                funcionario["NOME"] = nomeAtualizado;
                                Console.WriteLine("NOME ATUALIZADO COM SUCESSO.");
                                executar2 = false;
                                break;
                            case 2:
                                Console.Write("CARGO: ");
                                string cargoAtualizado = Console.ReadLine();
                                funcionario["CARGO"] = cargoAtualizado;
                                Console.WriteLine("CARGO ATUALIZADO COM SUCESSO.");
                                executar2 = false;
                                break;
                            case 3:
                                funcionario["SALARIO"] = ValidarSalario();
                                Console.WriteLine("SALARIO ATUALIZADO COM SUCESSO.");
                                executar2 = false;
                                break;
                            case 4:
                                Console.Write("TELEFONE: ");
                                string telefoneAtualizado = Console.ReadLine();
                                funcionario["TELEFONE"] = telefoneAtualizado;
                                Console.WriteLine("TELEFONE ATUALIZADO COM SUCESSO.");
                                executar2 = false;
                                break;
                            default:
                                Console.WriteLine("OPÇÃO INVÁLIDA.");
                                Console.WriteLine("\nPressione qualquer tecla para tentar novamente...");
                                Console.ReadKey();
                                break;
                        }
                    }
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("CPF NÃO ENCONTRADO.");
        }
    }
}

void DeletarFuncionario()
{
    Console.Clear();
    Console.WriteLine("## DELETANDO FUNCIONÁRIO ##\n");
    if (funcionarios.Count == 0)
    {
        Console.WriteLine("NENHUM FUNCIONÁRIO CADASTRADO.");
    }
    else
    {
        Console.Write("CPF: ");
        string cpf = Console.ReadLine();
        if (CpfExiste(cpf))
        {
            foreach(var funcionario in funcionarios)
            {
                if (funcionario["CPF"] == cpf)
                {
                    funcionarios.Remove(funcionario);
                    Console.WriteLine("FUNCIONÁRIO DELETADO COM SUCESSO.");
                    break;
                }
            }
        }
        else
        {
            Console.WriteLine("CPF NÃO ENCONTRADO.");
        }
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
    Console.WriteLine("4 - TELEFONE");
    Console.Write("Escolha: ");
    if (int.TryParse(Console.ReadLine(), out num))
    {
        return num;
    }
    return num;
}

bool CpfExiste(string cpf)
{
    int contCpf = 0;
    foreach(var funcionario in funcionarios)
    {
        if(funcionario["CPF"] == cpf)
        {
            contCpf++;
            break;
        }
    }
    if(contCpf == 0)
    {
        return false;
    }
    else
    {
        return true;
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
    return string.Format($"R${salarioValidado:F2}");
}

// Em Desenvolvimento
string ValidarTelefone()
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
    return string.Format($"R${salarioValidado:F2}");
}