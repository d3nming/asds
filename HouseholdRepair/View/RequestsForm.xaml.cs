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
    /// Логика взаимодействия для RequestsForm.xaml
    /// </summary>
    public partial class RequestsForm : Window
    {
        Model1 app = new Model1();
        List<Requests> requests;
        public RequestsForm()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            requests = app.Requests.ToList();
            RequestList.ItemsSource = requests;
        }
    }
}
