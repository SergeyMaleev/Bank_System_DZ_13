using BankSystem.Models;
using BankSystem.Models.Json;
using BankSystem.Models.Status;
using BankSystem.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace BankSystem.ViewModels
{

    /// <summary>
    /// Класс административной части банка
    /// </summary>
    public class AdminBankWindowViewModel : ViewModelsBase
    {
        

        private readonly string PATH = "ClientList.json"; //путь к файлу с коллекцией клиентов
        private FileJson _fileJson;


        /// <summary>
        /// Выбранный клиент из списка
        /// </summary>
        public Client SelectedClient { get; set; }



        private ObservableCollection<Client> _clients;
        public ObservableCollection<Client> Clients 
        {
            get => _clients;
            set => Set(ref _clients, value);

        }  // коллекция клиентов имеющих кредит

       
        public AdminBankWindowViewModel()
        {

            _fileJson = new FileJson(PATH);

            Clients = _fileJson.LoadData();

            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 4);
            timer.Start();




        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Clients.Add(ClientRandomGeneration.AutoClient());
            _fileJson.SaveData(Clients);
        }


    }
}
