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

namespace HouseholdRepair.View
{
    /// <summary>
    /// Логика взаимодействия для UserForm.xaml
    /// </summary>
    public partial class UserForm : Window
    {
        public UserForm()
        {
            InitializeComponent();
        }

        private void ToAdd_Click(object sender, RoutedEventArgs e)
        {
            RequestAddForm requestAddForm = new RequestAddForm();
            requestAddForm.ShowDialog();

        }

        private void ToMine_Click(object sender, RoutedEventArgs e)
        {
            UserRequests userRequests = new UserRequests();
            userRequests.ShowDialog();

        }
    }
}
