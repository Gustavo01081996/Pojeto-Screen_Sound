using ScreenSound;
using System.Globalization;

string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound";

Dictionary<int, Artista> conjuntoDeArtistas = new Dictionary<int, Artista>();

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

    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para mostrar todos os artistas");
    Console.WriteLine("Digite 3 para avaliar um artista");
    Console.WriteLine("Digite 4 para exibir a média de um artista");
    Console.WriteLine("Digite 5 para cadastrar uma música");
    Console.WriteLine("Digite 6 para exibir as músicas de um determinado artista");
    Console.WriteLine("Digite -1 para sair");

}
int opcao;

do
{

    ExibirOpcoesDoMenu();
    Console.Write("\nDigite a sua opção: ");
    opcao = int.Parse(Console.ReadLine()!);

    string nomeArtista;
    Artista artistaEscolhido;

    switch (opcao)
    {
        case 1:
            RegistrarArtista();
            break;
        case 2:
            MostrarArtistas();
            break;
        case 3:
            ExibeNomesArtistas();
            try
            {
                Console.Write("Informe o nome do artista que deseja avaliar: ");
                nomeArtista = Console.ReadLine()!;
                artistaEscolhido = RetornaArtistaPeloNome(nomeArtista);
                AvaliaArtista(artistaEscolhido);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            break;
        case 4:
            ExibeNomesArtistas();
            try
            {
                Console.Write("Informe o nome do artista que deseja saber a média de notas: ");
                nomeArtista = Console.ReadLine()!;
                artistaEscolhido = RetornaArtistaPeloNome(nomeArtista);
                ExibeMediaBanda(artistaEscolhido);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            break;
            case 5:
            ExibeNomesArtistas();
            Console.Write("Para qual artista deseja adicionar a música? ");
            string nome = Console.ReadLine()!;
            artistaEscolhido = RetornaArtistaPeloNome(nome);
            AdicionarMusica(artistaEscolhido);
            break;
            case 6:
            ExibeNomesArtistas();
            Console.Write("De qual artista deseja ver as músicas? ");
            nome = Console.ReadLine()!;
            artistaEscolhido = RetornaArtistaPeloNome(nome);
            ExibeMusicaArtista(artistaEscolhido);
            break;
        case -1:
            Console.WriteLine("Saindo do sistema");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;

    }
} while (opcao != -1);

void RegistrarArtista()
{
    Console.Clear();
    ExibeTituloDaOpcao("Registro dos artistas");
    Console.Write("Digite o nome do artista que deseja registrar: ");
    string nomeArtista = Console.ReadLine()!;
    Artista artista = new Artista(nomeArtista);
    int codigo = artista.GetHashCode();
    conjuntoDeArtistas.Add(codigo, artista);
    Console.WriteLine($"O(a) {nomeArtista} foi registado(a3) com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
}

void MostrarArtistas()
{
    Console.Clear();
    foreach (Artista artista in conjuntoDeArtistas.Values)
    {
        Console.WriteLine(artista.ToString());
    }

    Thread.Sleep(3000);
    Console.Clear();
}

void ExibeNomesArtistas()
{
    Console.Clear();
    ExibeTituloDaOpcao("Exibindo todos os artistas cadastrados");
    foreach (Artista artista in conjuntoDeArtistas.Values)
    {
        Console.WriteLine(artista.getNome());
    }
    Console.WriteLine();
}

void AvaliaArtista(Artista artista)
{
    if (artista == null)
        throw new ArgumentNullException("Artista não cadastrada no sistema");

    try
    {

        Console.Write($"Informe a nota que deseja dar para {artista.getNome()}: ");
        double nota = double.Parse(Console.ReadLine()!);
        artista.AvaliarArtista(nota);
        Console.WriteLine("Nota inserida com sucesso!");
    }
    catch (FormatException e)
    {
        Console.WriteLine("Erro: " + e.Message);
    }
    finally
    {
        Thread.Sleep(2000);
        Console.Clear();
    }

}

void ExibeMediaBanda(Artista artista)
{
    if (artista == null)
        throw new ArgumentNullException("Artista não cadastrado no sistema");

    ExibeTituloDaOpcao("Exibindo média do artista selecionado");

    Console.WriteLine($"A média da banda {artista.getNome()} é: {artista.RetornaMedia().ToString("F2")}");

    Thread.Sleep(3000);
    Console.Clear();
}

void AdicionarMusica(Artista artista) 
{
    if (artista == null)
        throw new ArgumentNullException("Artista não cadastrado no sistema");

    bool disponivel = false;
    Console.Write("Qual o nome da música? ");
    string nome = Console.ReadLine()!;
    Console.Write("Qual a duração da musica? (mm:ss)? ");
    TimeOnly duracao = TimeOnly.ParseExact(Console.ReadLine()!, "mm\\:ss", CultureInfo.InvariantCulture);
    Console.Write("Essa música já está disponível (s/n)? ");
    char disponibilidade = Console.ReadLine()!.ToLower().ElementAt(0);
    if (disponibilidade == 's') 
    {
        disponivel = true;  
    }

    artista.AdicionarMusicaAoArtista(new Musica(nome, artista, duracao, disponivel));
    Console.WriteLine("Música cadastrada com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();

}

Artista RetornaArtistaPeloNome(string nomeArtista)
{
    foreach (Artista artista in conjuntoDeArtistas.Values)
    {
        if (nomeArtista.Equals(artista.getNome()))
        {
            return artista;
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

void ExibeMusicaArtista(Artista artista) 
{
    List<Musica> musicas = conjuntoDeArtistas[artista.GetHashCode()].RetornaListaDeMusicas;
    Console.WriteLine($"Artista: {artista.getNome()}");
    foreach (Musica musica in musicas) 
    {
        Console.WriteLine(musica.ToString());
    }

    Thread.Sleep(4000);
    Console.Clear();
}


