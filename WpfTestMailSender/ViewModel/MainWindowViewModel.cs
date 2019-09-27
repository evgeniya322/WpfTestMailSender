using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MailSender.lib.Serveses;
using MailSender.lib.Data.Linq2SQL;

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

        public ObservableCollection<Recipients> Recipients { get; } = new ObservableCollection<Recipients>();

        public MainWindowViewModel(RecipientsDataProvider RecipientsProvider)
        {
            _RecipientsProvider = RecipientsProvider;

            RefreshData();
        }

        private void RefreshData()
        {
            var recipients = Recipients;
            recipients.Clear();
            foreach (var recipient in _RecipientsProvider.GetAll())
                recipients.Add(recipient);
        }
    }
}
