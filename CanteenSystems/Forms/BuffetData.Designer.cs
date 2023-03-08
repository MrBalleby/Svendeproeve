namespace CanteenSystems
{
    partial class BuffetData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuffetData));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_save_buffetdata = new System.Windows.Forms.Button();
            this.comboBox_filetype = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_datespan = new System.Windows.Forms.ComboBox();
            this.chart_data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_data)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.button_save_buffetdata);
            this.groupBox1.Controls.Add(this.comboBox_filetype);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_datespan);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // button_save_buffetdata
            // 
            resources.ApplyResources(this.button_save_buffetdata, "button_save_buffetdata");
            this.button_save_buffetdata.Name = "button_save_buffetdata";
            this.button_save_buffetdata.UseVisualStyleBackColor = true;
            this.button_save_buffetdata.Click += new System.EventHandler(this.button_save_buffetdata_Click);
            // 
            // comboBox_filetype
            // 
            resources.ApplyResources(this.comboBox_filetype, "comboBox_filetype");
            this.comboBox_filetype.FormattingEnabled = true;
            this.comboBox_filetype.Items.AddRange(new object[] {
            resources.GetString("comboBox_filetype.Items"),
            resources.GetString("comboBox_filetype.Items1")});
            this.comboBox_filetype.Name = "comboBox_filetype";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // comboBox_datespan
            // 
            resources.ApplyResources(this.comboBox_datespan, "comboBox_datespan");
            this.comboBox_datespan.FormattingEnabled = true;
            this.comboBox_datespan.Items.AddRange(new object[] {
            resources.GetString("comboBox_datespan.Items"),
            resources.GetString("comboBox_datespan.Items1"),
            resources.GetString("comboBox_datespan.Items2"),
            resources.GetString("comboBox_datespan.Items3"),
            resources.GetString("comboBox_datespan.Items4"),
            resources.GetString("comboBox_datespan.Items5"),
            resources.GetString("comboBox_datespan.Items6"),
            resources.GetString("comboBox_datespan.Items7"),
            resources.GetString("comboBox_datespan.Items8"),
            resources.GetString("comboBox_datespan.Items9")});
            this.comboBox_datespan.Name = "comboBox_datespan";
            this.comboBox_datespan.SelectedIndexChanged += new System.EventHandler(this.comboBox_datespan_SelectedIndexChanged);
            // 
            // chart_data
            // 
            resources.ApplyResources(this.chart_data, "chart_data");
            this.chart_data.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.Name = "ChartArea1";
            this.chart_data.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_data.Legends.Add(legend1);
            this.chart_data.Name = "chart_data";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_data.Series.Add(series1);
            // 
            // BuffetData
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart_data);
            this.Controls.Add(this.groupBox1);
            this.Name = "BuffetData";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private Button button_save_buffetdata;
        private ComboBox comboBox_filetype;
        private Label label2;
        private Label label3;
        private ComboBox comboBox_datespan;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_data;
    }
}