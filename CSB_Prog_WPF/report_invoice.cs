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
    public partial class report_invoice : Form
    {
        int id_inv;
        public report_invoice(int id)
        {
            InitializeComponent();
            id_inv = id;
        }

        private void report_invoice_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "CSB_INCDataSet.show_sale_receipt". При необходимости она может быть перемещена или удалена.
            this.reportViewer1.RefreshReport();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
