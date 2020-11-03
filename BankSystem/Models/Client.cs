using BankSystem.Interface;
using BankSystem.Models.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    /// <summary>
    /// Родительский класс клиентов
    /// </summary>
    [JsonConverter(typeof(BaseConverterClient))]
    public abstract class Client 
    {

        /// <summary>
        /// Предлагаемый кредит на условиях в зависимости от статуса клиента 
        /// </summary>
        public ICredit Credit { get; set; } //(в дальнейшем можно продумать условия смены при выполнении определенных условий)

        /// <summary>
        /// коллекция для хранения имеющихся кредитов
        /// </summary>
        public ObservableCollection<ExistingLoan> ExistingLoan { get; set; } = new ObservableCollection<ExistingLoan>();


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
        /// Лицевой счет
        /// </summary>
        public double PersonalAccount { get; set; }



        /// <summary>
        /// Тип наследника для дессирилизации json
        /// </summary>
        public int ObjType { get; set; }



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

        

        
    }
}
