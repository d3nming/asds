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
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        Model1 app = new Model1();
        //0 пользователь 1 сотрудник 2 менеджер
        public LoginForm()
        {
            InitializeComponent();
        }        
        public void Check()
        {
            if (login.Text == null && password.Password == null)
            {
                MessageBox.Show("Введите логин или пароль");
                return;
            }
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (RolePick.SelectedIndex == 0)
            {
                Check();
                var user = app.User.FirstOrDefault(u => u.login == login.Text && u.password == password.Password);
                {
                    if (user != null)
                    {
                        MessageBox.Show("Авторизация прошла успешно");
                        HouseholdRepairAbout.Id = user.Id;
                        UserForm userForm = new UserForm();
                        userForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                        return;
                    }

                }
            }
            if (RolePick.SelectedIndex == 1)
            {
                Check();
                var user = app.Employee.FirstOrDefault(u => u.login == login.Text && u.password == password.Password);
                {
                    if (user != null)
                    {
                        MessageBox.Show("Авторизация прошла успешно1");
                        
                        HouseholdRepairAbout.Id = user.Id;
                        EmployeeForm employeeForm = new EmployeeForm();
                        employeeForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                        return;
                    }

                }
            }
            if (RolePick.SelectedIndex == 2)
            {
                Check();
                var user = app.Manager.FirstOrDefault(u => u.login == login.Text && u.password == password.Password);
                {
                    if (user != null)
                    {
                        MessageBox.Show("Авторизация прошла успешно");
                        ManagerForm managerForm = new ManagerForm();
                        managerForm.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Неправильный логин или пароль");
                        return;
                    }

                }
            }
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            if (RolePick.SelectedIndex == 0)
            {
                Check();
                if (app.User.Any(u => u.login == login.Text))
                {
                    MessageBox.Show("Пользователь с таким логином уже существует");
                    return;
                }
                var newUser = new User
                {
                    login = login.Text,
                    password = password.Password
                };
                app.User.Add(newUser);
                app.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
            }
            if (RolePick.SelectedIndex == 1)
            {
                Check();
                if (app.Employee.Any(u => u.login == login.Text))
                {
                    MessageBox.Show("Сотрудник с таким логином уже существует");
                    return;
                }
                var newUser = new Employee
                {
                    login = login.Text,
                    password = password.Password
                };
                app.Employee.Add(newUser);
                app.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
            }
            if (RolePick.SelectedIndex == 2)
            {
                Check();
                if (app.Manager.Any(u => u.login == login.Text))
                {
                    MessageBox.Show("Менеджер с таким логином уже существует");
                    return;
                }
                var newUser = new Manager
                {
                    login = login.Text,
                    password = password.Password
                };
                app.Manager.Add(newUser);
                app.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно");
            }
        }
    }
}
