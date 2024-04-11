﻿using System;
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
using WpfApp2;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для Capcha.xaml
    /// </summary>
    public partial class Capcha : Page
    {

        public void generate()
        {
            String allowchar = " ";
            allowchar = "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            allowchar += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,y,z";
            allowchar += "1,2,3,4,5,6,7,8,9,0";
            char[] a = { ',' };
            String[] ar = allowchar.Split(a);
            String pwd = "";
            string temp = " ";
            Random r = new Random();
            for (int i = 0; i < 6; i++)
            {
                temp = ar[(r.Next(0, ar.Length))];
                pwd += temp;
            }
            textBoxCapcha.Text = pwd;
        }
        public Capcha()
        {
            InitializeComponent();
            generate();
        }

        private void buttonCapcha_click(object sender, RoutedEventArgs e)
        {
            generate();
        }

        private void CheckCapcha_Click(object sender, RoutedEventArgs e)
        {
            if(Checking(textBoxCapcha.Text, CapchaEnterTextbox.Text) == true)
            {
                NavigationService.Navigate(new AuthPage());
            }
        }
        public bool Checking(string textBoxCapcha, string CapchaEnterTextbox)
        {
            if (textBoxCapcha == CapchaEnterTextbox)
            {
                MessageBox.Show("Ура! Вы не робот!");
                return true;              
            }
            else
            {
                MessageBox.Show("Попробуйте ещё раз");
                generate();
                return false;
            }
        }
    }
}
