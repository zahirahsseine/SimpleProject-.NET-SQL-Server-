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
using System.Windows.Shapes;
using DAL;
namespace WpfApp_
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        efdataEntities db = new efdataEntities();
        Repository rep = new Repository(new efdataEntities());
        public Window1()
        {
            InitializeComponent();
            data.ItemsSource = rep.listUser();
        }
        public string loadMessage()
        {
            String msg = "";
            msg = name.Text.Length == 0 ?msg+ "*Name is requiried field": msg + "";          
            msg = pseudo.Text.Length == 0 ? msg + "*Pseudo is requiried field" : msg + "";
            msg = password.Password.Length == 0 ? msg + "*Password is requiried field" : msg + "";
            msg = confPassword.Password!= password.Password ? msg + "*the two passwords are not to match!" : msg + "";
           
            return msg;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string message = loadMessage();
            if (message.Length == 0)
            { 
                bool res = rep.addUser(new C_user { userName = name.Text, pseudoUser = pseudo.Text, passwordUser = password.Password });
            if (res)
            {
                data.ItemsSource = null;
                data.ItemsSource = rep.listUser();
                name.Text = "";
                pseudo.Text = "";
                password.Password = "";
                confPassword.Password = "";
                MessageBox.Show("Successfull Operation!");
            }
            else
            {
                MessageBox.Show("Failed Operation!");
            }
          }
            else
            {
                MessageBox.Show(message);
            }
        }
    }
}
