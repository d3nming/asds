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
    /// Логика взаимодействия для ManagerListForm.xaml
    /// </summary>
    public partial class ManagerListForm : Window
    {
        Model1 app = new Model1();
        List<Requests> requests;
        public ManagerListForm()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            requests = app.Requests.ToList();
            RequestList.ItemsSource = requests;
        }    
        private void StatusFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StatusFilter.SelectedIndex == 0)
            {
                requests = app.Requests.Where(u =>  u.RequestStatus == "Принята").ToList();
                RequestList.ItemsSource = requests;
            }
            if (StatusFilter.SelectedIndex == 1)
            {
                requests = app.Requests.Where(u => u.RequestStatus == "В процессе").ToList();
                RequestList.ItemsSource = requests;
            }
            if (StatusFilter.SelectedIndex == 2)
            {
                requests = app.Requests.Where(u =>  u.RequestStatus == "Выполнена").ToList();
                RequestList.ItemsSource = requests;
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void change_Click(object sender, RoutedEventArgs e)
        {
            int selectedItem = ((Requests)RequestList.SelectedItem).Id;
            string selectedStatus = ((Requests)RequestList.SelectedItem).RequestStatus;
            HouseholdRepairAbout.SelectedId = selectedItem;
            HouseholdRepairAbout.SelectedStatus = selectedStatus;
            if (selectedItem != null)
            {
                ChangeRequestManager changeRequestManager = new ChangeRequestManager();
                changeRequestManager.ShowDialog();
                Load();
            }
            else
            {
                MessageBox.Show("Выберите заявку для редактирования");
            }

        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите сохранить изменения?", "Подтверждение сохранения", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                Button btn = sender as Button;
                int Id = Convert.ToInt32(btn.Tag.ToString());
                var remove = app.Requests.FirstOrDefault(u => u.Id == Id);
                app.Requests.Remove(remove);
                app.SaveChanges();
                MessageBox.Show("Заявка удалена");
                Load();
            }
        }
    }
}
            //int selectedItem = ((Request)RequestListBox.SelectedItem).Id;
            //RequestInfo.Id = selectedItem;
            //MessageBox.Show(Convert.ToString(RequestInfo.Id));
            //if (selectedItem != null)
            //{
            //    EditWindow editWindow = new EditWindow();
            //    editWindow.ShowDialog();
            //    LoadRequests();
            //}
            //else
            //{
            //    MessageBox.Show("Выберите заявку для редактирования.");
            //}