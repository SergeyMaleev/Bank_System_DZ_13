using BankSystem.View;
using BankSystem.View.Admin;
using BankSystem.ViewModels.Base;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BankSystem.ViewModels
{
    public class StaffLoginWindowViewModel : ViewModelsBase
    {

        private string _password = "admin"; //Пароль для входа



        public string Password { get; set; }
        
        
        
        private NavigationService _navigation;

        public StaffLoginWindowViewModel(NavigationService navigation)
        {
            _navigation = navigation;


        }

        /// <summary>
        /// Команда выхода в главное меню
        /// </summary>
        public ICommand BackCommand => new DelegateCommand(() =>
        {

            _navigation.Navigate(new EntryWindow()); //Переходим на страницу регистрации сотрудника

        });

        /// <summary>
        /// Переход на основную страницу банка
        /// </summary>
        public ICommand LoginUp => new DelegateCommand(() =>
        {
            if (Password == _password)
            {
                _navigation.Navigate(new AdminBankWindow()); //Переходим на административную страницу банка               
            }
            else
            {
                MessageBox.Show("Вы ввели неверный пароль, попробуйте еще раз");
                Password = null;
            }

        }, () => !string.IsNullOrEmpty(Password)); //если строка пустая коменду выполнить не можем
    }
}
