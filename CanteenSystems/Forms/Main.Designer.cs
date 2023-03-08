namespace CanteenSystems
{
    partial class Form_main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.panel_mainmenu = new System.Windows.Forms.Panel();
            this.button_menu4 = new System.Windows.Forms.Button();
            this.button_menu3 = new System.Windows.Forms.Button();
            this.button_menu2 = new System.Windows.Forms.Button();
            this.button_menu1 = new System.Windows.Forms.Button();
            this.pictureBo_logo = new System.Windows.Forms.PictureBox();
            this.panel_content = new System.Windows.Forms.Panel();
            this.panel_mainmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBo_logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_mainmenu
            // 
            resources.ApplyResources(this.panel_mainmenu, "panel_mainmenu");
            this.panel_mainmenu.Controls.Add(this.button_menu4);
            this.panel_mainmenu.Controls.Add(this.button_menu3);
            this.panel_mainmenu.Controls.Add(this.button_menu2);
            this.panel_mainmenu.Controls.Add(this.button_menu1);
            this.panel_mainmenu.Controls.Add(this.pictureBo_logo);
            this.panel_mainmenu.Name = "panel_mainmenu";
            // 
            // button_menu4
            // 
            resources.ApplyResources(this.button_menu4, "button_menu4");
            this.button_menu4.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button_menu4.Name = "button_menu4";
            this.button_menu4.UseVisualStyleBackColor = false;
            this.button_menu4.Click += new System.EventHandler(this.Button_MenuOnClick);
            // 
            // button_menu3
            // 
            resources.ApplyResources(this.button_menu3, "button_menu3");
            this.button_menu3.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button_menu3.Name = "button_menu3";
            this.button_menu3.UseVisualStyleBackColor = false;
            this.button_menu3.Click += new System.EventHandler(this.Button_MenuOnClick);
            // 
            // button_menu2
            // 
            resources.ApplyResources(this.button_menu2, "button_menu2");
            this.button_menu2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button_menu2.Name = "button_menu2";
            this.button_menu2.UseVisualStyleBackColor = false;
            this.button_menu2.Click += new System.EventHandler(this.Button_MenuOnClick);
            // 
            // button_menu1
            // 
            resources.ApplyResources(this.button_menu1, "button_menu1");
            this.button_menu1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button_menu1.Name = "button_menu1";
            this.button_menu1.UseVisualStyleBackColor = false;
            this.button_menu1.Click += new System.EventHandler(this.Button_MenuOnClick);
            // 
            // pictureBo_logo
            // 
            resources.ApplyResources(this.pictureBo_logo, "pictureBo_logo");
            this.pictureBo_logo.Name = "pictureBo_logo";
            this.pictureBo_logo.TabStop = false;
            // 
            // panel_content
            // 
            resources.ApplyResources(this.panel_content, "panel_content");
            this.panel_content.Name = "panel_content";
            // 
            // Form_main
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_content);
            this.Controls.Add(this.panel_mainmenu);
            this.Name = "Form_main";
            this.panel_mainmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBo_logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel_mainmenu;
        private Button button_menu4;
        private Button button_menu3;
        private Button button_menu2;
        private Button button_menu1;
        private Panel panel_content;
        private PictureBox pictureBo_logo;
    }
}