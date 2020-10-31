using BankSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models.Status
{
    class VIP : ICredit
    {

        public double MaxLimit { get; set; }
        public double MonthlyFee { get; set; }
        public int Period { get; set; }
        public double CreditRate { get; set; }


        /// <summary>
        /// Метод вычисляющий кредитное предложение для клиента статуса standart
        /// </summary>
        /// <param name="client">Клиент</param>
        public void CreditOffer(Client client)
        {
            if (client is Legal) //если клиент юр.лицо
            {
                CreditRate = (14 / 12) * 0.01; //Месячная процентная ставка 

                MaxLimit = client.Profit * 30;

                Period = 10 * 12; //Период до 10 лет
            }
            else //Клиент физ.лицо
            {
                CreditRate = (13 / 12) * 0.01; //Месячная процентная ставка

                MaxLimit = client.Profit * 15;

                Period = ((65 - client.Age) > 10 ? 10 : (65 - client.Age)) * 12; //Период до 10 лет, или до 65 лет
            }

            MonthlyFee = ((CreditRate * Math.Pow((1 + CreditRate), Period)) / ((Math.Pow((1 + CreditRate), Period)) - 1)) * MaxLimit; // Формула расчета аннуитетного платежа


        }
    }
}
