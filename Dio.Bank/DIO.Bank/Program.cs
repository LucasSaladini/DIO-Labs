using DIO.Bank.Conta;
using DIO.Bank.Enum;

List<Conta> listaContas = new List<Conta>();

string opcaoUsuario = ObterOpcaoUsuario();

while (opcaoUsuario.ToUpper() != "X")
{
    switch(opcaoUsuario)
    {
        case "1":
            ListarContas();
            break;
        case "2":
            InserirConta();
            break;
        case "3":
            Transferir();
            break;
        case "4":
            Sacar();
            break;
        case "5":
            Depositar();
            break;
        case "6":
            Poupanca();
            break;
        case "C":
            Console.Clear();
            break;
        default:
            throw new ArgumentOutOfRangeException();
    }
    
    opcaoUsuario = ObterOpcaoUsuario();
}

void Poupanca()
{
    Console.WriteLine("Digite o número da conta: ");
    int indiceConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor dos juros em porcentagem: ");
    double juros = double.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor do saldo: ");
    double saldo = double.Parse(Console.ReadLine());

    listaContas[indiceConta].JurosPoupanca(juros, saldo);
}

void Transferir()
{
    Console.WriteLine("Digite o número da conta de origem: ");
    int indiceContaOrigem = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o número da conta de destino: ");
    int indiceContaDestino = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser transferido: ");
    double valorTransferencia = double.Parse(Console.ReadLine());

    listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
}

void Depositar()
{
    Console.WriteLine("Digite o número da conta: ");
    int indiceConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Dgite o valor a ser depositado: ");
    double valorDeposito = double.Parse(Console.ReadLine());

    listaContas[indiceConta].Depositar(valorDeposito);
}

void Sacar()
{
    Console.WriteLine("Digite o número da conta: ");
    int indiceConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o valor a ser sacado: ");
    double ValorSaque = double.Parse(Console.ReadLine());

    listaContas[indiceConta].Sacar(ValorSaque);
}

void ListarContas()
{
    Console.WriteLine("Listar contas");

    if(listaContas.Count == 0)
    {
        Console.WriteLine("Não há contas para serem listadas");
        return;
    }

    for (int i = 0; i < listaContas.Count; i++)
    {
        Conta conta = listaContas[i];
        Console.WriteLine("#{0} - ", i);
        Console.WriteLine(conta);
    }
}

void InserirConta()
{
    Console.WriteLine("Inserir nova conta");

    Console.WriteLine("Digite 1 para Conta Pessoa Física, 2 para Pessoa Jurídica ou 3 para Poupança");
    int entradaTipoConta = int.Parse(Console.ReadLine());

    Console.WriteLine("Digite o nome do cliente: ");
    string entradaNome = Console.ReadLine();

    Console.WriteLine("Digite o saldo inicial: ");
    double entradaSaldo = double.Parse(Console.ReadLine());

    Console.WriteLine("Digite o crédito inicial: ");
    double entradaCredito = double.Parse(Console.ReadLine());

    Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                saldo: entradaSaldo,
                                credito: entradaCredito,
                                nome: entradaNome);

    listaContas.Add(novaConta);
}

Console.WriteLine("Obrigado por utilizar nossos serviços.");
Console.ReadLine();

static string ObterOpcaoUsuario()
{
    Console.WriteLine();
    Console.WriteLine("DIO Banka ao seu dispor");
    Console.WriteLine("Informe a opção desejada:");

    Console.WriteLine("1 - Listar contas");
    Console.WriteLine("2 - Inserir nova conta");
    Console.WriteLine("3 - Transferir");
    Console.WriteLine("4 - Sacar");
    Console.WriteLine("5 - Depositar");
    Console.WriteLine("6 - Poupança");
    Console.WriteLine("C - Limpar Tela");
    Console.WriteLine("X - Sair");
    Console.WriteLine();

    string opcaoUsuario = Console.ReadLine().ToUpper();
    Console.WriteLine();
    return opcaoUsuario;
}