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
            }
            btnFormInvoice.Visibility = Visibility.Hidden;
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

                    labelTitle.Content = "Сотрудники";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Фамилия";
                    tableView.Columns[2].Header = "Имя";
                    tableView.Columns[3].Header = "Отчество";
                    tableView.Columns[4].Header = "Дата рождения";
                    tableView.Columns[5].Header = "Номер телефона";
                    tableView.Columns[6].Header = "Адрес проживания";
                    tableView.Columns[7].Header = "Логин";
                    tableView.Columns[8].Header = "Пароль";
                    tableView.Columns[9].Header = "Номер должности";

                    tableView.Columns[4].ClipboardContentBinding.StringFormat = "dd.MM.yyyy";        
                    break;
                case "positions":

                    if (accCat == 3)
                    {
                        tableView.ContextMenu.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Hidden;
                    }

                    labelTitle.Content = "Таблица Должности";
                    tableView.Columns[0].Header = "№";
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
                    labelTitle.Content = "Таблица Клиенты";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Фамилия";
                    tableView.Columns[2].Header = "Имя";
                    tableView.Columns[3].Header = "Отчество";
                    tableView.Columns[4].Header = "Адрес проживания";
                    tableView.Columns[5].Header = "Номер телефона";
                    tableView.Columns[6].Header = "Количество баллов";
                    tableView.Columns[7].Header = "Дата рождения";

                    tableView.Columns[7].ClipboardContentBinding.StringFormat = "dd.MM.yyyy";
                    break;
                case "goods":
                    if (accCat < 5)
                    {
                        addMenuItem.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                    }
                    labelTitle.Content = "Таблица Товары";
                    tableView.Columns[0].Header = "№";
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

                    labelTitle.Content = "Таблица Заказы";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Номер накладной";
                    tableView.Columns[2].Header = "Наименование товара";
                    tableView.Columns[3].Header = "Количество";
                    tableView.Columns[4].Header = "Цена без учета НДС";
                    tableView.Columns[5].Header = "НДС";

                    break;
                case "payment_type":
                    labelTitle.Content += "Сопособ оплаты";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Способ";

                    break;
                case "provider":
                    labelTitle.Content = "Таблица Поставщики";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Юр. адрес";
                    tableView.Columns[2].Header = "Номер телефона";
                    tableView.Columns[3].Header = "Наименование организации";
                    break;
                case "purchase_invoice":
                    btnFormInvoice.Visibility = Visibility.Visible;
                    if (accCat < 5)
                    {
                        tableView.ContextMenu.Visibility = Visibility.Hidden;
                        btnAdd.Visibility = Visibility.Hidden;
                        btnDelete.Visibility = Visibility.Hidden;
                        btnEdit.Visibility = Visibility.Hidden;
                    }

                    labelTitle.Content = "Таблица Приходные накладные";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Номер поставщика";
                    tableView.Columns[2].Header = "Дата составления накладной";
                    tableView.Columns[3].Header = "Дата поставки";

                    tableView.Columns[2].ClipboardContentBinding.StringFormat = "dd.MM.yyyy";
                    tableView.Columns[3].ClipboardContentBinding.StringFormat = "dd.MM.yyyy";

                    break;
                case "sales":
                    labelTitle.Content = "Таблица Продажи";
                    tableView.Columns[0].Header = "№";
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

                    labelTitle.Content = "Таблица Товарные чеки";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Дата покупки";
                    tableView.Columns[2].Header = "Номер клиента";
                    tableView.Columns[3].Header = "Номер сотрудника";
                    tableView.Columns[4].Header = "Способ оплаты";

                    break;
                case "categories":
                    labelTitle.Content = "Таблица Категории товаров";
                    tableView.Columns[0].Header = "Номер категории";
                    tableView.Columns[1].Header = "Категория";

                    break;
                case "goods_categories":
                    labelTitle.Content = "Таблица Товары-Категории";
                    tableView.Columns[0].Header = "№";
                    tableView.Columns[1].Header = "Номер товара";
                    tableView.Columns[2].Header = "Номер категории";
                    break;
            }
            tableView.Columns[0].IsReadOnly = true;
        }

        //Метод удаления данных
        private void delete_record() 
        {
            string action = "DELETE";
            DataRowView row = (DataRowView)tableView.Items[tableView.SelectedIndex];
            if (row != null) 
            {
                MessageBoxResult res = MessageBox.Show("Вы действительно хотите удалить запись?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (res == MessageBoxResult.Yes)
                {
                    int idRec = Convert.ToInt32(row["id"]);
                    switch (tableName)
                    {
                        case "employees":
                            MessageBoxResult rsEmp = MessageBox.Show("Возможно к этой записи привязаны данные, вы хотите удалить/изменить и их?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (rsEmp == MessageBoxResult.Yes)
                            {
                                delStoredProcedure("delete_employees", idRec);
                            }
                            else
                            {
                                MessageBox.Show("Операция отменена");
                            }
                            break;
                        case "positions":
                            string delPos = String.Format("DELETE FROM positions WHERE id={0}", idRec);
                            break;
                        case "clients":
                            MessageBoxResult rsCli = MessageBox.Show("Возможно к этой записи привязаны данные, вы хотите удалить/изменить и их?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            if (rsCli == MessageBoxResult.Yes)
                            {
                                delStoredProcedure("delete_clients", idRec);
                            }
                            else
                            {
                                MessageBox.Show("Операция отменена");
                            }
                            break;
                        case "provider":
                            string delProvider = String.Format("DELETE FROM provider WHERE id={0}", idRec);
                            actionWithDB(delProvider, action);
                            break;
                        case "sales_receipt":
                            string delSalesReceipt = String.Format("DELETE FROM sales_receipt WHERE id={0}", idRec);
                            actionWithDB(delSalesReceipt, action);
                            break;
                        case "sales":
                            string delSales = String.Format("DELETE FROM sales WHERE id={0}", idRec);
                            actionWithDB(delSales, action);
                            break;
                        case "categories":
                            string delCategories = String.Format("DELETE FROM categories WHERE id={0}", idRec);
                            actionWithDB(delCategories, action);
                            break;
                        case "orders":
                            string delOrders = String.Format("DELETE FROM orders WHERE id={0}", idRec);
                            actionWithDB(delOrders, action);
                            break;
                        case "purchase_invoice":
                            string delPurchaseInvoice = String.Format("DELETE FROM purchase_invoice WHERE id={0}", idRec);
                            actionWithDB(delPurchaseInvoice, action);
                            break;
                        case "goods_categories":
                            string delGoodsCategories = String.Format("DELETE FROM goods_categories WHERE id={0}", idRec);
                            actionWithDB(delGoodsCategories, action);
                            break;
                        case "goods":
                                MessageBoxResult rsGds = MessageBox.Show("Возможно к этой записи привязаны данные, вы хотите удалить/изменить и их?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                                if (rsGds == MessageBoxResult.Yes)
                                {
                                    delStoredProcedure("delete_goods", idRec);
                                }
                                else
                                {
                                    MessageBox.Show("Операция отменена");
                                }
                            break;
                        case "payment_type":
                            string delPaymentType = String.Format("DELETE FROM payment_type WHERE id={0}", idRec);
                            actionWithDB(delPaymentType, action);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Операция отменена");
                }
            }
        }
        //Метод добавления данных
        private void add_record() 
        {
            string action = "INSERT";
            if (tableName == "employees")
            {
                forEmployee emp = new forEmployee(0);
                emp.ShowDialog();
            }
            else if (tableName == "provider")
            {
                forProvider provider = new forProvider(0);
                provider.ShowDialog();
            }
            else if (tableName == "clients")
            {
                forClient cli = new forClient(0);
                cli.ShowDialog();
            }
            else 
            {
                DataRowView row = (DataRowView)tableView.SelectedItem;
                if (row != null)
                {
                    switch (tableName)
                    {
                        case "positions":
                            string addPositions = String.Format(@"INSERT INTO positions (job_title, access_category, salary, category) " +
                                " VALUES " +
                                "('{0}', {1}, {2}, {3})", row["job_title"], row["access_category"], Convert.ToString(row["salary"]).Replace(',', '.'), row["category"]);
                            actionWithDB(addPositions, action);
                            break;
                        case "sales_receipt":
                            string addSalesReceipt = String.Format(@"INSERT INTO sales_receipt (date_buy, id_client, id_emp, type_payment) " +
                                " VALUES " +
                                "('{0}', {1}, {2}, {3})", row["date_buy"], row["id_client"], row["id_emp"], row["type_payment"]);
                            actionWithDB(addSalesReceipt, action);
                            break;
                        case "sales":
                            string addSales = String.Format(@"INSERT INTO sales (id_receipt, id_product) " +
                                " VALUES " +
                                "({0}, {1})", row["id_receipt"], row["id_product"]);
                            actionWithDB(addSales, action);
                            break;
                        case "categories":
                            string addCategories = String.Format("INSERT INTO categories (\"text\") " +
                                " VALUES " +
                                "('{0}')", row["text"]);
                            actionWithDB(addCategories, action);
                            break;
                        case "orders":
                            string addOrders = String.Format(@"INSERT INTO orders (id_invoice, name_gds, count_gds, cost_gds_wo_vat, vat) " +
                                " VALUES " +
                                "({0}, '{1}', {2}, {3}, {4})", row["id_invoice"], row["name_gds"], row["count_gds"],
                                Convert.ToString(row["cost_gds_wo_vat"]).Replace(',', '.'), Convert.ToString(row["vat"]).Replace(',', '.'));
                            actionWithDB(addOrders, action);
                            break;
                        case "purchase_invoice":
                            string addPurchaseInvoice = String.Format(@"INSERT INTO purchase_invoice (id_provider, date_receipt, date_delivery) " +
                                " VALUES " +
                                "({0}, '{1}', '{2}')", row["id_provider"], row["date_receipt"], row["date_delivery"]);
                            actionWithDB(addPurchaseInvoice, action);
                            break;
                        case "goods_categories":
                            string addGoodsCategories = String.Format(@"INSERT INTO goods_categories (idProduct, idCat)" +
                                " VALUES " +
                                "({0}, {1})", row["idProduct"], row["idCat"]);
                            actionWithDB(addGoodsCategories, action);
                            break;
                        case "goods":
                            string addGoods = String.Format(@"INSERT INTO goods (name_pr, loc_product, discount, discnt_reason, price, id_order) " +
                                " VALUES " +
                                "('{0}', '{1}', {2}, '{3}', {4}, {5})", row["name_pr"], row["loc_product"],
                                row["discount"], row["discnt_reason"], Convert.ToString(row["price"]).Replace(',', '.'), row["id_order"]);
                            actionWithDB(addGoods, action);
                            break;
                        case "payment_type":
                            string addPaymentType = String.Format("INSERT INTO payment_type (\"type\") " +
                                " VALUES " +
                                "('{0}')", row["type"]);
                            actionWithDB(addPaymentType, action);
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Выбрана неверная запись!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        //Метод изменения данных
        private void edit_record() 
        {
            string action = "UPDATE";
            DataRowView row = (DataRowView)tableView.SelectedItem;
            if (row != null) 
            {
                int idRec = Convert.ToInt32(row["id"]);
                switch (tableName)
                {
                    case "employees":
                        forEmployee emp = new forEmployee(idRec);
                        emp.ShowDialog();
                        break;
                    case "clients":
                        forClient cli = new forClient(idRec);
                        cli.ShowDialog();
                        break;
                    case "provider":
                        forProvider provider = new forProvider(idRec);
                        provider.ShowDialog();
                        break;
                    case "positions":
                        string editPositions = String.Format("UPDATE positions SET job_title = '{0}', access_category={1}, salary='{2}', category={3} WHERE id={4}",
                            row["job_title"], row["access_category"], Convert.ToString(row["salary"]).Replace(',', '.'), row["category"], row["id"]);
                        actionWithDB(editPositions, action);
                        break;
                    case "salesReceipt":
                        string editSalesReceipt = String.Format("UPDATE sales_receipt SET date_buy = '{0}', id_client={1}, id_emp={2}, type_payment={3} WHERE id={4}",
                            row["date_buy"], row["id_client"], row["id_emp"], row["type_payment"], row["id"]);
                        actionWithDB(editSalesReceipt, action);
                        break;
                    case "sales":
                        string editSales = String.Format("UPDATE sales SET date_buy = '{0}', id_client ={1}, id_emp ={2}, type_payment = {3} WHERE id = {4}",
                            row["date_buy"], row["id_client"], row["id_emp"], row["type_payment"], row["id"]);
                        actionWithDB(editSales, action);
                        break;
                    case "categories":
                        string editCategories = String.Format("UPDATE categories SET \"text\" = '{0}' WHERE id = {1}",
                            row["text"], row["id"]);
                        actionWithDB(editCategories, action);
                        break;
                    case "orders":
                        string editSOrders = String.Format("UPDATE orders SET id_invoice = {0}, name_gds ='{1}', count_gds ={2}, cost_gds_wo_vat = {3}, vat = {4} WHERE id = {5}",
                            row["id_invoice"], row["name_gds"], row["count_gds"], Convert.ToString(row["cost_gds_wo_vat"]).Replace(',', '.'),
                            Convert.ToString(row["vat"]).Replace(',', '.'), row["id"]);
                        actionWithDB(editSOrders, action);
                        break;
                    case "purchase_invoice":
                        string editPurchaseInvoices = String.Format("UPDATE purchase_invoice SET id_provider = {0}, date_receipt ='{1}', date_delivery ='{2}' WHERE id = {3}",
                            row["id_provider"], row["date_receipt"], row["date_delivery"], row["id"]);
                        actionWithDB(editPurchaseInvoices, action);
                        break;
                    case "goods_categories":
                        string editGoodsCategories = String.Format("UPDATE goods_categories SET idProduct = {0}, idCat ={1} WHERE id = {3}",
                            row["idProduct"], row["idCat"], row["id"]);
                        actionWithDB(editGoodsCategories, action);
                        break;
                    case "goods":
                        string editGoods = String.Format("UPDATE goods SET name_pr = '{0}', loc_product ='{1}', discount ='{2}', discnt_reason = '{3}', price= {4}, id_order= {5} WHERE id = {6}",
                            row["name_pr"], row["loc_product"],
                            row["discount"], row["discnt_reason"],
                            Convert.ToString(row["price"]).Replace(',', '.'),
                            row["id_order"], row["id"]);
                        actionWithDB(editGoods, action);
                        break;
                    case "payment_type":
                        string editPaymentType = String.Format("UPDATE payment_type SET \"type\" = '{0}' WHERE id = {1}",
                            row["type"], row["id"]);
                        actionWithDB(editPaymentType, action);
                        break;
                }
            }
            else 
            {
                MessageBox.Show("Выберите запись для редактирования!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            
        }

        //Добавление
        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            add_record();
            Window_Loaded(sender, e);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            add_record();
            Window_Loaded(sender, e);
        }

        //Редактирование
        private void MenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            edit_record();
            Window_Loaded(sender, e);
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            edit_record();
            Window_Loaded(sender, e);
        }

        //Удаление
        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            delete_record();
            Window_Loaded(sender, e);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            delete_record();
            Window_Loaded(sender, e);
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

        //Нажатие на кнопку сформировать накладную
        private void btnFormInvoice_Click(object sender, RoutedEventArgs e)
        {
            DataRowView dataRowView = (DataRowView)tableView.SelectedItem;
            if (dataRowView == null)
            {
                MessageBox.Show("Выберите запись!", "Внимание!!!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else 
            {
                int idRec = Convert.ToInt32(dataRowView["id"]);
                report_invoice formInvoice = new report_invoice(idRec);
                formInvoice.ShowDialog();
            }
        }

        //Нажатие на кнопку обновить записи
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Window_Loaded(sender, e);
        }

        //Для действий с данными БД
        private void actionWithDB(string query, string action)
        {
            
            ConnectionMSSQL conSQL = new ConnectionMSSQL();
            SqlCommand cmd = conSQL.cmdSql;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            try
            {
                using (conSQL.conn)
                {
                    conSQL.conn.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        if (action == "INSERT")
                        {
                            MessageBox.Show("Данные успешно добавлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (action == "UPDATE")
                        {
                            MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if(action == "DELETE") 
                        {
                            MessageBox.Show("Данные успешно удалены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    else 
                    {
                        if (action == "INSERT")
                        {
                            MessageBox.Show("Не удалось добавить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (action == "UPDATE")
                        {
                            MessageBox.Show("Не удалось обновить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else if (action == "DELETE")
                        {
                            MessageBox.Show("Не удалось удалить запись", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (SqlException ex) 
            {
                if (action == "DELETE") 
                {
                    MessageBox.Show("Возможно к удаляемой записи привязаны данные из других таблиц", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        //Для вызова хранимых процедур
        private void delStoredProcedure(string procedureName, int idRec) 
        {
            ConnectionMSSQL conSQL = new ConnectionMSSQL();
            SqlCommand cmd = conSQL.cmdSql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = procedureName;
            try
            {
                using (conSQL.conn)
                {
                    conSQL.conn.Open();
                    cmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int));
                    cmd.Parameters["@id"].Value = idRec;
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Данные успешно удалены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить записи", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Что-то пошло не так", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
