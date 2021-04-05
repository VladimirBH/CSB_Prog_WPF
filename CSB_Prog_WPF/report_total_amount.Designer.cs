
namespace CSB_program
{
    partial class report_total_amount
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report_total_amount));
            this.show_sum_salesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSB_INCDataSet = new CSB_Prog_WPF.CSB_INCDataSet();
            this.dateTimePicker_from = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_to = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.show_sum_salesTableAdapter = new CSB_Prog_WPF.CSB_INCDataSetTableAdapters.show_sum_salesTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.show_sum_salesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // show_sum_salesBindingSource
            // 
            this.show_sum_salesBindingSource.DataMember = "show_sum_sales";
            this.show_sum_salesBindingSource.DataSource = this.cSB_INCDataSet;
            // 
            // cSB_INCDataSet
            // 
            this.cSB_INCDataSet.DataSetName = "CSB_INCDataSet";
            this.cSB_INCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dateTimePicker_from
            // 
            this.dateTimePicker_from.Location = new System.Drawing.Point(77, 33);
            this.dateTimePicker_from.Name = "dateTimePicker_from";
            this.dateTimePicker_from.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker_from.TabIndex = 1;
            // 
            // dateTimePicker_to
            // 
            this.dateTimePicker_to.Location = new System.Drawing.Point(336, 33);
            this.dateTimePicker_to.Name = "dateTimePicker_to";
            this.dateTimePicker_to.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker_to.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "От:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(295, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "До:";
            // 
            // button_submit
            // 
            this.button_submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.button_submit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.button_submit.FlatAppearance.BorderSize = 2;
            this.button_submit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.button_submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.button_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_submit.Location = new System.Drawing.Point(706, 29);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(139, 39);
            this.button_submit.TabIndex = 26;
            this.button_submit.Text = "Выполнить";
            this.button_submit.UseVisualStyleBackColor = false;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Location = new System.Drawing.Point(851, 29);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(139, 39);
            this.button_exit.TabIndex = 25;
            this.button_exit.Text = "Закрыть";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // reportViewer2
            // 
            reportDataSource2.Name = "total_amount";
            reportDataSource2.Value = this.show_sum_salesBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "CSB_Prog_WPF.amount_sales.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(13, 74);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(997, 511);
            this.reportViewer2.TabIndex = 27;
            // 
            // show_sum_salesTableAdapter
            // 
            this.show_sum_salesTableAdapter.ClearBeforeFill = true;
            // 
            // report_total_amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 596);
            this.Controls.Add(this.reportViewer2);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_to);
            this.Controls.Add(this.dateTimePicker_from);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(1039, 635);
            this.MinimumSize = new System.Drawing.Size(1039, 635);
            this.Name = "report_total_amount";
            this.Padding = new System.Windows.Forms.Padding(33, 83, 33, 28);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отчет по продажам за период";
            this.Load += new System.EventHandler(this.report_total_amount_Load);
            this.Resize += new System.EventHandler(this.report_total_amount_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.show_sum_salesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource show_sum_salesBindingSource;
        private System.Windows.Forms.DateTimePicker dateTimePicker_from;
        private System.Windows.Forms.DateTimePicker dateTimePicker_to;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_submit;
        private System.Windows.Forms.Button button_exit;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private CSB_Prog_WPF.CSB_INCDataSet cSB_INCDataSet;
        private CSB_Prog_WPF.CSB_INCDataSetTableAdapters.show_sum_salesTableAdapter show_sum_salesTableAdapter;
    }
}