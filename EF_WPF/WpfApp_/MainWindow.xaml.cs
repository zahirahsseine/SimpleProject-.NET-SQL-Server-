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
using DAL;
namespace WpfApp_
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
        public MainWindow()
        {
           
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            efdataEntities db = new efdataEntities();
            Repository _rpo = new Repository(db);
            if(_rpo.checkConnexion(name.Text,password.Password))
            {
                Window1 wnd = new Window1();
                wnd.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Your Credential are incorrect");
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }
    }
}
