using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound;
public class Genero
{
    private string nome;

    public Genero(string nome) 
    {
        this.nome = nome;
    }
    public string getNome => nome;  
}
