using CSB_Prog_WPF.Models;
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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CSB_program
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {


        public string idUser;
        public int accCat;
        public MainMenu(string _idUser)
        {
            idUser = _idUser;
            InitializeComponent();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string getInfoUser = @"SELECT emp.*, pos.access_category, pos.job_title " +
                "FROM employees emp INNER JOIN positions pos on emp.id_position=pos.id " +
                "WHERE emp.id=" + idUser + ";";
            ConnectionMSSQL conSQL = new ConnectionMSSQL();
            DataTable dt = conSQL.getInDataTable(getInfoUser);
            if (dt == null)
            {
                MessageBox.Show("Что-то пошло не так", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            labelSurname.Content = dt.Rows[0]["surname"].ToString();
            labelNameDadNm.Content = dt.Rows[0]["name"].ToString() + ' ' + dt.Rows[0]["dad_nm"].ToString();
            labelPos.Content = dt.Rows[0]["job_title"].ToString();
            labelAccCat.Content = dt.Rows[0]["access_category"].ToString();
            accCat = Convert.ToInt32(dt.Rows[0]["access_category"]);
            switch (accCat)
            {
                case 1:
                    btnSaleGoods.Visibility = Visibility.Hidden;
                    btnClients.Visibility = Visibility.Hidden;
                    btnEmp.Visibility = Visibility.Hidden;
                    btnPayType.Visibility = Visibility.Hidden;
                    btnPos.Visibility = Visibility.Hidden;
                    btnSales.Visibility = Visibility.Hidden;
                    btnSaleReceipt.Visibility = Visibility.Hidden;
                    //Grid.Column = 1
                    btnOrders.Margin = new Thickness(0, 10, 10, 0);
                    btnReports.Margin = new Thickness(0, 48, 10, 0);
                    btnBuyGoods.Margin = new Thickness(0, 86, 10, 0);
                    btnCat.Margin = new Thickness(0, 124, 10, 0);
                    //Grid.Column = 2
                    btnGoods.Margin = new Thickness(10, 10, 0, 0);
                    btnProviders.Margin = new Thickness(10, 48, 0, 0);
                    btnInvoices.Margin = new Thickness(10, 86, 0, 0);
                    break;
                case 2:
                    btnProviders.Visibility = Visibility.Hidden;
                    btnOrders.Visibility = Visibility.Hidden;
                    btnBuyGoods.Visibility = Visibility.Hidden;
                    btnEmp.Visibility = Visibility.Hidden;
                    btnInvoices.Visibility = Visibility.Hidden;
                    btnPos.Visibility = Visibility.Hidden;
                    //Grid.Column = 1
                    btnSales.Margin = new Thickness(0, 10, 10, 0);
                    btnCat.Margin = new Thickness(0, 48, 10, 0);
                    btnReports.Margin = new Thickness(0, 86, 10, 0);
                    btnSaleGoods.Margin = new Thickness(0, 124, 10, 0);
                    btnPayType.Margin = new Thickness(0, 162, 10, 0);
                    //Grid.Column = 2
                    btnSaleReceipt.Margin = new Thickness(10, 10, 0, 0);
                    btnGoods.Margin = new Thickness(10, 48, 0, 0);
                    btnClients.Margin = new Thickness(10, 86, 0, 0);

                    break;
            }
            try
            {
                using (conSQL.conn)
                {
                    
                }
               
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Не удалось подключиться к базе данных \n" + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {
            viewTables viewTables = new viewTables(Convert.ToInt32(idUser), "employees");
            viewTables.ShowDialog();
        }

        private void btnPos_Click(object sender, RoutedEventArgs e)
        {
            viewTables viewTables = new viewTables(Convert.ToInt32(idUser), "positions");
            viewTables.ShowDialog();
        }
    }
}
