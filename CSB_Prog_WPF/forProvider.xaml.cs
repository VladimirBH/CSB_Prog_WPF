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
    /// Логика взаимодействия для forProvider.xaml
    /// </summary>
    public partial class forProvider : Window
    {
        private int idProvider;
        public forProvider(int _idProvider)
        {
            InitializeComponent();
            idProvider = _idProvider;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectionMSSQL conSql = new ConnectionMSSQL();

            if (idProvider == 0)
            {
                btnSubmit.Content = "Добавить";
            }
            else
            {
                btnSubmit.Content = "Обновить";
                labelTitle.Content = "Обновление записи";
                string sql = @"SELECT * FROM provider " +
                    "where id=" + idProvider + "";
                conSql = new ConnectionMSSQL();
                DataTable dt = conSql.getInDataTable(sql);
                if (dt != null)
                {
                    textBoxNameOrg.Text = (string)dt.Rows[0]["name_org"];
                    textBoxAddress.Text = (string)dt.Rows[0]["legal_address"];
                    textBoxTelNum.Text = (string)dt.Rows[0]["tel_num"];;
                }
                else
                {
                    MessageBox.Show("Не удалось пролучить данные", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                    this.Close();
                }

            }
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            ConnectionMSSQL conSql = new ConnectionMSSQL();
            SqlCommand cmdSql = conSql.cmdSql;
            cmdSql.CommandType = CommandType.StoredProcedure;

            if (textBoxNameOrg != null || textBoxAddress != null || textBoxTelNum != null)
            {
                if (idProvider == 0)
                {
                    cmdSql.CommandText = "add_provider";
                    //Наименование организации
                    cmdSql.Parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar));
                    cmdSql.Parameters["@surname"].Value = textBoxNameOrg.Text;
                    //Юр адрес
                    cmdSql.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar));
                    cmdSql.Parameters["@name"].Value = textBoxAddress.Text;
                    //Номер телефона
                    cmdSql.Parameters.Add(new SqlParameter("@otch", SqlDbType.VarChar));
                    cmdSql.Parameters["@otch"].Value = textBoxTelNum.Text;
                    using (conSql.conn)
                    {
                        conSql.conn.Open();
                        if (cmdSql.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("Данные успешно добавлены!!!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            textBoxNameOrg.Text = "";
                            textBoxAddress.Text = "";
                            textBoxTelNum.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Нет записей", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    cmdSql.CommandText = "upd_provider";
                    //ID поставщика
                    cmdSql.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar));
                    cmdSql.Parameters["@id"].Value = idProvider;
                    //Наименование организации
                    cmdSql.Parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar));
                    cmdSql.Parameters["@surname"].Value = textBoxNameOrg.Text;
                    //Юр адрес
                    cmdSql.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar));
                    cmdSql.Parameters["@name"].Value = textBoxAddress.Text;
                    //Номер телефона
                    cmdSql.Parameters.Add(new SqlParameter("@otch", SqlDbType.VarChar));
                    cmdSql.Parameters["@otch"].Value = textBoxTelNum.Text;
                    using (conSql.conn)
                    {
                        conSql.conn.Open();
                        if (cmdSql.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("Данные успешно обновлены!!!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Нет записей", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните все записи", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
