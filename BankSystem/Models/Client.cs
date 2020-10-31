using BankSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    /// <summary>
    /// Родительский класс клиентов
    /// </summary>
    public abstract class Client 
    {
        public ICredit Credit { get; set; }

        /// <summary>
        /// Дата регистрации клиента
        /// </summary>
        public DateTime DateTime { get; } 

        /// <summary>
        /// Имя клиента (представителя юр.лица)
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия клиента (представителя юр.лица)
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Возраст клиента (существования юр.лица)
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Доход
        /// </summary>
        public double Profit { get; set; }


        /// <summary>
        /// Кредитный рейтинг
        /// </summary>
        protected int CreditRating { get; set; }

        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string Telephone { get; set; }



        /// <summary>
        /// Конструктор клиента для ручного заполнения
        /// </summary>
        /// <param name="FirstName">Имя</param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Profit">Доход</param>
        /// <param name="Telephone">Телефон</param>
        public Client(string FirstName, string LastName, int Age, double Profit, string Telephone)
        {
            this.DateTime = DateTime.Now;

            this.FirstName = FirstName;

            this.LastName = LastName;

            this.Age = Age;

            this.Profit = Profit;

            this.Telephone = Telephone;

        }

        /// <summary>
        /// Конструктор клиента для автоматического заполнения
        /// </summary>
        public Client()
        {
            var firstNamelastName = StaffRandomGeneration.GetRandName();

            this.DateTime = DateTime.Now;

            this.FirstName = firstNamelastName[0];

            this.LastName = firstNamelastName[1];

            this.Age = StaffRandomGeneration.random.Next(18,61);

            this.Profit = StaffRandomGeneration.random.Next(25000, 180000);

            this.Telephone = firstNamelastName[2];

        }
    }
}
