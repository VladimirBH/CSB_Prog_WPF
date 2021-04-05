
namespace CSB_program
{
    partial class report
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(report));
            this.show_tovarBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cSB_INCDataSet = new CSB_Prog_WPF.CSB_INCDataSet();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.button_exit = new System.Windows.Forms.Button();
            this.textBox_filter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_submit = new System.Windows.Forms.Button();
            this.show_tovarTableAdapter = new CSB_Prog_WPF.CSB_INCDataSetTableAdapters.show_tovarTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.show_tovarBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // show_tovarBindingSource
            // 
            this.show_tovarBindingSource.DataMember = "show_tovar";
            this.show_tovarBindingSource.DataSource = this.cSB_INCDataSet;
            // 
            // cSB_INCDataSet
            // 
            this.cSB_INCDataSet.DataSetName = "CSB_INCDataSet";
            this.cSB_INCDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer2.DocumentMapWidth = 1;
            this.reportViewer2.Font = new System.Drawing.Font("Verdana", 12F);
            reportDataSource1.Name = "price_list";
            reportDataSource1.Value = this.show_tovarBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "CSB_Prog_WPF.goodsReportView.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(33, 83);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1065, 616);
            this.reportViewer2.TabIndex = 0;
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.button_exit.FlatAppearance.BorderSize = 2;
            this.button_exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.button_exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_exit.Location = new System.Drawing.Point(959, 28);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(139, 39);
            this.button_exit.TabIndex = 21;
            this.button_exit.Text = "Закрыть";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // textBox_filter
            // 
            this.textBox_filter.Location = new System.Drawing.Point(127, 46);
            this.textBox_filter.Name = "textBox_filter";
            this.textBox_filter.Size = new System.Drawing.Size(409, 27);
            this.textBox_filter.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 23;
            this.label1.Text = "Фильтр:";
            // 
            // button_submit
            // 
            this.button_submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(144)))), ((int)(((byte)(0)))));
            this.button_submit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.button_submit.FlatAppearance.BorderSize = 2;
            this.button_submit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(104)))), ((int)(((byte)(0)))));
            this.button_submit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(124)))), ((int)(((byte)(0)))));
            this.button_submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_submit.Location = new System.Drawing.Point(814, 28);
            this.button_submit.Name = "button_submit";
            this.button_submit.Size = new System.Drawing.Size(139, 39);
            this.button_submit.TabIndex = 24;
            this.button_submit.Text = "Выполнить";
            this.button_submit.UseVisualStyleBackColor = false;
            this.button_submit.Click += new System.EventHandler(this.button_submit_Click);
            // 
            // show_tovarTableAdapter
            // 
            this.show_tovarTableAdapter.ClearBeforeFill = true;
            // 
            // report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 727);
            this.Controls.Add(this.button_submit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_filter);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.reportViewer2);
            this.Font = new System.Drawing.Font("Verdana", 12F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(0)))), ((int)(((byte)(87)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximumSize = new System.Drawing.Size(1147, 766);
            this.MinimumSize = new System.Drawing.Size(1147, 766);
            this.Name = "report";
            this.Padding = new System.Windows.Forms.Padding(33, 83, 33, 28);
            this.Text = "Поиск по навзванию товара";
            this.Load += new System.EventHandler(this.report_Load);
            this.Resize += new System.EventHandler(this.report_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.show_tovarBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cSB_INCDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource show_tovarBindingSource;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.TextBox textBox_filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_submit;
        private CSB_Prog_WPF.CSB_INCDataSet cSB_INCDataSet;
        private CSB_Prog_WPF.CSB_INCDataSetTableAdapters.show_tovarTableAdapter show_tovarTableAdapter;
    }
}