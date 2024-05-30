using HouseholdRepair.Models;
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
    /// Логика взаимодействия для EmployeeListForm.xaml
    /// </summary>
    public partial class EmployeeListForm : Window
    {
        Model1 app = new Model1();
        List<Requests> requests;
        public EmployeeListForm()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            requests = app.Requests.Where(u=>u.EmployeeId==HouseholdRepairAbout.Id).ToList();
            RequestList.ItemsSource = requests;
        }
        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StatusFilter.SelectedIndex == 0)
            {
                requests = app.Requests.Where(u => u.RequestStatus == "Принята" && u.EmployeeId == HouseholdRepairAbout.Id).ToList();
                RequestList.ItemsSource = requests;
            }
            if (StatusFilter.SelectedIndex == 1)
            {
                requests = app.Requests.Where(u => u.RequestStatus == "В процессе" && u.EmployeeId == HouseholdRepairAbout.Id).ToList();
                RequestList.ItemsSource = requests;
            }
            if (StatusFilter.SelectedIndex == 2)
            {
                requests = app.Requests.Where(u => u.RequestStatus == "Выполнена" && u.EmployeeId == HouseholdRepairAbout.Id).ToList();
                RequestList.ItemsSource = requests;
            }
        }
    }
}
