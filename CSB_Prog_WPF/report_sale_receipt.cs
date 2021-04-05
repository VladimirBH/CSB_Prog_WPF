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
    public partial class report_sale_receipt : Form
    {
        int id;
        public report_sale_receipt(int id_sale)
        {
            InitializeComponent();
            id = id_sale;
        }

        private void report_sale_receipt_Load(object sender, EventArgs e)
        {
            this.button_exit.Location = new Point(this.Width - this.button_exit.Width - 40, 35);
            this.reportViewer1.RefreshReport();
            this.reportViewer2.RefreshReport();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void report_sale_receipt_Resize(object sender, EventArgs e)
        {
            this.button_exit.Location = new Point(this.Width - this.button_exit.Width - 40, 35);
        }
    }
}
