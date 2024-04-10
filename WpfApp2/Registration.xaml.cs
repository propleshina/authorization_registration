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
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = new Roles[]
            {
                new Roles { Name = "Менеджер А"},
                new Roles { Name = "Менеджер С"},
                new Roles { Name = "Администратор"},
            };
        }

        public class Roles
        {
            public string Name { get; set; } = "";
            public override string ToString() => $"{Name }";
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        public bool RegistrationCheck(string fio, string login, string password, string checkpassword, string role, string telephone, string photo, string gender)
        {
            if (!string.IsNullOrEmpty(fio) && !string.IsNullOrEmpty(login)
               && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(checkpassword)
               && !string.IsNullOrEmpty(telephone) && !string.IsNullOrEmpty(photo))
            {

                if (TelephoneText.Text.Length == 11)
                {
                    bool isphone = true;
                    for (int i = 0; i < 11; i++)
                    {
                        if (!Char.IsDigit(TelephoneText.Text[i]))
                        {
                            isphone = false;
                            break;
                        }
                    }
                    if (isphone)
                    {
                        if (password == checkpassword)
                        {
                            var db = new ПР5Entities();
                            var user = db.User.AsNoTracking().FirstOrDefault(u => u.Login == login);
                            if (user == null)
                            {

                                User userObject = new User
                                {
                                    FIO = fio,
                                    Login = login,
                                    Password = password,
                                    Role = role,
                                    Gender = gender,
                                    Phone = telephone,
                                    Photo = photo
                                };
                                db.User.Add(userObject);
                                db.SaveChanges();
                                MessageBox.Show($"Новый пользователь зарегестрирован!");

                                NavigationService.Navigate(new AuthPage());
                                return true;
                            }
                            else
                            {
                                MessageBox.Show($"Учетная запись с таким логином уже есть");
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Пароли не совпадают!!");
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Вы ввели телефон неправильно!");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели телефон неправильно!");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Вы заполнили не все поля :(");
                return false;
            }
        }
        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if((MaleRadioButton.IsChecked == true || FemaleRadioButton.IsChecked == true) && !(RoleComboBox.SelectedIndex == -1)){
                string gender = "";
                if (MaleRadioButton.IsChecked == true)
                {
                    gender = "M";
                }
                else
                {
                    gender = "F";
                }

                RegistrationCheck(FIOtext.Text, LoginText.Text, PasswordText.Password, PasswordText2.Password, RoleComboBox.Text, TelephoneText.Text, PhotoLinkText.Text, gender);
            }
       
    }
}
}
