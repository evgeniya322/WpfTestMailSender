using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MailSender.lib.Serveses;
using MailSender.lib.Data.Linq2SQL;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;

namespace WpfTestMailSender.ViewModel
{
    public class MainWindowViewModel:ViewModelBase
    {
        private RecipientsDataProvider _RecipientsProvider;

        private string _WindowTitle = "Рассыльщик почты v0.1";

        public string WindowTitle
        {
            get => _WindowTitle;
            set => Set(ref _WindowTitle, value);
        }

        private ObservableCollection<Recipients> _Recipients = new ObservableCollection<Recipients>();

        public ObservableCollection<Recipients> Recipients { get => _Recipients;
            set => Set(ref _Recipients, value);

        }

        #region SelectedRecipient : Recipient - Выбранный получатель

        /// <summary>Выбранный получатель</summary>
        private Recipients _SelectedRecipient;

        /// <summary>Выбранный получатель</summary>
        public Recipients SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }

        #endregion

        public ICommand RefreshDataCommand { get; }

        public ICommand SaveChangesCommand { get; }

       // public ICommand RefreshDataComand { get; }

        public MainWindowViewModel(RecipientsDataProvider RecipientsProvider)
        {
            _RecipientsProvider = RecipientsProvider;

            RefreshDataCommand = new RelayCommand(OnRefreshDataComandExecuted, CanRefreshDataComandExecuted);
            SaveChangesCommand = new RelayCommand(OnRefreshDataComandExecuted);
            //RefreshData();
        }

        private bool CanRefreshDataComandExecuted() => true;

        private void OnRefreshDataComandExecuted()
        {
            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = new ObservableCollection<Recipients>();
            recipients.Clear();
            foreach (var recipient in _RecipientsProvider.GetAll())
                recipients.Add(recipient);
            Recipients = recipients;
        }
    }
}
