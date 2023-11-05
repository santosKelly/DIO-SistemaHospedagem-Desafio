using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_SistemaHospedagem_Desafio.Model
{
    public class Pessoa
    {
        public Pessoa() { }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public Suite Suite { get; set; }
    }
}
