using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Models
{
    /// <summary>
    /// Статический класс генерации данных о персонале
    /// </summary>
    public static class StaffRandomGeneration
    {
        public static Random random = new Random();


        /// <summary>
        /// Метод возращающий массив из [0] - имя [1] - Фамилия одного пола, [2]-Телефон
        /// </summary>
        /// <returns></returns>
        public static string[] GetRandName()
        {
            //Список хранящий имя и фамилмю
            string[] firstNamelastName = new string[3];

            var mansFirstNames = new string[]
         {
            "Владимир",
            "Петр",
            "Анатолий",
            "Геннадий",
            "Роман",
            "Никита",
            "Илья",
            "Сергей",
            "Тимофей",
            "Любомир",
            "Максим",
            "Степан",
            "Всеволод",
            "Ефим",
            "Павел",
            "Артем",
            "Евгений",
            "Валерий"
         };

            var mansLastNames = new string[]
         {
            "Царёв",
            "Борисов",
            "Минеев",
            "Ворожцов",
            "Тимирёв",
            "Ястребов",
            "Чекмарёв",
            "Федосов",
            "Чегодаев",
            "Сыров"
         };

            var womansFirstNames = new string[]
         {
            "Зинаида",
            "Наталья",
            "Лилия",
            "Залина",
            "Елена",
            "Светлана",
            "Лидия",
            "Татьяна",
            "Янина",
            "Елизавета"
         };

            var womansLastNames = new string[]
         {
            "Лосевская",
            "Огородникова",
            "Кутичева",
            "Цой",
            "Кунаковская",
            "Саянкина",
            "Кобелева",
            "Водопьянова",
            "Карандашова",
            "Явчуновская"
         };

            var telephonNumber = new string[]
         {
            "+7 (987) 914-22-18",
            "+7 (929) 915-25-11",
            "+7 (937) 664-55-51",
            "+7 (812) 955-35-17",
            "+7 (929) 656-22-41"            
         };

            var manOrWoman = random.Next(0, 2);
            //Мужина или женщина
            switch (manOrWoman)
            {
                case 0:
                    firstNamelastName[0] = (mansFirstNames[random.Next(0, mansFirstNames.Length)]);
                    firstNamelastName[1] = (mansLastNames[random.Next(0, mansLastNames.Length)]);
                    firstNamelastName[2] = (telephonNumber[random.Next(0, telephonNumber.Length)]);
                    return firstNamelastName;
                case 1:
                    firstNamelastName[0] = (womansFirstNames[random.Next(0, womansFirstNames.Length)]);
                    firstNamelastName[1] = (womansLastNames[random.Next(0, womansLastNames.Length)]);
                    firstNamelastName[2] = (telephonNumber[random.Next(0, telephonNumber.Length)]);
                    return firstNamelastName;
                default:
                    return null;
            }

        }

    }
}
