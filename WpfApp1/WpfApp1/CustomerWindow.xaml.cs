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
    /// Логика взаимодействия для CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Page
    {
        public CustomerWindow()
        {
            InitializeComponent();
            UsersGrid.ItemsSource = AutozapBDEntities.GetContext().UserSet.ToList();
        }

        private void RemoveBTN_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditBTN_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.MainPage.Navigate(new AddEdit(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AutozapBDEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                UsersGrid.ItemsSource = AutozapBDEntities.GetContext().UserSet.ToList();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.main.MainPage.Navigate(new AddEdit((sender as Button).DataContext as UserSet));
        }
    }
}
