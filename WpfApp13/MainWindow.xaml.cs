using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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

namespace WpfApp13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        registration registration = new registration();
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var pass = password.Text;
            var context=new Appdbcontext();
            var user_exists = context.Users.FirstOrDefault(x=>x.login == login);
            if (user_exists is not null) 
            {
                MessageBox.Show("Такой пользователь уже зарегестрирован");
                return;
            }
            var user = new user {login = login,password=pass};
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("lets'go baby");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            registration.Show();
            this.Hide();
        }
    }
}
