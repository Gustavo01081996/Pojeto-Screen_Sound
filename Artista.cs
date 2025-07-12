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
    private List<Album> albuns;

    public Artista(String nome)
    {
        this.nome = nome;
        this.registro = ++ultimoId;
        notas = new List<Double>();
        albuns = new List<Album>();
    }

    public String getNome() => nome;  
    public void AvaliarArtista(double nota)
    {
        if (nota < 0)
            throw new ArgumentException("A nota deve ser maior que 0");
        notas.Add(nota);
    }

    public void AdicionarAlbumAoArtista(Album album) 
    {
        if (album == null)
            throw new ArgumentNullException("O objeto não pode ser nulo");

        albuns.Add(album);    
    }

    public double RetornaMedia() => notas.Average();    
  
    public override int GetHashCode() => registro;

    public List<Album> RetornaListaDeAlbuns => albuns;


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Artista: {nome}");

        foreach (Album album in albuns)
        {
            sb.AppendLine(album.ToString());
        }

        return sb.ToString();
    }
}
