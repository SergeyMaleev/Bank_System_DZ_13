using BankSystem.Models;
using BankSystem.Models.Status;
using BankSystem.View.Client;
using BankSystem.ViewModels.Base;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankSystem.ViewModels
{
    public class ClientWindowViewModel : ViewModelsBase
    {
        public Client Client { get; set; } //Создаем класс клиента


        /// <summary>
        /// Индекс выбора пользователя в combobox [0] - физ.лицо, [1] - юр.лицо
        /// </summary>
        public int СlientsСhoice { get; set; }

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


        private string _telephone = "+7 (999) 999-99-99";

        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string Telephone
        {
            get => _telephone;
            set => Set(ref _telephone, value);

        }

        public string NameOrganization { get; set; }

        /// <summary>
        /// Запрещает ввод в поле NameOrganization при выборе физ.лица
        /// </summary>
        public bool Organization
        {
            get
            {
                if (СlientsСhoice == 0) return false;
                return true;
            }

        }

        /// <summary>
        /// Для скрытия блока результата кредитования
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// Для скрытия блока расчета индивидуального кредитования
        /// </summary>
        public bool Individual { get; set; }


        //Для отображеия кредитного предложения
        public double MaxLimit { get; set; }
        public double MonthlyFee { get; set; }
        public int Period { get; set; }
        public double CreditRate { get; set; }



        //Для отображеия индивидуального кредита
        public double IndividualLimit { get; set; }
        public double IndividualMonthlyFee { get; set; }
        public int IndividualPeriod { get; set; }
        public double IndividualCreditRate { get; set; }




        public ClientWindowViewModel()
        {

        }

        #region Команды
        /// <summary>
        /// Команда сохранения клиента
        /// </summary>
        public ICommand ResultCommand => new DelegateCommand(() =>
        {
            if (СlientsСhoice == 0) //Физ.лицо, при создании всегда статус standart              
            {
                Client = new Physical(FirstName, LastName, Age, Profit, Telephone);
                Client.Credit = new Standart();
                Client.Credit.CreditOffer(Client);
               
            }
            else
            {
                Client = new Legal(NameOrganization, FirstName, LastName, Age, Profit, Telephone);
                Client.Credit = new Standart();
                Client.Credit.CreditOffer(Client);
            }

            CreditRate = Client.Credit.CreditRate * 12 * 100;

            MaxLimit = Client.Credit.MaxLimit;

            Period = Client.Credit.Period;

            MonthlyFee = Client.Credit.MonthlyFee;

            Result = true;

        }, () => //Условия при которых кнопка отработает
        {
            if (СlientsСhoice == 0) //Физ.лицо, при создании всегда статус standart 
            {
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName) && Age > 17 && Profit != 0 && !string.IsNullOrEmpty(Telephone)) return true;
                else return false;

            }
            else //юр.лицо
            {
                if (!string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(FirstName) && Age > 17 && !string.IsNullOrEmpty(LastName) && Age > 0 && Profit != 0 && !string.IsNullOrEmpty(Telephone)) return true;
                else return false;

            }

        });

        /// <summary>
        /// Команда расчета кредита на индивидуальных условиях
        /// </summary>
        public ICommand IndividualCreditCommand => new DelegateCommand(() =>
        {

            Individual = true;

        });


        #endregion
    }
}
