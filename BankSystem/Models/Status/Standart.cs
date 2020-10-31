using BankSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models.Status
{
    class Standart : ICredit
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
                CreditRate = (18.0 / 12) * 0.01; //Месячная процентная ставка 

                MaxLimit = client.Profit * 20;

                Period = 7 * 12; //Период до 7 лет
            }
            else //Клиент физ.лицо
            {
                CreditRate = (16.5 / 12) * 0.01; //Месячная процентная ставка

                MaxLimit = client.Profit * 10;

                Period = ((60 - client.Age) > 5 ? 5 : (60 - client.Age)) * 12; //Период до 5 лет, или до предельного возраста
            }

            MonthlyFee = ((CreditRate * Math.Pow((1 + CreditRate), Period)) / ((Math.Pow((1 + CreditRate), Period)) - 1)) * MaxLimit; // Формула расчета аннуитетного платежа
                                                                                                                                    

        }
    }
}
