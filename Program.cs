using ScreenSound;
using System.Globalization;

string mensagemDeBoasVindas = "\nBoas vindas ao Screen Sound";

Dictionary<int, Artista> conjuntoDeArtistas = new Dictionary<int, Artista>();
Dictionary<int, Podcast> conjuntoDePodcasts = new Dictionary<int, Podcast>();

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
    Console.WriteLine("Digite 5 para criar um novo álbum");  
    Console.WriteLine("Digite 6 para exibir os albuns de um determinado artista");    
    Console.WriteLine("Digite 7 para cadastrar uma música");
    Console.WriteLine("Digite 8 para cadastrar um novo podcast");
    Console.WriteLine("Digite 9 para cadastrar um novo episodio");
    Console.WriteLine("Digite 10 para adicionar um convidado ao episodio de um podcast");
    Console.WriteLine("Digite 11 para exibir os podcasts cadastrados");    
    Console.WriteLine("Digite -1 para sair");

}
int opcao;

do
{

    ExibirOpcoesDoMenu();
    Console.Write("\nDigite a sua opção: ");
    opcao = int.Parse(Console.ReadLine()!);

    string nomeArtista, podcast, episodio;
    Artista artistaEscolhido;
    Podcast podcastEscolhido;
    Episodio episodioEscolhido;

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
            try
            {
                Console.Write("Informe o nome do artista que ao qual deseja cadastrar o album: ");
                nomeArtista = Console.ReadLine()!;
                artistaEscolhido = RetornaArtistaPeloNome(nomeArtista);
                RegistrarAlbum(artistaEscolhido);
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            break;
            case 6:
            ExibeNomesArtistas();
            try
            {
                Console.Write("Informe o nome do artista que ao qual deseja exibir os álbuns: ");
                nomeArtista = Console.ReadLine()!;
                artistaEscolhido = RetornaArtistaPeloNome(nomeArtista);
                ExibeAlbuns(artistaEscolhido);
            }
            catch (ArgumentNullException e) 
            {
                Console.WriteLine($"{e.Message}");
            }
            break;
            case 7:
            ExibeNomesArtistas();
            try
            {
                Console.Write("Para qual artista deseja adicionar a música? ");
                string nome = Console.ReadLine()!;
                artistaEscolhido = RetornaArtistaPeloNome(nome);
                ExibeNomeAlbunsArtista(artistaEscolhido);
                Console.Write("Informe o nome do album: ");
                string nomeAlbum = Console.ReadLine()!;
                Album albumEscolhido = RetornaAlbumPeloNome(artistaEscolhido, nomeAlbum);
                AdicionarMusica(artistaEscolhido,albumEscolhido);
            }
            catch(ArgumentNullException e) 
            {
                Console.WriteLine($"{e.Message}");
            }   
            break;
            case 8:
            CadastrarPodcast();
            break;
            case 9:
            ExibeNomePodcasts();
            try
            {
                Console.Write("Informe o nome do podcast ao qual deseja adicionar um episodio");
                podcast = Console.ReadLine()!;
                podcastEscolhido = RetornaPodcastPeloNome(podcast);
            }
            catch(ArgumentNullException e) 
            {
                Console.WriteLine($"{e.Message}");
            }
            break;
            case 10:
            ExibeNomePodcasts();
            Console.Write("Informe o nome do podcast ao qual deseja adicionar um episodio");
            podcast = Console.ReadLine()!;
            podcastEscolhido = RetornaPodcastPeloNome(podcast);
            ExibeListaEpisodios(podcastEscolhido);
            Console.WriteLine("Informe o episodio");
            episodio = Console.ReadLine()!;
            episodioEscolhido = RetornaEpisodioPeloNome(podcastEscolhido, episodio);
            AdicionarConvidado(episodioEscolhido);
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
    Console.WriteLine("Artista cadastrado com sucesso!");
    Thread.Sleep(2000);
    Console.Clear();
}

void MostrarArtistas()
{
    Console.Clear();
    ExibeTituloDaOpcao("Exbindo artistas cadastrados");
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


void RegistrarAlbum(Artista artista)
{
    if (artista == null)
        throw new ArgumentNullException("Argumento nulo");

    Console.Clear();
    ExibeTituloDaOpcao("Registro dos albuns");
    Console.Write("Informe o nome do álbum: ");
    string nome = Console.ReadLine();
    artista.AdicionarAlbumAoArtista(new Album(nome));
    Console.WriteLine("Álbum cadastrado com sucesso!");
    Thread.Sleep(3000);
    Console.Clear();
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

void AdicionarMusica(Artista artista, Album album) 
{
    if (album == null)
        throw new ArgumentNullException("O argumento não pode ser nulo");

    Console.Clear();
    ExibeTituloDaOpcao("Registro das músicas");
    bool disponivel = false;
    Console.Write("Qual o nome da música? ");
    string nome = Console.ReadLine()!;
    Console.Write("Qual a duração da musica? (mm:ss)? ");
    TimeSpan duracao = TimeSpan.ParseExact(Console.ReadLine()!, "mm\\:ss", CultureInfo.InvariantCulture);
    Console.Write("Qual o gênero da música?: ");
    string genero = Console.ReadLine()!;
    Console.Write("Essa música já está disponível (s/n)? ");
    char disponibilidade = Console.ReadLine()!.ToLower().ElementAt(0);
    if (disponibilidade == 's') 
    {
        disponivel = true;  
    }

    album.AdicionarMusicaAoAlbum(new Musica(artista, nome, duracao, disponivel, new Genero(genero)));
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

Album RetornaAlbumPeloNome(Artista artista, string nomeAlbum) 
{
    List<Album> albuns = conjuntoDeArtistas[artista.GetHashCode()].RetornaListaDeAlbuns;
    foreach (Album album in albuns) 
    {
        if (nomeAlbum.Equals(album.GetNome))
        {
            return album;   
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

void ExibeAlbuns(Artista artista) 
{
    if (artista == null)
        throw new ArgumentNullException("O argumento não pode ser nulo");


    Console.Clear();
    ExibeTituloDaOpcao("Exbindo albuns");
    Console.WriteLine(artista);
    Thread.Sleep(5000);
    Console.Clear();
}

void ExibeNomeAlbunsArtista(Artista artista) 
{
    if (artista == null)
        throw new ArgumentNullException("O argumento não pode ser nulo");

    Console.Clear();
    ExibeTituloDaOpcao("Exbindo nome dos albuns");
    List<Album> albuns = artista.RetornaListaDeAlbuns;
    albuns.ForEach(album => Console.WriteLine(album.GetNome));  
    Console.WriteLine();
}

void CadastrarPodcast() 
{
    Console.Write("Informe o host: ");
    string host = Console.ReadLine();
    Console.Write("Informe o nome do podcast: ");
    string nome = Console.ReadLine();
    Podcast podcast = new Podcast(host, nome);
    conjuntoDePodcasts.Add(podcast.GetHashCode(), podcast);
    Console.WriteLine("Podcast cadastrado com sucesso!");
    Thread.Sleep(3000);
    Console.Clear();   
       
}

void ExibeNomePodcasts() 
{
    foreach (Podcast podcast in conjuntoDePodcasts.Values) 
    {
        Console.WriteLine($"Podcast: {podcast.getNome()}");
    }
}

Podcast RetornaPodcastPeloNome(string nome) 
{
    foreach (Podcast podcast in conjuntoDePodcasts.Values)
    {
        if (nome.Equals(podcast.getNome()))
        { 
            return podcast; 
        }
    }
    return null;
}

void AdicionarEpisodio(Podcast podcast)
{
    Console.Write("Informe o titulo do podcast: ");
    string titulo = Console.ReadLine()!;
    Console.Write("Informe o resumo do podcast: ");
    string resumo = Console.ReadLine()!;
    Console.Write("Informe a duração do podcast: ");
    TimeSpan duracao = TimeSpan.ParseExact(Console.ReadLine()!, "mm\\:ss", CultureInfo.InvariantCulture);
    Episodio episodio = new Episodio(duracao, resumo, titulo);
    Console.Write("Episodio adicionado com sucesso");
    Thread.Sleep(3000);
    Console.Clear();   
}

void ExibeListaEpisodios(Podcast podcast)
{
    List<Episodio> episodios = conjuntoDePodcasts[podcast.GetHashCode()].getListaEpisodios();

    episodios.ForEach(episodio => Console.WriteLine(episodio.getTitulo()));
}

Episodio RetornaEpisodioPeloNome(Podcast podcast, string nome) 
{
    if(podcast == null)
        throw new ArgumentNullException("O argumento não pode ser nulo");
    List<Episodio> episodios = conjuntoDePodcasts[podcast.GetHashCode()].getListaEpisodios();
    foreach (Episodio episodio in episodios) 
    {
        if (nome.Equals(episodio.getTitulo())) 
        {
            return episodio;
        }
    }

    return null;
}

void AdicionarConvidado(Podcast podcast, Episodio episodio) 
{
    if (podcast == null || episodio == null)
        throw new ArgumentNullException("O argumento não pode ser nulo");
    
    List<Episodio> episodios = conjuntoDePodcasts[podcast.GetHashCode()].getListaEpisodios();
    foreach (Episodio epis in episodios)
    {
        if (epis.Equals(episodio))
        {
            Console.WriteLine("Informe o nome do convidado: ");
            string nome = Console.ReadLine()!;
            epis.AdicionarConvidado(nome);
        }
    }
}







