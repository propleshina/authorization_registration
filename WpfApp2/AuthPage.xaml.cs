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

namespace WpfApp2
{
    public partial class AuthPage : Page
    {

        
        public AuthPage()
        {
            InitializeComponent();   
        }

        private void Vxod_button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login_text.Text) || string.IsNullOrEmpty(Password_pasbox.Password))
            {
                MessageBox.Show("Введите логин и пароль");
                return;
            }
            using (var db = new ПР5Entities())
            {
                var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == Login_text.Text && u.Password == Password_pasbox.Password);
                if (user == null)
                {
                    MessageBox.Show($"Учётная запись не найдена");
                }
                if (user != null)
                {
                    MessageBox.Show($"Здравствуйте, {user.Role} {user.FIO}!");
                }
            }
        }
    }
}
