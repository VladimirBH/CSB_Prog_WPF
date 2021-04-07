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
    /// Логика взаимодействия для forEmployee.xaml
    /// </summary>
    public partial class forEmployee : Window
    {
        private int idEmp;
        public forEmployee(int _idEmp)
        {
            InitializeComponent();
            idEmp = _idEmp;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ConnectionMSSQL conSql = new ConnectionMSSQL();
            using (conSql.conn)
            {
                conSql.conn.Open();
                string getPos = @"SELECT DISTINCT job_title FROM positions";

                SqlCommand cmdSql = conSql.cmdSql;
                cmdSql.CommandType = CommandType.Text;
                cmdSql.CommandText = getPos;
                SqlDataReader rdr = cmdSql.ExecuteReader();
                if (rdr.HasRows) 
                {
                    while (rdr.Read())
                    {
                        comboBoxPos.Items.Add(rdr[0]);
                    }
                    rdr.Close();
                    cmdSql.Dispose();
                }
            }

            if (idEmp == 0)
            {
                btnSubmit.Content = "Добавить";
                comboBoxPos.SelectedIndex = -1;
            }
            else 
            {
                btnSubmit.Content = "Обновить";
                labelTitle.Content = "Обновление записи";
                string sql = @"SELECT emp.*, pos.job_title, pos.class FROM " +
                    "positions pos inner join " +
                    "employees emp " +
                    "on pos.id=emp.id_position " +
                    "where emp.id=" + idEmp + "";
                conSql = new ConnectionMSSQL();
                DataTable dt = conSql.getInDataTable(sql);
                if (dt != null)
                {
                    comboBoxPos.SelectedIndex = comboBoxPos.Items.IndexOf(dt.Rows[0]["job_title"]);
                    getClasses();
                    comboBoxClass.SelectedIndex = comboBoxClass.Items.IndexOf(dt.Rows[0]["class"]);
                    textBoxSurname.Text = (string)dt.Rows[0]["surname"];
                    textBoxName.Text = (string)dt.Rows[0]["name"];
                    textBoxDadNm.Text = (string)dt.Rows[0]["dad_nm"];
                    datePickerBirth.SelectedDate = (DateTime)dt.Rows[0]["date_birth"];
                    textBoxLogin.Text = (string)dt.Rows[0]["login"];
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

            if (textBoxSurname != null || textBoxName != null || textBoxDadNm != null || textBoxTelNum != null || textBoxAddress != null ||
                textBoxLogin != null || textBoxPass != null || datePickerBirth != null)
            {
                if (idEmp == 0)
                {
                    //Хэширование пароля
                    string passHash = BCrypt.Net.BCrypt.HashPassword(textBoxPass.Password, 14);
                    cmdSql.CommandText = "add_employees";
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
                    //Логин
                    cmdSql.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar));
                    cmdSql.Parameters["@login"].Value = textBoxLogin.Text;
                    //Пароль
                    cmdSql.Parameters.Add(new SqlParameter("@pass", SqlDbType.VarChar));
                    cmdSql.Parameters["@pass"].Value = passHash;
                    //Наименование должности
                    cmdSql.Parameters.Add(new SqlParameter("@job_tit", SqlDbType.VarChar));
                    cmdSql.Parameters["@job_tit"].Value = comboBoxPos.SelectedValue.ToString();
                    //Номер телефона
                    cmdSql.Parameters.Add(new SqlParameter("@tel", SqlDbType.VarChar));
                    cmdSql.Parameters["@tel"].Value = textBoxTelNum.Text;
                    //Разряд (если есть)
                    cmdSql.Parameters.Add(new SqlParameter("@job_class", SqlDbType.Int));
                    if (comboBoxClass.SelectedIndex == -1)
                    {
                        cmdSql.Parameters["@job_class"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmdSql.Parameters["@job_class"].Value = Convert.ToInt32(comboBoxClass.SelectedValue);
                    }
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
                            textBoxLogin.Text = "";
                            textBoxName.Text = "";
                            textBoxTelNum.Text = "";
                            datePickerBirth = null;
                            comboBoxPos.SelectedIndex = -1;
                            comboBoxClass.SelectedIndex = -1;
                        }
                        else
                        {
                            MessageBox.Show("Нет записей", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    cmdSql.CommandText = "upd_employees";
                    //ID сотрудника
                    cmdSql.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar));
                    cmdSql.Parameters["@id"].Value = idEmp;
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
                    //Логин
                    cmdSql.Parameters.Add(new SqlParameter("@login", SqlDbType.VarChar));
                    cmdSql.Parameters["@login"].Value = textBoxLogin.Text;
                    //Наименование должности
                    cmdSql.Parameters.Add(new SqlParameter("@job_tit", SqlDbType.VarChar));
                    cmdSql.Parameters["@job_tit"].Value = comboBoxPos.SelectedValue.ToString();
                    //Номер телефона
                    cmdSql.Parameters.Add(new SqlParameter("@tel", SqlDbType.Char));
                    cmdSql.Parameters["@tel"].Value = textBoxTelNum.Text;
                    //Разряд (если есть)
                    cmdSql.Parameters.Add(new SqlParameter("@job_class", SqlDbType.Int));
                    if (comboBoxClass.SelectedIndex == -1)
                    {
                        cmdSql.Parameters["@job_class"].Value = DBNull.Value;
                    }
                    else
                    {
                        cmdSql.Parameters["@job_class"].Value = Convert.ToInt32(comboBoxClass.SelectedValue.ToString());
                    }
                    using (conSql.conn)
                    {
                        MessageBox.Show(comboBoxPos.SelectedValue.ToString() +"\t"+ comboBoxClass.SelectedValue.ToString(), "Успех",
                            MessageBoxButton.OK, MessageBoxImage.Information);
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

        private void getClasses() 
        {
            string getClass = @"SELECT class FROM positions WHERE job_title='" + comboBoxPos.Text + "'";
            ConnectionMSSQL conSql = new ConnectionMSSQL();

            using (conSql.conn)
            {
                conSql.conn.Open();
                SqlCommand cmdSql = conSql.cmdSql;
                cmdSql.CommandType = CommandType.Text;
                cmdSql.CommandText = getClass;
                SqlDataReader rdr = cmdSql.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        comboBoxClass.Items.Add(rdr[0]);
                    }
                }
                rdr.Close();
                cmdSql.Dispose();
            }
        }

        private void comboBoxPos_DropDownClosed(object sender, EventArgs e)
        {
            comboBoxClass.Items.Clear();
            getClasses();
            comboBoxClass.SelectedIndex = -1;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //Ввод номера телефона
        private void textBoxTelNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBoxTelNum.Text == "")
            {
                e.Handled = !(e.Key == Key.Add);
            }
            else
            {
                e.Handled = !(e.Key >= Key.D0 && e.Key <= Key.D9);
            }
        }
    }
}
