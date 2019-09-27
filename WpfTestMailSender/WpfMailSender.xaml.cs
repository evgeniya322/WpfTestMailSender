using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using WpfTestMailSender.Controls;

namespace WpfTestMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        


        public WpfMailSender()
        {
            InitializeComponent();
           
            
        }


        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TabItemSwicher_LeftButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemSwicher switcher)) return;

            if (MainTabCantrol.SelectedIndex == 0) return;

            if (switcher.RightButtonVisible == false) switcher.RightButtonVisible = true;
            MainTabCantrol.SelectedIndex--;
            if (MainTabCantrol.SelectedIndex == 0)
            {
                switcher.LeftButtonVisible = false;
            }
        }

        private void TabItemSwicher_RightButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemSwicher switcher)) return;

            var tab_count = MainTabCantrol.Items.Count;

            if (MainTabCantrol.SelectedIndex == tab_count - 1) return;

            if (switcher.LeftButtonVisible == false) switcher.LeftButtonVisible = true;
            MainTabCantrol.SelectedIndex++;

            if (MainTabCantrol.SelectedIndex == MainTabCantrol.Items.Count - 1)
            {
                switcher.RightButtonVisible = false;
            }
        }
    }
}
