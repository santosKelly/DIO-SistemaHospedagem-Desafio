using DIO_SistemaHospedagem_Desafio.Controller;
using DIO_SistemaHospedagem_Desafio.Model;

int diasReservados = 0;
int capacidade = 0;
string tipoSuite = "";
decimal valorDiaria = 0;


Reserva reserva = new Reserva( diasReservados);
Pessoa hospede = new Pessoa();
List<Pessoa> listHospede = new List<Pessoa>();
Suite suite = new Suite(tipoSuite,capacidade,valorDiaria);

PessoaController pessoaController = new PessoaController();
ReservaController reservaController = new ReservaController(reserva);
SuiteController suiteController = new SuiteController();

bool sair = false;

while (!sair)
{
    Console.Clear();
    Console.WriteLine("Escolha uma opção:");
    Console.WriteLine("1. Listar Suítes");
    Console.WriteLine("2. Cadastrar Hóspedes");
    Console.WriteLine("3. Listar Hóspedes");
    Console.WriteLine("4. Calcular Valor da Diária");
    Console.WriteLine("5. Sair");

    string escolha = Console.ReadLine();

    switch (escolha)
    {
        case "1": 
            Console.WriteLine("Suítes disponíveis:");
            suiteController.ListarSuitesDisponiveis();
            break;
        case "2": 
            listHospede.Add(pessoaController.CadastrarHospede());
            break;
        case "3": 
             reservaController.ListarHospedes(listHospede);
            break;
        case "4":
            reservaController.ObterValorDiaria(listHospede,suite,diasReservados);
            break;

        case "5":
            sair = true;
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida. Tente novamente.");
            break;
    }
    Console.WriteLine("Pressione uma tecla para retornar ao menu inicial.");
    Console.ReadLine();
}