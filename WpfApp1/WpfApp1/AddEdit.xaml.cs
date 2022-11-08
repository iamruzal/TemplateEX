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
    /// Логика взаимодействия для AddEdit.xaml
    /// </summary>
    public partial class AddEdit : Page
    {
        private static UserSet _currentUser = new UserSet();
        public AddEdit(UserSet selectedUser)
        {
            if (selectedUser != null)
            {
                _currentUser = selectedUser;
            }
            InitializeComponent();
            DataContext = _currentUser;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (_currentUser.Id == 0)
            {
                AutozapBDEntities.GetContext().UserSet.Add(_currentUser);
                AutozapBDEntities.GetContext().SaveChanges();
                MessageBox.Show("Успешно");
                MainWindow.main.MainPage.GoBack();
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
