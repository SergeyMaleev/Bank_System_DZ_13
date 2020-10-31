using BankSystem.View;
using BankSystem.View.Client;
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
    public class EntryWindowViewModel : ViewModelsBase
    {

        private NavigationService _navigation;

        public EntryWindowViewModel(NavigationService navigation)
        {
            _navigation = navigation;


        }

        /// <summary>
        /// Команда входа клиента в банк
        /// </summary>
        public ICommand LoginСlientCommand => new DelegateCommand(() =>
        {

            _navigation.Navigate(new ClientWindow()); //Переходим на страницу клиента

        });

        /// <summary>
        /// Команда входа сотрудника банка в банк
        /// </summary>
        public ICommand LoginStaffCommand => new DelegateCommand(() =>
        {

            _navigation.Navigate(new StaffLoginWindow()); //Переходим на страницу регистрации сотрудника

        });


    }
}
