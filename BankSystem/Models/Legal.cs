using BankSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    /// <summary>
    /// Юридическое лицо
    /// </summary>
    class Legal : Client
    {
        
        static int Nomer { get; set; }

        public string NameOrganization { get; set;}



        /// <summary>
        /// Конструктор для ручного заполнения 
        /// </summary>
        /// <param name="NameOrganization">Название организации</param>
        /// <param name="FirstName">Имя представителя</param>
        /// <param name="LastName">Фамилия представителя</param>
        /// <param name="Age">Возраст организации</param>
        /// <param name="Profit">Прибыль организации в месяц</param>
        /// <param name="Telephone">Контактный телефон</param>
        public Legal(string NameOrganization, string FirstName, string LastName, int Age, double Profit, string Telephone)
            : base(FirstName, LastName, Age, Profit, Telephone)
        {
            this.NameOrganization = NameOrganization;
        }


        /// <summary>
        /// Конструктор для автозаполнения
        /// </summary>
        public Legal()
        {
            this.NameOrganization = $"Организация {Nomer}";
            NomerUp();
        }



        /// <summary>
        /// Метод счетчик организаций созданных вручную
        /// </summary>
        static void NomerUp()
        {
            ++Nomer;
        }

    }
}
