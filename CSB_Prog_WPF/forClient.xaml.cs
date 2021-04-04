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
    /// Логика взаимодействия для forClient.xaml
    /// </summary>
    public partial class forClient : Window
    {
        private int idCli;
        public forClient(int _idCli)
        {
            InitializeComponent();
            idCli = _idCli;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectionMSSQL conSql = new ConnectionMSSQL();

            if (idCli == 0)
            {
                btnSubmit.Content = "Добавить";
            }
            else
            {
                btnSubmit.Content = "Обновить";
                labelTitle.Content = "Обновление записи";
                string sql = @"SELECT * FROM clients " +
                    "where id=" + idCli + "";
                conSql = new ConnectionMSSQL();
                DataTable dt = conSql.getInDataTable(sql);
                if (dt != null)
                {
                    textBoxSurname.Text = (string)dt.Rows[0]["surname"];
                    textBoxName.Text = (string)dt.Rows[0]["name"];
                    textBoxDadNm.Text = (string)dt.Rows[0]["dad_nm"];
                    datePickerBirth.SelectedDate = (DateTime)dt.Rows[0]["date_birth"];
                    textBoxAddress.Text = (string)dt.Rows[0]["adress"];
                    textBoxTelNum.Text = (string)dt.Rows[0]["tel_num"];
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

            if (textBoxSurname != null || textBoxName != null || textBoxDadNm != null || textBoxTelNum != null 
                || textBoxAddress != null || datePickerBirth != null)
            {
                if (idCli == 0)
                {
                    cmdSql.CommandText = "add_clients";
                    //Фамилия
                    cmdSql.Parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar));
                    cmdSql.Parameters["@surname"].Value = textBoxSurname.Text;
                    //Имя
                    cmdSql.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar));
                    cmdSql.Parameters["@name"].Value = textBoxName.Text;
                    //Отчество
                    cmdSql.Parameters.Add(new SqlParameter("@otch", SqlDbType.VarChar));
                    cmdSql.Parameters["@otch"].Value = textBoxDadNm.Text;
                    //Дата рождения
                    cmdSql.Parameters.Add(new SqlParameter("@date_birth", SqlDbType.Date));
                    cmdSql.Parameters["@date_birth"].Value = (DateTime)datePickerBirth.SelectedDate;
                    //Адрес проживания
                    cmdSql.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar));
                    cmdSql.Parameters["@address"].Value = textBoxAddress.Text;
                    //Номер телефона
                    cmdSql.Parameters.Add(new SqlParameter("@tel", SqlDbType.Char));
                    cmdSql.Parameters["@tel"].Value = textBoxTelNum.Text;
                    using (conSql.conn)
                    {
                        conSql.conn.Open();
                        if (cmdSql.ExecuteNonQuery() != 0)
                        {
                            MessageBox.Show("Данные успешно добавлены!!!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                            textBoxSurname.Text = "";
                            textBoxName.Text = "";
                            textBoxDadNm.Text = "";
                            textBoxAddress.Text = "";
                            textBoxName.Text = "";
                            textBoxTelNum.Text = "";
                            datePickerBirth = null;
                        }
                        else
                        {
                            MessageBox.Show("Нет записей", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    cmdSql.CommandText = "upd_clients";
                    //ID сотрудника
                    cmdSql.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar));
                    cmdSql.Parameters["@id"].Value = idCli;
                    //Фамилия
                    cmdSql.Parameters.Add(new SqlParameter("@surname", SqlDbType.VarChar));
                    cmdSql.Parameters["@surname"].Value = textBoxSurname.Text;
                    //Имя
                    cmdSql.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar));
                    cmdSql.Parameters["@name"].Value = textBoxName.Text;
                    //Отчество
                    cmdSql.Parameters.Add(new SqlParameter("@otch", SqlDbType.VarChar));
                    cmdSql.Parameters["@otch"].Value = textBoxDadNm.Text;
                    //Дата рождения
                    cmdSql.Parameters.Add(new SqlParameter("@date_birth", SqlDbType.Date));
                    cmdSql.Parameters["@date_birth"].Value = (DateTime)datePickerBirth.SelectedDate;
                    //Адрес проживания
                    cmdSql.Parameters.Add(new SqlParameter("@address", SqlDbType.VarChar));
                    cmdSql.Parameters["@address"].Value = textBoxAddress.Text;
                    //Номер телефона
                    cmdSql.Parameters.Add(new SqlParameter("@tel", SqlDbType.Char));
                    cmdSql.Parameters["@tel"].Value = textBoxTelNum.Text;
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
