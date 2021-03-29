using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSB_program
{
    public partial class productReceiptReport : Form
    {
        public productReceiptReport()
        {
            InitializeComponent();
        }

        private void productReceiptReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
