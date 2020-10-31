using BankSystem.View;
using BankSystem.View.Admin;
using BankSystem.ViewModels;
using BankSystem.ViewModels.Base;
using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BankSystem.ViewModels
{
    /// <summary>
    /// Каркас страницы 
    /// </summary>
    class MainWindowViewModel : ViewModelsBase
    {
        
        public Page CurrenPage { get; set; } //текущая страница

       

        public MainWindowViewModel(NavigationService navigation)
        {

            navigation.OnPageChanged += Page => CurrenPage = Page; //подписываемся на навигацию для пооказа текущей страницы
            navigation.Navigate(new EntryWindow()); //первая страница, страница входа
           
        }

        
    }
}
