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
    /// Логика взаимодействия для RequestAddForm.xaml
    /// </summary>
    public partial class RequestAddForm : Window
    {
        Model1 app = new Model1();
        public RequestAddForm()
        {
            InitializeComponent();
        }        
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TypeEquipment.Text) || string.IsNullOrEmpty(DescriptionRepair.Text) ||
                string.IsNullOrEmpty(Comments.Text)
                )
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            var NewRequests = new Requests
            {
                DateStart = DateTime.Now,
                UserId = HouseholdRepairAbout.Id,
                TypeEquipment = TypeEquipment.Text,
                DescriptionRepair = DescriptionRepair.Text,
                Comments = Comments.Text,
                RequestStatus = "Принята"
            };
            app.Requests.Add(NewRequests);
            app.SaveChanges();
            MessageBox.Show("Заявка успешно добавлена");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
