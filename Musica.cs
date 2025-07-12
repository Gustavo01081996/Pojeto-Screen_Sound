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
    private TimeOnly duracao;
    private bool disponivel;

    public Musica(string nome, Artista artista, TimeOnly duracao, bool disponivel)
    {
        this.nome = nome;
        this.artista = artista;
        this.duracao = duracao;
        this.disponivel = disponivel;
    }

    public bool getDisponivel() => disponivel;

    public override String ToString() 
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Nome: {nome}");
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
