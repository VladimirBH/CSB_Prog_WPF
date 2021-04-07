using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace CSB_program
{
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            //TODO: данная строка кода позволяет загрузить данные в таблицу "CSB_INCDataSet.show_tovar".При необходимости она может быть перемещена или удалена.
            this.show_tovar_funcTableAdapter.Fill(this.cSB_INCDataSet.show_tovar_func, textBox_filter.Text);
            this.reportViewer2.RefreshReport();
            this.button_exit.Location = new Point(this.Width - this.button_exit.Width - 40, 35);
            this.button_submit.Location = new Point(this.Width - this.button_exit.Width - this.button_submit.Width - 40 - 20, 35);
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void report_Resize(object sender, EventArgs e)
        {
            this.button_exit.Location = new Point(this.Width - this.button_exit.Width - 40, 35);
            this.button_submit.Location = new Point(this.Width - this.button_exit.Width - this.button_submit.Width - 40 - 20, 35);
        }

        private void button_submit_Click(object sender, EventArgs e)
        {
            this.show_tovar_funcTableAdapter.Fill(this.cSB_INCDataSet.show_tovar_func, textBox_filter.Text);
            this.reportViewer2.RefreshReport();
        }
    }
}
