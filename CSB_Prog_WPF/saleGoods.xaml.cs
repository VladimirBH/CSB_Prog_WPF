using CSB_Prog_WPF.Models;
using CSB_program;
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

namespace CSB_Prog_WPF
{
    /// <summary>
    /// Логика взаимодействия для saleGoods.xaml
    /// </summary>
    public partial class saleGoods : Window
    {
        public int idUser;
        public saleGoods(int _idUser)
        {
            InitializeComponent();
            idUser = _idUser;
        }

        private class Product
        {
            public int id { set; get; }
            public string name_tov { set; get; }
            public int discount { set; get; }
            public decimal price { set; get; }
            public decimal priceWithDiscount { set; get; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string getType = @"SELECT type FROM payment_type";
            ConnectionMSSQL conSql = new ConnectionMSSQL();
            SqlCommand cmdSql = conSql.cmdSql;
            using (conSql.conn)
            {
                conSql.conn.Open();
                cmdSql.CommandType = CommandType.Text;
                cmdSql.CommandText = getType;
                SqlDataReader rdr = cmdSql.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        comboBoxPaymentType.Items.Add(rdr[0]);
                    }
                    rdr.Close();
                    cmdSql.Dispose();
                }
            }
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "№",
                Binding = new Binding("id")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Наименование товара",
                Binding = new Binding("name_tov")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Скидка",
                Binding = new Binding("discount")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Цена без скидки",
                Binding = new Binding("price")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Цена со скидкой",
                Binding = new Binding("priceWithDiscount")
            });
        }
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxProductNumber == null)
            {
                MessageBox.Show("Укажите номер товара!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                string getProduct = @"SELECT id, price, discount, name_pr " + 
                    "FROM goods WHERE id=" + textBoxProductNumber.Text + 
                    " AND id NOT IN (SELECT id_product FROM sales)";
                ConnectionMSSQL conSql = new ConnectionMSSQL();
                SqlCommand cmd = conSql.cmdSql;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = getProduct;
                Product product = new Product();
                using (conSql.conn) 
                {
                    conSql.conn.Open();
                    SqlDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            product.id = (int)rdr.GetValue(0);
                            product.price = (decimal)rdr.GetValue(1);
                            if (rdr.GetValue(2) == DBNull.Value)
                            {
                                product.discount = 0;
                            }
                            else 
                            {
                                product.discount = (int)rdr.GetValue(2);
                            }
                            product.name_tov = (string)rdr.GetValue(3);
                            product.priceWithDiscount = product.price - product.price * product.discount / 100;
                        }
                        rdr.Close();
                        cmd.Dispose();
                        dataGridProducts.Items.Add(product);
                        textBoxProductNumber.Text = "";
                    }
                    else 
                    {
                        MessageBox.Show("Некорректный номер товара!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                
            }
        }

        private void menuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (mbr == MessageBoxResult.Yes)
            {
                dataGridProducts.Items.Remove(dataGridProducts.SelectedItem);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxPaymentType.SelectedIndex == -1)
            {
                MessageBox.Show("Укажите способ оплаты!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                ConnectionMSSQL conSql = new ConnectionMSSQL();
                SqlCommand cmd = conSql.cmdSql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "buy_goods";
                if (textBoxClientNumber.Text == "")
                {
                    cmd.Parameters.Add(new SqlParameter("@id_client", SqlDbType.Int));
                    cmd.Parameters["@id_client"].Value = DBNull.Value;
                }
                else 
                {
                    cmd.Parameters.Add(new SqlParameter("@id_client", SqlDbType.Int));
                    cmd.Parameters["@id_client"].Value = Convert.ToInt32(textBoxClientNumber.Text);
                }
                cmd.Parameters.Add(new SqlParameter("@id_emp", SqlDbType.Int));
                cmd.Parameters["@id_emp"].Value = idUser;
                cmd.Parameters.Add(new SqlParameter("@type_payment", SqlDbType.VarChar));
                cmd.Parameters["@type_payment"].Value = Convert.ToString(comboBoxPaymentType.SelectedValue);
                SqlParameter id_check = new SqlParameter
                {
                    ParameterName = "@id_check",
                    SqlDbType = SqlDbType.Int // тип параметра
                };
                // указываем, что параметр будет выходным
                id_check.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id_check);
                using (conSql.conn) 
                {
                    conSql.conn.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        int id_chk = Convert.ToInt32(cmd.Parameters["@id_check"].Value);
                        if (id_chk is int valueOfA)
                        {
                            cmd.Dispose();
                            for (int i = 0; i < dataGridProducts.Items.Count; i++)
                            {
                                Product product = (Product)dataGridProducts.Items[i];
                                cmd = new SqlCommand("add_sales", conSql.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@id_tov", SqlDbType.VarChar));
                                cmd.Parameters["@id_tov"].Value = product.id;
                                cmd.Parameters.Add(new SqlParameter("@id_check", SqlDbType.Int));
                                cmd.Parameters["@id_check"].Value = id_chk;
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("Что-то пошло не так", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                cmd.Dispose();
                            }
                            MessageBox.Show("Данные успешно добавлены", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            textBoxClientNumber.Text = "";
                            textBoxProductNumber.Text = "";
                            comboBoxPaymentType.SelectedIndex = -1;
                            dataGridProducts.Items.Clear();
                            report_sale_receipt sale_Receipt = new report_sale_receipt(id_chk);
                            sale_Receipt.ShowDialog();
                        }
                        else 
                        {
                            MessageBox.Show("Не удалось получить номер товарного чека", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void textBoxProductNumber_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.D0 && e.Key <= Key.D9);
        }
    }
}
