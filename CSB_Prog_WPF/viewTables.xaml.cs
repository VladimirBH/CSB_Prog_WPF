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

namespace CSB_program
{
    /// <summary>
    /// Логика взаимодействия для viewTables.xaml
    /// </summary>
    public partial class viewTables : Window
    {
        int idUser;
        string tableName;
        int accCat;
        public viewTables(int _idUser, string _tableName, int _accCat)
        {
            idUser = _idUser;
            tableName = _tableName;
            accCat = _accCat;
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
            /*
            ---------------------------------------------------------
            Суть уровней доступа:

            1 уровень:

            Доступны таблицы 
            ---------------------------------------------------------
             */
            switch (tableName) 
            {
                case "employees":

                    if (accCat == 3) 
                    {
                        tableView.ContextMenu.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Hidden;
                    }

                    labelTitle.Content += "Сотрудники";
                    tableView.Columns[0].Header = "Номер сотрудника";
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

                    if (accCat == 3)
                    {
                        tableView.ContextMenu.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Hidden;
                    }

                    labelTitle.Content += "Должности";
                    tableView.Columns[0].Header = "Номер должности";
                    tableView.Columns[1].Header = "Наименование должности";
                    tableView.Columns[2].Header = "Уровень доступа";
                    tableView.Columns[3].Header = "Оклад";
                    tableView.Columns[4].Header = "Разряд (если есть)";

                    break;
                case "clients":
                    if (accCat < 4) 
                    {
                        deleteMenuItem.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                    }
                    labelTitle.Content += "Клиенты";
                    tableView.Columns[0].Header = "Номер клиента";
                    tableView.Columns[1].Header = "Фамилия";
                    tableView.Columns[2].Header = "Имя";
                    tableView.Columns[3].Header = "Отчество";
                    tableView.Columns[4].Header = "Адрес проживания";
                    tableView.Columns[5].Header = "Номер телефона";
                    tableView.Columns[6].Header = "Количество баллов";
                    tableView.Columns[7].Header = "Дата рождения";

                    tableView.Columns[7].ClipboardContentBinding.StringFormat = "d";
                    break;
                case "goods":
                    if (accCat < 5)
                    {
                        addMenuItem.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                    }
                    labelTitle.Content += "Товары";
                    tableView.Columns[0].Header = "Номер товара";
                    tableView.Columns[1].Header = "Наименование товара";
                    tableView.Columns[2].Header = "Расположение товара";
                    tableView.Columns[3].Header = "Скидка (если есть)";
                    tableView.Columns[4].Header = "Причина скидки (если есть)";
                    tableView.Columns[5].Header = "Цена";
                    tableView.Columns[6].Header = "Номер заказа";

                    break;
                case "orders":
                    if (accCat < 5) 
                    {
                        tableView.ContextMenu.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Hidden;
                    }

                    labelTitle.Content += "Заказы";
                    tableView.Columns[0].Header = "Номер заказа";
                    tableView.Columns[1].Header = "Номер накладной";
                    tableView.Columns[2].Header = "Наименование товара";
                    tableView.Columns[3].Header = "Количество";
                    tableView.Columns[4].Header = "Цена без учета НДС";
                    tableView.Columns[5].Header = "НДС";

                    break;
                case "payment_type":
                    labelTitle.Content += "Сопособ оплаты";
                    tableView.Columns[0].Header = "Номер способа";
                    tableView.Columns[1].Header = "Способ";

                    break;
                case "provider":
                    labelTitle.Content += "Поставщики";
                    tableView.Columns[0].Header = "Номер Поставщика";
                    tableView.Columns[1].Header = "Юр. адрес";
                    tableView.Columns[2].Header = "Номер телефона";
                    tableView.Columns[3].Header = "Наименование организации";

                    break;
                case "purchase_invoce":

                    if (accCat < 5)
                    {
                        tableView.ContextMenu.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Hidden;
                    }

                    labelTitle.Content += "Приходные накладные";
                    tableView.Columns[0].Header = "Номер накладной";
                    tableView.Columns[1].Header = "Номер поставщика";
                    tableView.Columns[2].Header = "Дата составления накладной";
                    tableView.Columns[3].Header = "Дата поставки";

                    tableView.Columns[2].ClipboardContentBinding.StringFormat = "d";
                    tableView.Columns[3].ClipboardContentBinding.StringFormat = "d";

                    break;
                case "sales":
                    labelTitle.Content += "Продажи";
                    tableView.Columns[0].Header = "Номер Продажи";
                    tableView.Columns[1].Header = "Номер чека";
                    tableView.Columns[2].Header = "Дата товара";

                    break;
                case "sales_receipt":

                    if (accCat == 3)
                    {
                        tableView.ContextMenu.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Hidden;
                    }

                    labelTitle.Content += "Товарные чеки";
                    tableView.Columns[0].Header = "Номер чека";
                    tableView.Columns[1].Header = "Дата покупки";
                    tableView.Columns[2].Header = "Номер клиента";
                    tableView.Columns[3].Header = "Номер сотрудника";
                    tableView.Columns[4].Header = "Способ оплаты";

                    break;
                case "categories":
                    labelTitle.Content += "Категории товаров";
                    tableView.Columns[0].Header = "Номер категории";
                    tableView.Columns[1].Header = "Категория";

                    break;
            }
        }

        private void delete_record(int id) 
        {
            
        }
        private void add_record() 
        {
            switch (tableName) 
            {
                case "employees":
                    forEmployee emp = new forEmployee(0);
                    emp.ShowDialog();
                    break;
                case "positions":
                    break;
                case "clients":
                    forClient cli = new forClient(0);
                    cli.ShowDialog();
                    break;
                case "provider":
                    break;
                case "salesReceipt":
                    break;
                case "sales":
                    break;
                case "categories":
                    break;
                case "orders":
                    break;
                case "purchase_invoice":
                    break;
                case "goods_categories":
                    break;
                case "goods":
                    break;
                case "payment_type":
                    break;
            }
        }
        private void edit_record() 
        {
            DataRowView dataRowView = (DataRowView)tableView.SelectedItem;
            int idRec = Convert.ToInt32(dataRowView["id"]);
            switch (tableName)
            {
                case "employees":
                    forEmployee emp = new forEmployee(idRec);
                    emp.ShowDialog();
                    break;
                case "positions":
                    break;
                case "clients":
                    forClient cli = new forClient(idRec);
                    cli.ShowDialog();
                    break;
                case "provider":
                    break;
                case "salesReceipt":
                    break;
                case "sales":
                    break;
                case "categories":
                    break;
                case "orders":
                    break;
                case "purchase_invoice":
                    break;
                case "goods_categories":
                    break;
                case "goods":
                    break;
                case "payment_type":
                    break;
            }
            tableView.Items.Refresh();
        }

        //Добавление
        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            add_record();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            add_record();
        }

        //Редактирование
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            edit_record();
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            edit_record();
        }

        //Удаление
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        //Следующая запись
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (tableView.SelectedIndex == -1 || tableView.SelectedIndex == tableView.Items.Count - 1)
            {
                tableView.SelectedIndex = 0;
            }
            else
            {
                tableView.SelectedIndex += 1;
            }
        }

        //Предыдущая запись
        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (tableView.SelectedIndex == -1)
            {
                tableView.SelectedIndex = 0;
            }
            else if (tableView.SelectedIndex == 0)
            {
                tableView.SelectedIndex = tableView.Items.Count - 1;
            }
            else 
            {
                tableView.SelectedIndex -= 1;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            tableView.Items.Refresh();
        }
    }
}
