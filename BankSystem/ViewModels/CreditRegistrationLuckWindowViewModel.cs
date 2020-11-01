using BankSystem.View;
using BankSystem.ViewModels.Base;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankSystem.ViewModels
{
    class CreditRegistrationLuckWindowViewModel : ViewModelsBase
    {

        private NavigationService _navigation;

        public CreditRegistrationLuckWindowViewModel(NavigationService navigation)
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

    }
}
