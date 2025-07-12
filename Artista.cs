using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ScreenSound;
public class Artista
{
    private static int ultimoId = 0;
    private int registro;
    private String nome;
    private List<Double> notas;
    private List<Musica> musicas;

    public Artista(String nome)
    {
        this.nome = nome;
        this.registro = ++ultimoId;
        notas = new List<Double>();
        musicas = new List<Musica>();
    }

    public String getNome() => nome;  
    public void AvaliarArtista(double nota)
    {
        if (nota < 0)
            throw new ArgumentException("A nota deve ser maior que 0");
        notas.Add(nota);
    }

    public void AdicionarMusicaAoArtista(Musica musica) 
    {
        if (musica == null)
            throw new ArgumentNullException("O objeto não pode ser nulo");

        musicas.Add(musica);    
    }

    public double RetornaMedia() => notas.Average();    
  
    public override int GetHashCode() => registro;

    public List<Musica> RetornaListaDeMusicas => musicas;


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Artista: {nome}");
        sb.AppendLine("Notas:");


        foreach (double nota in notas)
        {
            sb.AppendLine($"{nota}");
        }

        return sb.ToString();
    }
}
