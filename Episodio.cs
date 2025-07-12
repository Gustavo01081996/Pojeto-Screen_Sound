using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound;
public class Episodio
{
    private TimeSpan duracao;
    private static int ultimoId = 0;
    private string resumo;
    private string titulo;
    List<string> convidados;

    public Episodio(TimeSpan duracao, string resumo, string titulo) 
    {
        this.duracao = duracao;
        this.resumo = resumo;   
        this.titulo = titulo;   
        convidados = new List<string>();
        
    }

    public List<string> getListaConvidados() => convidados;

    public string getTitulo() => titulo;

    public void AdicionarConvidado(string convidado)
    {
        if (convidado == null)
            throw new ArgumentNullException("O argumento não pode ser nulo");
        convidados.Add(convidado);  
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Título: {titulo}");
        sb.AppendLine($"Duração: {duracao.ToString("mm\\:ss")}");
        foreach (string convidado in convidados)
        {
            sb.AppendLine(convidado);
        }

        return sb.ToString();   

    }
}
