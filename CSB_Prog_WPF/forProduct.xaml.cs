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

namespace CSB_Prog_WPF
{
    /// <summary>
    /// Логика взаимодействия для forProduct.xaml
    /// </summary>
    public partial class forProduct : Window
    {
        private int idUser;
        public forProduct(int _idUser)
        {
            InitializeComponent();
            idUser = _idUser;
        }
        private class Product 
        {
            public string name_tov { set; get; }
            public string nameCat { set; get; }
            public int count { set; get; }
            public decimal cost { set; get; }
            public decimal vat { set; get; }
            public decimal price { set; get; }
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string getProvs = @"SELECT name_org FROM provider";
            string getCat = @"SELECT text FROM categories";
            ConnectionMSSQL conSql = new ConnectionMSSQL();
            SqlCommand cmdSql = conSql.cmdSql;
            using (conSql.conn) 
            {
                conSql.conn.Open();
                cmdSql.CommandType = CommandType.Text;
                cmdSql.CommandText = getProvs;
                SqlDataReader rdr = cmdSql.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        comboBoxProvider.Items.Add(rdr[0]);
                    }
                    rdr.Close();
                    cmdSql.Dispose();
                }
                cmdSql = new SqlCommand(getCat, conSql.conn);
                rdr = cmdSql.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        comboBoxCategory.Items.Add(rdr[0]);
                    }
                    rdr.Close();
                    cmdSql.Dispose();
                }
            }
            dataGridProducts.Columns.Add(new DataGridTextColumn 
            {
                Header = "Наименование товара",
                Binding = new Binding("name_tov")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Количество товара",
                Binding = new Binding("count")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Цена товара",
                Binding = new Binding("cost")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Ставка НДС",
                Binding = new Binding("vat")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Розничная цена",
                Binding = new Binding("price")
            });
            dataGridProducts.Columns.Add(new DataGridTextColumn
            {
                Header = "Категория товара",
                Binding = new Binding("nameCat")
            });
        }

        //Нажатие на кнопку Добавить
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxNameProduct == null || textBoxCountGds == null || textBoxCostWithoutVat == null
                || textBoxVat == null || textBoxRetailCost == null)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                dataGridProducts.Items.Add(new Product() 
                {
                    name_tov = textBoxNameProduct.Text, 
                    count = Convert.ToInt32(textBoxCountGds.Text),
                    cost = Convert.ToDecimal(textBoxCostWithoutVat.Text),
                    vat = Convert.ToDecimal(textBoxVat.Text), 
                    price = Convert.ToDecimal(textBoxRetailCost.Text),
                    nameCat = (string)comboBoxCategory.SelectedValue
                });
            }

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerDateCompilation == null || datePickerDateDelivery == null || comboBoxProvider.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                ConnectionMSSQL conSql = new ConnectionMSSQL();
                SqlCommand cmd = conSql.cmdSql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "add_invoice";
                cmd.Parameters.Add(new SqlParameter("@name_org", SqlDbType.VarChar));
                cmd.Parameters["@name_org"].Value = comboBoxProvider.SelectedValue.ToString();
                cmd.Parameters.Add(new SqlParameter("@date_receipt", SqlDbType.Date));
                cmd.Parameters["@date_receipt"].Value = datePickerDateCompilation.SelectedDate;
                cmd.Parameters.Add(new SqlParameter("@date_del", SqlDbType.Date));
                cmd.Parameters["@date_del"].Value = datePickerDateDelivery.SelectedDate;
                SqlParameter id_invoice = new SqlParameter
                {
                    ParameterName = "@id_inv",
                    SqlDbType = SqlDbType.Int // тип параметра
                };
                // указываем, что параметр будет выходным
                id_invoice.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(id_invoice);
                using (conSql.conn) 
                {
                    conSql.conn.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        int id_inv = Convert.ToInt32(cmd.Parameters["@id_inv"].Value);
                        if (id_inv is int valueOfA)
                        {
                            cmd.Dispose();
                            for (int i = 0; i < dataGridProducts.Items.Count; i++)
                            {
                                Product product = (Product)dataGridProducts.Items[i];
                                cmd = new SqlCommand("add_goods_order", conSql.conn);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.Add(new SqlParameter("@name_tov", SqlDbType.VarChar));
                                cmd.Parameters["@name_tov"].Value = product.name_tov;
                                cmd.Parameters.Add(new SqlParameter("@id_invoice", SqlDbType.Int));
                                cmd.Parameters["@id_invoice"].Value = id_inv;
                                cmd.Parameters.Add(new SqlParameter("@price", SqlDbType.Decimal));
                                cmd.Parameters["@price"].Value = product.price;
                                cmd.Parameters.Add(new SqlParameter("@cost_tov", SqlDbType.Decimal));
                                cmd.Parameters["@cost_tov"].Value = product.cost;
                                cmd.Parameters.Add(new SqlParameter("@count_tov", SqlDbType.Int));
                                cmd.Parameters["@count_tov"].Value = product.count;
                                cmd.Parameters.Add(new SqlParameter("@vat", SqlDbType.Int));
                                cmd.Parameters["@vat"].Value = product.vat;
                                cmd.Parameters.Add(new SqlParameter("@category", SqlDbType.VarChar));
                                cmd.Parameters["@category"].Value = product.nameCat;
                                if (cmd.ExecuteNonQuery() == 0)
                                {
                                    MessageBox.Show("Что-то пошло не так", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                cmd.Dispose();
                            }
                            MessageBox.Show("Данные успешно добавлены", "Успех", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            dataGridProducts.Items.Clear();
                        }
                        else 
                        {
                            MessageBox.Show("Не удалось получить номер приходной накладной", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        }   
                        
                    }
                    else 
                    {
                        MessageBox.Show(this, "Данные не добавлены", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void menuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("Вы уверены, что хотите удалить запись?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (mbr == MessageBoxResult.Yes) 
            {
                dataGridProducts.Items.Remove(dataGridProducts.SelectedItem);
            }
        }

        private void textBoxCountGds_KeyDown(object sender, KeyEventArgs e)
        {
                e.Handled = !(e.Key >= Key.D0 && e.Key <= Key.D9);
        }

        private void textBoxCostWithoutVat_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxCostWithoutVat.Text == "")
            {
                e.Handled = !((e.Key >= Key.D0 && e.Key <= Key.D9));
            }
            else
            {
                e.Handled = !((e.Key >= Key.D0 && e.Key <= Key.D9) | (e.Key == Key.Decimal && !(textBoxCostWithoutVat.Text.Contains('.'))));
            }
        }

        private void textBoxVat_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxVat.Text == "")
            {
                e.Handled = !((e.Key >= Key.D0 && e.Key <= Key.D9));
            }
            else
            {
                e.Handled = !((e.Key >= Key.D0 && e.Key <= Key.D9) | (e.Key == Key.Decimal && !(textBoxVat.Text.Contains('.'))));
            }
        }

        private void textBoxRetailCost_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxRetailCost.Text == "")
            {
                e.Handled = !((e.Key >= Key.D0 && e.Key <= Key.D9));
            }
            else
            {
                e.Handled = !((e.Key >= Key.D0 && e.Key <= Key.D9) | (e.Key == Key.Decimal && !(textBoxRetailCost.Text.Contains('.'))));
            }
        }
    }
}
