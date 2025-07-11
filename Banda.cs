using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound;
public class Banda
{
    private static int ultimoId = 0;
    private int registro;
    private String nome;
    private List<Double> notas;

    public Banda(String nome)
    {
        this.nome = nome;
        this.registro = ++ultimoId;
        notas = new List<Double>();
    }

    public String getNome()
    {
        return nome;
    }
    public void AvaliarBanda(double nota)
    {
        if (nota < 0)
            throw new ArgumentException("A nota deve ser maior que 0");
        notas.Add(nota);
    }

    public double RetornaMedia()
    {
        double soma = 0;
        foreach (Double nota in notas)
        {
            soma += nota;
        }
        return soma / notas.Count;
    }

    public override int GetHashCode()
    {
        return registro;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            throw new ArgumentNullException("O objeto não pode ser nulo");

        Banda outra = (Banda)obj;
        return outra.getNome().Equals(nome);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Banda: {nome}");
        sb.AppendLine("Notas:");


        foreach (double nota in notas)
        {
            sb.AppendLine($"{nota}");
        }

        return sb.ToString();
    }
}
