using BankSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /// <summary>
    /// Клас взаимодействия с XAML
    /// </summary>
    class ViewModelsLocator
    {
        public MainWindowViewModel MainWindowViewModel => Dependency.Resolve<MainWindowViewModel>();

        public EntryWindowViewModel EntryWindowViewModel => Dependency.Resolve<EntryWindowViewModel>();

        public StaffLoginWindowViewModel StaffLoginWindowViewModel => Dependency.Resolve<StaffLoginWindowViewModel>();

        public AdminBankWindowViewModel AdminBankWindowViewModel => Dependency.Resolve<AdminBankWindowViewModel>();

        public ClientWindowViewModel ClientWindowViewModel => Dependency.Resolve<ClientWindowViewModel>();

        public CreditRegistrationLuckWindowViewModel CreditRegistrationLuckWindowViewModel => Dependency.Resolve<CreditRegistrationLuckWindowViewModel>();

    } 
}
