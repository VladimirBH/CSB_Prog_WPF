
namespace CSB_program
{
    partial class report_sale_receipt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report_sale_receipt));

            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button_exit = new System.Windows.Forms.Button();
            this.show_sale_receiptBindingSource = new System.Windows.Forms.BindingSource(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.show_sale_receiptBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CSB_INCDataSet
            // 
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "sale_receipt";
            reportDataSource1.Value = this.show_sale_receiptBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CSB_program.sale_receipt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(33, 83);
            this.reportViewer1.Name = "reportViewer1";
           // this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1006, 512);
            this.reportViewer1.TabIndex = 0;
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Location = new System.Drawing.Point(900, 38);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(139, 39);
            this.button_exit.TabIndex = 22;
            this.button_exit.Text = "Закрыть";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // show_sale_receiptBindingSource
            // 
            // 
            // show_sale_receiptTableAdapter
            // 
            // 
            // report_sale_receipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 623);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(97)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "report_sale_receipt";
            this.Padding = new System.Windows.Forms.Padding(33, 83, 33, 28);
            this.Load += new System.EventHandler(this.report_sale_receipt_Load);
            this.Resize += new System.EventHandler(this.report_sale_receipt_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.show_sale_receiptBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.BindingSource show_sale_receiptBindingSource;
    }
}