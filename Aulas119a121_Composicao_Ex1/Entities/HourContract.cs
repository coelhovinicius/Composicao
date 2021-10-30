/* >>> CLASSE HOURCONTRACT <<< */

using System;

namespace Aulas119a121_Composicao_Ex1.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        /* CONSTRUTORES - Podemos gerar Construtores utilizando as "Quick Actions": Quando estiver na linha desejada, 
         * verificar o icone que esta a esquerda da linha e selecionar as "Quick Actions" */
        public HourContract() // Construtor padrao
        {
        }

        public HourContract(DateTime date, double valuePerHour, int hours) // Construtor com argumentos
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        // METODO "TotalValue" para retornar o valor total
        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }
    }
}
