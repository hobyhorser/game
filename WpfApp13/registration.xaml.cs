using Microsoft.EntityFrameworkCore;
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

namespace WpfApp13
{
    /// <summary>
    /// Логика взаимодействия для registration.xaml
    /// </summary>
    public partial class registration : Window
    {
        public registration()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var login = Logi.Text;
            var password = pass.Text;
            var context = new Appdbcontext();
            var user_exists = context.Users.FirstOrDefault(x => x.login == login);
            if (user_exists is not null)
            {
                MessageBox.Show("Такой пользователь уже зарегестрирован");
                return;
            }
            var user = new user { login = login, password =password };
            context.Users.Add(user);
            context.SaveChanges();
            MessageBox.Show("lets'go baby");
            this.Hide();
            MainWindow main = new MainWindow();
            main.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
