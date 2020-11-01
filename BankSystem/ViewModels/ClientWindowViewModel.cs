using BankSystem.Models;
using BankSystem.Models.Status;
using BankSystem.View;
using BankSystem.View.Client;
using BankSystem.ViewModels.Base;
using DevExpress.Mvvm;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BankSystem.ViewModels
{
    public class ClientWindowViewModel : ViewModelsBase
    {

        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>(); // коллекция клиентов имеющих кредит
             
        public Client Client { get; set; } //Создаем класс потенциального клиента

        #region Поля вводимые пользователем
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

        private int _age;
        
        /// <summary>
        /// Возраст клиента (существования юр.лица)
        /// </summary>
        public int Age
        {
            get => _age;


            set
            {
                if(value > 18) 
                    Set(ref _age, value);
                else
                {
                    MessageBox.Show("Возраст заемщика не может быть меньше 18 лет");
                    
                }
               
            }
            
            }


        /// <summary>
        /// Доход
        /// </summary>
        public double Profit { get; set; }


        /// <summary>
        /// Кредитный рейтинг 
        /// </summary>
        private int CreditRating { get; set; }


        private string _telephone = "+7 (###) ###-##-##";

        /// <summary>
        /// Контактный телефон
        /// </summary>
        public string Telephone
        {
            get => _telephone;
            set => Set(ref _telephone, value);

        }

        public string NameOrganization { get; set; }
        #endregion

        /// <summary>
        /// статус клиента
        /// </summary>
        public string StatusClient { get; set; }

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
        public double MaxLimit { get; set; }   //максимальный лимит кредита
        public double MonthlyFee { get; set; } //ежемесячный платеж
        public int Period { get; set; }        //Период выплаты кредита
        public double CreditRate { get; set; } //Ставка по кредиту 



        //Для отображеия индивидуального кредита
        public double IndividualLimit { get; set; } //лимит выбранный пользователем

        public int IndividualPeriod { get; set; }  //период выбранный пользователем

        private double _individualMonthlyFee; //ежемесячный платеж 

        public double IndividualMonthlyFee
        {
            get
            {              
                return CreditOffer(CreditRate, IndividualLimit, IndividualPeriod); 
            }
            set => Set(ref _individualMonthlyFee, value);
        }

        
        private double _iIndividualPereplata; //Переплата по кредиту
        public double IndividualPereplata
        {
            get
            {
                return _individualMonthlyFee * IndividualPeriod - IndividualLimit;
            }
            set => Set(ref _iIndividualPereplata, value);
        }



        private NavigationService _navigation;
        
        public ClientWindowViewModel(NavigationService navigation)
        {
            _navigation = navigation;


            var FileExists = File.Exists("ClientList.json");
            if (FileExists)
            {

                using (StreamReader reader = File.OpenText("ClientList.json"))//Если есть открываем
                {

                    var fileText = reader.ReadToEnd();//Прочитываем до конца             
                    Clients = JsonConvert.DeserializeObject<ObservableCollection<Client>>(fileText);//Возвращаем в исходном виде

                    

                }

            }

                





        }

        #region Команды
        /// <summary>
        /// Команда создания клиента
        /// </summary>
        public ICommand ResultCommand => new DelegateCommand(() =>
        {
            if (СlientsСhoice == 0) //Физ.лицо, при создании всегда статус standart              
            {
                Client = new Physical(FirstName, LastName, Age, Profit, Telephone);
                Client.Credit = new Standart();
                Client.Credit.CreditOffer(Client);
               
            }
            else //Юр.лицо, при создании всегда статус standart
            {
                Client = new Legal(NameOrganization, FirstName, LastName, Age, Profit, Telephone);
                Client.Credit = new Standart();
                Client.Credit.CreditOffer(Client);
            }

            //Сохраняем для отображения в консоли кредитного предложения (напрямую не биндится)
            CreditRate = Client.Credit.CreditRate;

            MaxLimit = Client.Credit.MaxLimit;

            Period = Client.Credit.Period;

            MonthlyFee = Client.Credit.MonthlyFee;

            StatusClient = Client.Credit.Status;

            Result = true; //Открываем блок персонального предложения

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
        /// Команда выхода в главное меню
        /// </summary>
        public ICommand BackCommand => new DelegateCommand(() =>
        {

            _navigation.Navigate(new EntryWindow()); //Переходим на страницу регистрации сотрудника

        });


        /// <summary>
        /// Команда расчета кредита на индивидуальных условиях
        /// </summary>
        public ICommand IndividualCreditCommand => new DelegateCommand(() =>
        {

            Individual = true;

        }, () => Individual != true); //как только открыли выбор индивидуальных условий кредита команда недоступна


        /// <summary>
        /// Команда выдачи кредита при согласии с предложением и добавления в список клиентов банка
        /// </summary>
        public ICommand ICreditCreditCommand => new DelegateCommand(() =>
        {

            Client.ExistingLoan.Add(new ExistingLoan(MaxLimit, Period, MonthlyFee)); //выдаем кредит клиенту 

            Clients.Add(Client); //Добавляем с список клиентов

            

            using (StreamWriter writer = File.CreateText("ClientList.json"))
            {
                string f_text = JsonConvert.SerializeObject(Clients);
                writer.Write(f_text);

            }
            
            _navigation.Navigate(new CreditRegistrationLuckWindow()); //Переходим на страницу информации об успешной выдачи кредита

        });

        /// <summary>
        /// Команда выдачи кредита на индивидуальных условиях и добавления в список клиентов банка
        /// </summary>
        public ICommand ICreditPersonalCommand => new DelegateCommand(() =>
        {

            Client.ExistingLoan.Add(new ExistingLoan(IndividualLimit, IndividualPeriod, IndividualMonthlyFee)); //выдаем кредит клиенту 

            Clients.Add(Client); //Добавляем с список клиентов

            
            using (StreamWriter writer = File.CreateText("ClientList.json"))
            {
                string f_text = JsonConvert.SerializeObject(Clients);
                writer.Write(f_text);

            }


            _navigation.Navigate(new CreditRegistrationLuckWindow()); //Переходим на страницу информации об успешной выдачи кредита



        });


        #endregion


        /// <summary>
        /// Метод вычисляющий сумму ежемесячного платежа 
        /// </summary>
        /// <param name="CreditRate"> ставка процентов готовых</param>
        /// <param name="IndividualLimit"></param>
        /// <param name="IndividualPeriod"></param>
        /// <returns></returns>
        private double CreditOffer(double CreditRate, double IndividualLimit, int IndividualPeriod)
        { 
        
            _individualMonthlyFee = (((CreditRate/1200) * Math.Pow((1 + (CreditRate / 1200)), IndividualPeriod)) / ((Math.Pow((1 + (CreditRate / 1200)), IndividualPeriod)) - 1)) * IndividualLimit;


            return _individualMonthlyFee;

        }

    }
}
