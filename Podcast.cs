using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound;
public class Podcast
{
    private static int ultimoId = 0;
    private  int registro;
    private string host;
    private string nome;
    private int totalEpisodios;
    private List<Episodio> listaDeEpisodios;

    public Podcast(string host, string nome) 
    {
        this.host = host;   
        this.nome = nome;
        this.registro = ++ultimoId;
        listaDeEpisodios = new List<Episodio>();    
    }

    public int TotalEpisodios => listaDeEpisodios.Count;

    public void AdicionarEpisodio(Episodio episodio) 
    {
        if (episodio == null)
            throw new ArgumentNullException("O argumento não pode ser nulo");
        listaDeEpisodios.Add(episodio);     
    }

    public string getNome() => nome;    
    public override int GetHashCode() => registro;

    public List<Episodio> getListaEpisodios() => listaDeEpisodios;  
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Host: {host}");
        sb.AppendLine($"Nome: {nome}");

        foreach (Episodio episodio in listaDeEpisodios) 
        {
            sb.AppendLine(episodio.ToString());
        }

        return sb.ToString();
    }


}
