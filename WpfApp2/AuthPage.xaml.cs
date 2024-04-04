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
        public static int incorrectAttempts = 0;
        public AuthPage()
        {
            InitializeComponent();
        }

        private void Vxod_button_Click(object sender, RoutedEventArgs e)
        {
            Auth(Login_text.Text, Password_pasbox.Password);
        }
        public bool Auth(string login, string password) 
        {
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(password))
            {
                incorrectAttempts += 1;
                MessageBox.Show("Введите логин и пароль");
                if (incorrectAttempts >= 3)
                {
                   NavigationService.Navigate(new Capcha());
                   incorrectAttempts = 0;
                }
                return false;
            }
            else if (string.IsNullOrEmpty(login))
            {
                incorrectAttempts += 1;
                MessageBox.Show("Вы не ввели логин!");
                if (incorrectAttempts >= 3)
                {
                    NavigationService.Navigate(new Capcha());
                    incorrectAttempts = 0;
                }
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                incorrectAttempts += 1;
                MessageBox.Show("Вы не ввели пароль!");
                if (incorrectAttempts >= 3)
                {
                    NavigationService.Navigate(new Capcha());
                    incorrectAttempts = 0;
                }
                return false;
            }
            using (var db = new ПР5Entities())
            {
               
                var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == login && u.Password == password);
                 if (user == null)
                {
                    incorrectAttempts += 1;
                    MessageBox.Show($"Учётная запись не найдена");
                    if (incorrectAttempts >= 3)
                    {
                        NavigationService.Navigate(new Capcha());
                        incorrectAttempts = 0;
                    }
                    return false;
                }
                else
                {
                    var role = user.Role;
                    if (role == "Удален")
                    {
                        incorrectAttempts += 1;
                        MessageBox.Show($"Уважаемый, {user.FIO}, вы удалены :3");
                        if (incorrectAttempts >= 3)
                        {
                            NavigationService.Navigate(new Capcha());
                            incorrectAttempts = 0;
                        }
                        return false;
                    }
                    else
                    {
                        incorrectAttempts = 0;
                        MessageBox.Show($"Здравствуйте, {user.Role} {user.FIO}!");
                        Login_text.Clear();
                        Password_pasbox.Clear();
                        return true;
                    }
                }
            }
        }

        private void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
    }
}
