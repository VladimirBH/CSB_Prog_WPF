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

namespace CSB_program
{
    /// <summary>
    /// Логика взаимодействия для viewTables.xaml
    /// </summary>
    public partial class viewTables : Window
    {
        int idUser;
        string tableName;
        public viewTables(int _idUser, string _tableName)
        {
            idUser = _idUser;
            tableName = _tableName;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string dataFromTable = @"SELECT * FROM " + tableName + "";
            ConnectionMSSQL conSQL = new ConnectionMSSQL();
            DataTable dt = conSQL.getInDataTable(dataFromTable);
            if (dt == null)
            {
                MessageBox.Show("Что-то пошло не так", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                tableView.ItemsSource = dt.DefaultView;
               // tableView.DataContext = dt;
            }
            switch (tableName) 
            {
                case "employees":
                    labelTitle.Content += "Сотрудники";
                    tableView.Columns[0].Visibility = Visibility.Hidden;
                    tableView.Columns[1].Header = "Фамилия";
                    tableView.Columns[2].Header = "Имя";
                    tableView.Columns[3].Header = "Отчество";
                    tableView.Columns[4].Header = "Дата рождения";
                    tableView.Columns[5].Header = "Номер телефона";
                    tableView.Columns[6].Header = "Адрес проживания";
                    tableView.Columns[7].Header = "Логин";
                    tableView.Columns[8].Header = "Пароль";
                    tableView.Columns[9].Header = "Номер должности";

                    tableView.Columns[4].ClipboardContentBinding.StringFormat = "d";        
                    break;
                case "positions":
                    labelTitle.Content += "Должности";
                    break;
                case "clients":
                    labelTitle.Content += "Клиенты";
                    break;
                case "goods":
                    labelTitle.Content += "Товары";
                    break;
                case "orders":
                    labelTitle.Content += "Заказы";
                    break;
                case "payment_type":
                    labelTitle.Content += "Сопособ оплаты";
                    break;
                case "provider":
                    labelTitle.Content += "Поставщики";
                    break;
                case "purchase_invoce":
                    labelTitle.Content += "Приходные накладные";
                    break;
                case "sales":
                    labelTitle.Content += "Продажи";
                    break;
                case "sales_receipt":
                    labelTitle.Content += "Товарные чеки";
                    break;
                case "categories":
                    labelTitle.Content += "Категории товаров";
                    break;
            }
        }
    }
}
