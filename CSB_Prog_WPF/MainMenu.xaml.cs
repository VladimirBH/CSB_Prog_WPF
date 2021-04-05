using CSB_Prog_WPF;
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


        private string idUser;
        private int accCat;
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
            /*
            ---------------------------------------
            Для 1 уровня доступа

            Orders
            Reports
            BuyGoods - поставка товаров
            Categories
            Goods
            Providers
            SearchProduct - поиск товаров
            Invoices

            ---------------------------------------
            */
            if (accCat == 1)
            {
                btnSaleGoods.Visibility = Visibility.Hidden;
                btnClients.Visibility = Visibility.Hidden;
                btnEmp.Visibility = Visibility.Hidden;
                btnPayType.Visibility = Visibility.Hidden;
                btnPos.Visibility = Visibility.Hidden;
                btnSales.Visibility = Visibility.Hidden;
                btnSaleReceipt.Visibility = Visibility.Hidden;
                btnCatForGds.Visibility = Visibility.Hidden;
                btnReports.Visibility = Visibility.Hidden;
                //Grid.Column = 1
                btnOrders.Margin = new Thickness(0, 10, 10, 0);
                btnBuyGoods.Margin = new Thickness(0, 48, 10, 0);
                btnCat.Margin = new Thickness(0, 86, 10, 0);
                //Grid.Column = 2
                btnGoods.Margin = new Thickness(10, 10, 0, 0);
                btnProviders.Margin = new Thickness(10, 48, 0, 0);
                btnInvoices.Margin = new Thickness(10, 86, 0, 0);
            }
            /*
            ---------------------------------------
            Для 2 уровня доступа

            Categories
            Goods
            SaleGoods - продажа товара
            PaymentType
            SaleReceipt
            Clients
            SearchProduct - поиск товаров
            ---------------------------------------
            */
            else if (accCat == 2)
            {
                btnProviders.Visibility = Visibility.Hidden;
                btnOrders.Visibility = Visibility.Hidden;
                btnBuyGoods.Visibility = Visibility.Hidden;
                btnEmp.Visibility = Visibility.Hidden;
                btnInvoices.Visibility = Visibility.Hidden;
                btnPos.Visibility = Visibility.Hidden;
                btnSales.Visibility = Visibility.Hidden;
                btnCatForGds.Visibility = Visibility.Hidden;
                btnReports.Visibility = Visibility.Hidden;
                //Grid.Column = 1
                btnCat.Margin = new Thickness(0, 10, 10, 0);
                btnSaleGoods.Margin = new Thickness(0, 48, 10, 0);
                btnPayType.Margin = new Thickness(0, 86, 10, 0);
                //Grid.Column = 2
                btnSaleReceipt.Margin = new Thickness(10, 10, 0, 0);
                btnGoods.Margin = new Thickness(10, 48, 0, 0);
                btnClients.Margin = new Thickness(10, 86, 0, 0);
            }
            /*
            ---------------------------------------
            Для 3 и 4 уровней доступа

            Все кроме используемых для связи таблиц
            
            ---------------------------------------
            */
            else if (accCat==3 || accCat == 4)
            {
                btnCatForGds.Visibility = Visibility.Hidden;
                btnSales.Visibility = Visibility.Hidden;
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

        private void openViewTable(string selectedTable) 
        {
            viewTables viewTables = new viewTables(Convert.ToInt32(idUser), selectedTable, accCat);
            viewTables.ShowDialog();
        }

        //Нажатие на кнопку Сотрудники
        private void btnEmp_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("employees");
        }

        //Нажатие на кнопку Должности
        private void btnPos_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("positions");
        }

        //Нажатие на кнопку Товарный чек
        private void btnSaleReceipt_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("sales_receipt");
        }

        //Нажатие на кнопку Товары
        private void btnGoods_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("goods");
        }

        //Нажатие на кнопку Клиенты
        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("clients");
        }

        //Нажатие на кнопку Поставщики
        private void btnProviders_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("provider");
        }

        //Нажатие на кнопку Приходная накладная
        private void btnInvoices_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("purchase_invoice");
        }

        //Нажатие на кнопку Категории для товаров
        private void btnCatForGds_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("goods_categories");
        }

        //Нажатие на кнопку Категории
        private void btnCat_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("categories");
        }

        //Нажатие на кнопку Способ оплаты
        private void btnPayType_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("payment_type");
        }

        //Нажатие на кнопку Заказы
        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("orders");
        }
        
        //Нажатие на кнопку Продажи
        private void btnSales_Click(object sender, RoutedEventArgs e)
        {
            openViewTable("sales");
        }

        //Нажатие на кнопку Отчет по продажам
        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            report_total_amount totalAmount = new report_total_amount();
            totalAmount.ShowDialog();
        }

        //Нажатие на кнопку Покупка товаров
        private void btnBuyGoods_Click(object sender, RoutedEventArgs e)
        {
            saleGoods saleGds = new saleGoods(Convert.ToInt32(idUser));
            saleGds.Show();
        }

        //Нажатие на кнопку Продажа товаров
        private void btnSaleGoods_Click(object sender, RoutedEventArgs e)
        {
            forProduct product = new forProduct(Convert.ToInt32(idUser));
            product.Show();
        }

        //Нажатие на кнопку Поиск товаров
        private void btnSearchProduct_Click(object sender, RoutedEventArgs e)
        {
            report searchProduct = new report();
            searchProduct.ShowDialog();
        }
    }
}
