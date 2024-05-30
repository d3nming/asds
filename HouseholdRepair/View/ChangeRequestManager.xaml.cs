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
    /// Логика взаимодействия для ChangeRequestManager.xaml
    /// </summary>
    public partial class ChangeRequestManager : Window
    {
        Model1 app = new Model1();
        public ChangeRequestManager()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            var load = app.Requests.FirstOrDefault(u => u.Id == HouseholdRepairAbout.SelectedId);
            if (load != null)
            {
                TypeEquipment.Text = load.TypeEquipment;
                DescriptionRepair.Text = load.DescriptionRepair;
                Comments.Text = load.Comments;
                if (load.DateEnd != null)
                {
                    date.SelectedDate = Convert.ToDateTime(load.DateEnd);
                }
                else
                {
                    date.SelectedDate = DateTime.Now;
                    
                }                                
                    var employee = app.Employee
                    .Select(u => u.Id)
                    .Distinct()
                    .ToList();
                    EmployeeId.Items.Clear();
                    foreach (var item in employee)
                    {
                        EmployeeId.Items.Add(item);
                    }
                    if (load.EmployeeId.HasValue && employee.Contains(load.EmployeeId.Value))
                    {
                    EmployeeId.SelectedItem = load.EmployeeId.Value;
                    };
                    


            };
        }

        private void Status_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }              
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var load = app.Requests.FirstOrDefault(u => u.Id == HouseholdRepairAbout.SelectedId);
            if (load != null)
            {
                load.TypeEquipment = TypeEquipment.Text;
                load.DescriptionRepair = DescriptionRepair.Text;
                load.Comments= Comments.Text;
                load.DateEnd = date.SelectedDate;
                load.EmployeeId = Convert.ToInt16(EmployeeId.SelectedItem);
                load.RequestStatus = ((ComboBoxItem)Status.SelectedItem).Content.ToString();
            };
            app.SaveChanges();
            MessageBox.Show("Информация о заявке успешно обновлена");
            this.Close();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Status_Loaded(object sender, RoutedEventArgs e)
        {            
            if (HouseholdRepairAbout.SelectedStatus == ((ComboBoxItem)Status.Items[0]).Content.ToString())
            {
                Status.SelectedIndex = 0;
            }
            if (HouseholdRepairAbout.SelectedStatus == ((ComboBoxItem)Status.Items[1]).Content.ToString())
            {
                Status.SelectedIndex = 1;
            }
            if (HouseholdRepairAbout.SelectedStatus == ((ComboBoxItem)Status.Items[2]).Content.ToString())
            {
                Status.SelectedIndex = 2;
            }
        }
    }
}

                