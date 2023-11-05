using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO_SistemaHospedagem_Desafio.Model
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }
        public List<Suite> SuitesDisponiveis { get; set; }

        public Reserva(int diasReservados) { }

    }
}
