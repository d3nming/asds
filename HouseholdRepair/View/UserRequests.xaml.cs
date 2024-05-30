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
using HouseholdRepair.Models;

namespace HouseholdRepair.View
{
    /// <summary>
    /// Логика взаимодействия для UserRequests.xaml
    /// </summary>
    public partial class UserRequests : Window
    {
        Model1 app = new Model1();
        List<Requests> requests;
        public UserRequests()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            requests = app.Requests.Where(u=>u.UserId==HouseholdRepairAbout.Id).ToList();
            RequestList.ItemsSource = requests;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StatusFilter.SelectedIndex == 0)
            {
                requests = app.Requests.Where(u => u.UserId == HouseholdRepairAbout.Id && u.RequestStatus =="Принята").ToList();
                RequestList.ItemsSource = requests;
            }
            if (StatusFilter.SelectedIndex == 1)
            {
                requests = app.Requests.Where(u => u.UserId == HouseholdRepairAbout.Id && u.RequestStatus == "В процессе").ToList();
                RequestList.ItemsSource = requests;
            }
            if (StatusFilter.SelectedIndex == 2)
            {
                requests = app.Requests.Where(u => u.UserId == HouseholdRepairAbout.Id && u.RequestStatus == "Завершена").ToList();
                RequestList.ItemsSource = requests;
            }

        }
    }
}
