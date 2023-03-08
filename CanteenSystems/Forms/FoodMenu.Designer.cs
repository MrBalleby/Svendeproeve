namespace CanteenSystems
{
    partial class FoodMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FoodMenu));
            this.monthCalendar_menu = new System.Windows.Forms.MonthCalendar();
            this.button_save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox_menu1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox_menu2 = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox_menu3 = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox_menu4 = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBox_menu5 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // monthCalendar_menu
            // 
            resources.ApplyResources(this.monthCalendar_menu, "monthCalendar_menu");
            this.monthCalendar_menu.MaxSelectionCount = 1;
            this.monthCalendar_menu.Name = "monthCalendar_menu";
            this.monthCalendar_menu.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_menu_DateSelected);
            // 
            // button_save
            // 
            resources.ApplyResources(this.button_save, "button_save");
            this.button_save.Name = "button_save";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // richTextBox_menu1
            // 
            resources.ApplyResources(this.richTextBox_menu1, "richTextBox_menu1");
            this.richTextBox_menu1.Name = "richTextBox_menu1";
            // 
            // richTextBox_menu2
            // 
            resources.ApplyResources(this.richTextBox_menu2, "richTextBox_menu2");
            this.richTextBox_menu2.Name = "richTextBox_menu2";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // richTextBox_menu3
            // 
            resources.ApplyResources(this.richTextBox_menu3, "richTextBox_menu3");
            this.richTextBox_menu3.Name = "richTextBox_menu3";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // richTextBox_menu4
            // 
            resources.ApplyResources(this.richTextBox_menu4, "richTextBox_menu4");
            this.richTextBox_menu4.Name = "richTextBox_menu4";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // richTextBox_menu5
            // 
            resources.ApplyResources(this.richTextBox_menu5, "richTextBox_menu5");
            this.richTextBox_menu5.Name = "richTextBox_menu5";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // FoodMenu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox_menu5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.richTextBox_menu4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBox_menu3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_menu2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.richTextBox_menu1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.monthCalendar_menu);
            this.Name = "FoodMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MonthCalendar monthCalendar_menu;
        private Button button_save;
        private Label label1;
        private RichTextBox richTextBox_menu1;
        private RichTextBox richTextBox_menu2;
        private Label label2;
        private RichTextBox richTextBox_menu3;
        private Label label3;
        private RichTextBox richTextBox_menu4;
        private Label label4;
        private RichTextBox richTextBox_menu5;
        private Label label5;
    }
}