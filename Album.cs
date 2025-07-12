using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound;
public class Album
{
    private string nome;
    private List<Musica> musicas;

    public Album(string nome) 
    {
        this.nome = nome;   
        musicas = new List<Musica>();
    }

    public void AdicionarMusicaAoAlbum(Musica musica)
    {
        if (musica == null)
            throw new ArgumentNullException("O argumento fornecido não pode ser nulo");

        musicas.Add(musica);
    }

    public String GetNome => nome;

    public List<Musica> GetMusicas() => musicas;
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Álbum: {nome}");
        foreach (Musica musica in musicas)
        {
            sb.AppendLine(musica.ToString());
        }
        return sb.ToString();
        
    }

}
