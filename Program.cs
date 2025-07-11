using ScreenSound;

string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound";

Dictionary<int, Banda> conjuntoBandas = new Dictionary<int, Banda>();

void ExibirLogo()
{
    Console.WriteLine(@"
    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();

    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

}
int opcao;

do
{

    ExibirOpcoesDoMenu();
    Console.Write("\nDigite a sua opção: ");
    opcao = int.Parse(Console.ReadLine()!);

    string nomeBanda;

    switch (opcao)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            MostrarBandas();
            break;
        case 3:
            ExibeNomesBandas();
            try
            {
                Console.Write("Informe o nome da banda que deseja avaliar: ");
                nomeBanda = Console.ReadLine();
                Banda bandaEscolhida = RetornaBandaPeloNome(nomeBanda);
                AvaliaBanda(bandaEscolhida);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            break;
        case 4:
            ExibeNomesBandas();
            try
            {
                Console.Write("Informe o nome da banda que deseja saber a média de notas: ");
                nomeBanda = Console.ReadLine()!;
                Banda bandaEscolhida = RetornaBandaPeloNome(nomeBanda);
                ExibeMediaBanda(bandaEscolhida);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            break;
        case -1:
            Console.WriteLine("Saindo do sistema");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;

    }
} while (opcao != -1);

void RegistrarBanda()
{
    Console.Clear();
    ExibeTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    Banda banda = new Banda(nomeDaBanda);
    int codigo = banda.GetHashCode();
    conjuntoBandas.Add(codigo, banda);
    Console.WriteLine($"A banda {nomeDaBanda} foi registada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
}

void MostrarBandas()
{
    Console.Clear();
    foreach (Banda banda in conjuntoBandas.Values)
    {
        Console.WriteLine(banda);
    }

    Thread.Sleep(3000);
    Console.Clear();
}

void ExibeNomesBandas()
{
    Console.Clear();
    ExibeTituloDaOpcao("Exibindo todas as bandas cadastradas");
    foreach (Banda banda in conjuntoBandas.Values)
    {
        Console.WriteLine(banda.getNome());
    }
    Console.WriteLine();
}

void AvaliaBanda(Banda banda)
{
    if (banda == null)
        throw new ArgumentNullException("Banda não cadastrada no sistema");

    try
    {

        Console.Write($"Informe a nota que deseja dar para {banda.getNome()}: ");
        double nota = double.Parse(Console.ReadLine());
        banda.AvaliarBanda(nota);
        Console.WriteLine("Nota inserida com sucesso!");
    }
    catch (FormatException e)
    {
        Console.WriteLine("Formato de nota inválido");
    }
    finally
    {
        Thread.Sleep(2000);
        Console.Clear();
    }

}

void ExibeMediaBanda(Banda banda)
{
    if (banda == null)
        throw new ArgumentNullException("Banda não cadastrada no sistema");

    ExibeTituloDaOpcao("Exibindo média da banda selecionada");

    Console.WriteLine($"A média da banda {banda.getNome()} é: {banda.RetornaMedia().ToString("F2")}");

    Thread.Sleep(3000);
    Console.Clear();
}

Banda RetornaBandaPeloNome(string nomeBanda)
{
    foreach (Banda banda in conjuntoBandas.Values)
    {
        if (nomeBanda.Equals(banda.getNome()))
        {
            return banda;
        }
    }
    return null;
}

void ExibeTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");

}
