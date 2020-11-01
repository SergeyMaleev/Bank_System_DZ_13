using BankSystem.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    /// <summary>
    /// Физическое лицо
    /// </summary>
    class Physical : Client
    {
        

        /// <summary>
        /// Конструктор для ручного заполнения 
        /// </summary>
        /// <param name="FirstName">Имя </param>
        /// <param name="LastName">Фамилия</param>
        /// <param name="Age">Возраст</param>
        /// <param name="Profit">Прибыль в месяц</param>
        /// <param name="Telephone">Контактный телефон</param>
        public Physical( string FirstName, string LastName, int Age, double Profit, string Telephone)
            : base(FirstName, LastName, Age, Profit, Telephone)
        {
            ObjType = 2;
        }

        /// <summary>
        /// Конструктор для автозаполнения
        /// </summary>
        public Physical() { }


    }
}
