
namespace CSB_program
{
    partial class report_invoice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report_invoice));
            this.show_purchase_invoiceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSB_INCDataSet = new CSB_Prog_WPF.CSB_INCDataSet();
            this.button_exit = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.show_purchase_invoiceTableAdapter = new CSB_Prog_WPF.CSB_INCDataSetTableAdapters.show_purchase_invoiceTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.show_purchase_invoiceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // show_purchase_invoiceBindingSource
            // 
            this.show_purchase_invoiceBindingSource.DataMember = "show_purchase_invoice";
            this.show_purchase_invoiceBindingSource.DataSource = this.cSB_INCDataSet;
            // 
            // cSB_INCDataSet
            // 
            this.cSB_INCDataSet.DataSetName = "CSB_INCDataSet";
            this.cSB_INCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Location = new System.Drawing.Point(976, 38);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(139, 39);
            this.button_exit.TabIndex = 23;
            this.button_exit.Text = "Закрыть";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "purchase_invoice";
            reportDataSource1.Value = this.show_purchase_invoiceBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CSB_Prog_WPF.purchaseInvoiceReportView.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(33, 83);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1082, 601);
            this.reportViewer1.TabIndex = 0;
            // 
            // show_purchase_invoiceTableAdapter
            // 
            this.show_purchase_invoiceTableAdapter.ClearBeforeFill = true;
            // 
            // report_invoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 712);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(1164, 751);
            this.MinimumSize = new System.Drawing.Size(1164, 751);
            this.Name = "report_invoice";
            this.Padding = new System.Windows.Forms.Padding(33, 83, 33, 28);
            this.Text = "Формирование приходной накладной";
            this.Load += new System.EventHandler(this.report_invoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.show_purchase_invoiceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.BindingSource show_purchase_invoiceBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private CSB_Prog_WPF.CSB_INCDataSet cSB_INCDataSet;
        private CSB_Prog_WPF.CSB_INCDataSetTableAdapters.show_purchase_invoiceTableAdapter show_purchase_invoiceTableAdapter;
    }
}