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

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FIOtext.Text) && !string.IsNullOrEmpty(LoginText.Text) 
                && !string.IsNullOrEmpty(PasswordText.Password)&& !string.IsNullOrEmpty(PasswordText.Password)
                && !string.IsNullOrEmpty(TelephoneText.Text) && !string.IsNullOrEmpty(PhotoLinkText.Text) &&
                (MaleRadioButton.IsChecked==true || FemaleRadioButton.IsChecked==true) && !(RoleComboBox.SelectedIndex==-1))
            {
                for (int i = 0; i < 11; i++)
                {

                }
                if (яоляляля)
                {

                }
                else
                {
                    MessageBox.Show("Вы ввели телефон неправильно!");
                }
            }
            else
            {
                MessageBox.Show("Вы заполнили не все поля :(");
            }
        }
    }
}
