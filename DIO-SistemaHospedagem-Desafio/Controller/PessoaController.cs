using DIO_SistemaHospedagem_Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_SistemaHospedagem_Desafio.Controller
{

    public class PessoaController
    {
        List<Suite> suitesDisponiveis = new List<Suite>
        {
              new Suite("Suite Simples", 2, 100.0M),
              new Suite("Suite Luxo", 3, 200.0M),
              new Suite("Suite Presidencial", 4, 300.0M)
        };


        public Pessoa CadastrarHospede()
        {
            Pessoa hospede = new Pessoa();
            Console.WriteLine("Escolha o número da suíte em que deseja cadastrar o hóspede:");

            // Filtra as suítes disponíveis que não estão cheias
            var disponiveis = suitesDisponiveis
                .Where(suite => suite.Hospedes.Count < suite.Capacidade)
                .ToList();

            if (disponiveis.Count == 0)
            {
                Console.WriteLine("Não há suítes disponíveis no momento.");
                return hospede;
            }

            for (int i = 0; i < disponiveis.Count; i++)
            {
                Suite suite = disponiveis[i];
                Console.WriteLine($"{i + 1} - {suite.TipoSuite}, Capacidade: {suite.Capacidade} pessoas, Valor Diária: {suite.ValorDiaria:C}");
            }

            int escolhaSuite = int.Parse(Console.ReadLine());

            Suite suiteEscolhida = null;

            if (escolhaSuite >= 1 && escolhaSuite <= disponiveis.Count)
            {
                suiteEscolhida = disponiveis[escolhaSuite - 1];

                Console.Write("Informe o nome do hóspede: ");
                string nomeDoHospede = Console.ReadLine();

                hospede.Nome = nomeDoHospede;
                hospede.Suite = suiteEscolhida;

                suiteEscolhida.Hospedes.Add(hospede);

                Console.WriteLine("Hóspede cadastrado com sucesso.");
            }
            else
            {
                Console.WriteLine("Escolha de suíte inválida. Por favor, escolha uma opção válida.");
            }

            return hospede;
        }


    }


}
