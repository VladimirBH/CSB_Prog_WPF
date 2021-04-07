using CSB_Prog_WPF.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace CSB_program
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlCommand cmd;
        private string sqlCmd;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void btn_Submit_Click(object sender, RoutedEventArgs e) 
        {
            ConnectionMSSQL connMSSQl = new ConnectionMSSQL();

            string idUser = "";
            string hashPassFromDB = "";
            bool enter = false;
            if (textboxLogin.Text != "" && textboxPass.Text != "")
            {
                try
                {
                    using (SqlConnection cn = connMSSQl.conn)
                    {
                        cn.Open();
                        sqlCmd = @"select id, password from employees " +
                            "where login='" + textboxLogin.Text + "';";
                        cmd = new SqlCommand();
                        cmd.Connection = cn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = sqlCmd;
                        SqlDataReader rdr;
                        if ((rdr = cmd.ExecuteReader()) != null)
                        {
                            while (rdr.Read())
                            {
                                idUser = rdr.GetValue(0).ToString();
                                hashPassFromDB = rdr.GetValue(1).ToString();
                            }
                            bool isValidPassword = false;
                            try
                            {
                                isValidPassword = BCrypt.Net.BCrypt.Verify(passboxPass.Password, hashPassFromDB);
                            }
                            catch (ArgumentException ex) 
                            {
                                
                            }
                            
                            if (isValidPassword)
                            {
                                enter = true;
                            }
                            else
                            {
                                MessageBox.Show("Неверный логин/пароль. \n ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else 
                        {
                            MessageBox.Show("Неверный логин/пароль. \n ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        cmd.Dispose();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Не удалось подключиться к базе данных \n" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else 
            {
                MessageBox.Show("Заполните все поля!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (enter)
            {
                MessageBox.Show("Вход выполнен успешно", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Hide();
                MainMenu mainMenu = new MainMenu(idUser);
                mainMenu.Show();
            }
        }

        private void textboxPass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (passboxPass.Password == "")
            {
                textboxPass.Visibility = Visibility.Visible;
                passboxPass.Visibility = Visibility.Hidden;
            }
        }

        private void textboxPass_GotFocus(object sender, RoutedEventArgs e)
        {
            textboxPass.Visibility = Visibility.Hidden;
            passboxPass.Visibility = Visibility.Visible;
            passboxPass.Focus();
        }

        private void textboxLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textboxLogin.Text == "")
            {
                textboxLogin.Text = "login";
            }
        }

        private void textboxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            textboxLogin.Text = "";
        }
    }
}
