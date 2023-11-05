using DIO_SistemaHospedagem_Desafio.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_SistemaHospedagem_Desafio.Controller
{
    public class ReservaController
    {
        private readonly Reserva _reserva;

        public ReservaController(Reserva reserva)
        {
            _reserva = reserva;
        }

        public List<Pessoa> ListarHospedes(List<Pessoa> hospedes)
        {

            for (int i = 0; i < hospedes.Count; i++)
            {
                Console.WriteLine($"Nome do hóspede:    {hospedes[i].Nome}");
                Console.WriteLine($"Suíte:              {hospedes[i].Suite.TipoSuite}");
                Console.WriteLine();
            }

            if (hospedes.Count == 0)
            {
                Console.WriteLine("Não há hóspedes cadastrados em nenhuma suíte.");
            }

            return hospedes;
        }


        public void ObterValorDiaria(List<Pessoa> listHospede, Suite suite, int diasReservados)
        {

            if (listHospede != null)
            {
                Console.WriteLine("Escolha o hóspede para o cálculo da diária: ");
                for (int i = 0; i < listHospede.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listHospede[i].Nome}");
                }

                Console.Write("Digite o número do hóspede: ");
                if (int.TryParse(Console.ReadLine(), out int escolhaHospede) && escolhaHospede >= 1 && escolhaHospede <= listHospede.Count)
                {
                    Pessoa hospedeEscolhido = listHospede[escolhaHospede - 1];

                    Console.WriteLine("Informe a quantidade de dias reservados: ");
                    diasReservados = int.Parse(Console.ReadLine());
                    CalcularDiaria(suite, diasReservados, hospedeEscolhido);
                }
                else
                {
                    Console.WriteLine("Escolha inválida. Certifique-se de selecionar um número válido.");
                }
            }

        }
      

        public decimal CalcularDiaria(Suite suite, int diasReservados,Pessoa hospedeEscolhido)
        {
            decimal valorDiaria = 0;

            switch (hospedeEscolhido.Suite.TipoSuite)
            {
                case "Suite Simples":
                    valorDiaria = 100;
                    break;
                case "Suite Luxo":
                    valorDiaria = 200;
                    break;
                case "Suite Presidencial":
                    valorDiaria = 300;
                    break;
                default:
                    throw new InvalidOperationException("Tipo de suíte inválido.");
            }

            decimal valorTotal = valorDiaria * diasReservados;

            if (diasReservados >= 10)
            {
                decimal desconto = valorTotal * 0.10M; 
                valorTotal -= desconto;
            }

            Console.WriteLine($"O valor da diária para {hospedeEscolhido.Nome} na {hospedeEscolhido.Suite.TipoSuite} por {diasReservados} dias é: {valorTotal:C}");

            return valorTotal;
        }
    }
}
