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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (AutozapBDEntities autozap = new AutozapBDEntities())
            {
                autozap.UserSet.Add(new UserSet()
                {


                    Login = LoginTextBox.Text,
                    Password=PasswordTexBox.Text,
                    Role="Клиент",
                    Email="Proverka"
                   
                });
                autozap.SaveChanges();
                
            }
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Enter_Click_1(object sender, RoutedEventArgs e)
        {
            using (AutozapBDEntities autozap = new AutozapBDEntities())
            {
                foreach(var user in autozap.UserSet)
                {
                    if(user.Login == LoginTextBox.Text && user.Password == PasswordTexBox.Text)
                    {
                        MainWindow.main.MainPage.Navigate(new CustomerWindow());
                    }
                    
                    
                    
                }
            }
               
        }
    }
}
