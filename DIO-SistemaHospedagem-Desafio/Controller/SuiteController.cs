using DIO_SistemaHospedagem_Desafio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_SistemaHospedagem_Desafio.Controller
{
    public class SuiteController
    {
        private List<Suite> suites;


        public SuiteController()
        {
             suites = new List<Suite>
             {
                new Suite("Suite Simples", 2, 100.0M),
                new Suite("Suite Luxo", 3, 200.0M),
                new Suite("Suite Presidencial", 4, 300.0M)
             };
        }
        public List<Suite> ListarSuitesDisponiveis()
        {
            for (int i = 0; i < suites.Count; i++)
            {
                Suite suite = suites[i];
                Console.WriteLine($"{i + 1} - Tipo de Suíte: {suite.TipoSuite}, Capacidade: {suite.Capacidade} pessoas, Valor Diária: {suite.ValorDiaria:C}");
            }

            return suites.ToList();
        }
    }
}
