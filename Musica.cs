using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound;
public class Musica
{
    private string nome;
    private Artista artista;
    private TimeSpan duracao;
    private bool disponivel;
    private Genero genero;

    public Musica(Artista artista, string nome, TimeSpan duracao, bool disponivel, Genero genero)
    {
        this.nome = nome;
        this.duracao = duracao;
        this.disponivel = disponivel;
        this.genero = genero;   
    }

    public bool getDisponivel() => disponivel;

    public TimeSpan getDuracao => duracao;    

    public override String ToString() 
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Nome: {nome} | Gênero: {genero.getNome}");
        sb.AppendLine($"Duração: {duracao.ToString("mm\\:ss")}");
        if (disponivel)
        {
            sb.AppendLine("Disponível no plano");
        }
        else 
        {
            sb.AppendLine("Adquira o plano Plus");
        }
        return sb.ToString();
    }
}
