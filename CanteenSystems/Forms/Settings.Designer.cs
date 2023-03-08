namespace CanteenSystems
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_language = new System.Windows.Forms.ComboBox();
            this.listBox_users = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_readfile = new System.Windows.Forms.Button();
            this.button_transferusers = new System.Windows.Forms.Button();
            this.textBox_selectfile = new System.Windows.Forms.TextBox();
            this.openFileDialog_user = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // comboBox_language
            // 
            resources.ApplyResources(this.comboBox_language, "comboBox_language");
            this.comboBox_language.FormattingEnabled = true;
            this.comboBox_language.Items.AddRange(new object[] {
            resources.GetString("comboBox_language.Items"),
            resources.GetString("comboBox_language.Items1")});
            this.comboBox_language.Name = "comboBox_language";
            // 
            // listBox_users
            // 
            resources.ApplyResources(this.listBox_users, "listBox_users");
            this.listBox_users.FormattingEnabled = true;
            this.listBox_users.Name = "listBox_users";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // button_readfile
            // 
            resources.ApplyResources(this.button_readfile, "button_readfile");
            this.button_readfile.Name = "button_readfile";
            this.button_readfile.UseVisualStyleBackColor = true;
            this.button_readfile.Click += new System.EventHandler(this.button_readfile_Click);
            // 
            // button_transferusers
            // 
            resources.ApplyResources(this.button_transferusers, "button_transferusers");
            this.button_transferusers.Name = "button_transferusers";
            this.button_transferusers.UseVisualStyleBackColor = true;
            this.button_transferusers.Click += new System.EventHandler(this.button_transferusers_Click);
            // 
            // textBox_selectfile
            // 
            resources.ApplyResources(this.textBox_selectfile, "textBox_selectfile");
            this.textBox_selectfile.Name = "textBox_selectfile";
            // 
            // openFileDialog_user
            // 
            resources.ApplyResources(this.openFileDialog_user, "openFileDialog_user");
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_selectfile);
            this.Controls.Add(this.button_transferusers);
            this.Controls.Add(this.button_readfile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox_users);
            this.Controls.Add(this.comboBox_language);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox comboBox_language;
        private ListBox listBox_users;
        private Label label2;
        private Button button_readfile;
        private Button button_transferusers;
        private TextBox textBox_selectfile;
        private OpenFileDialog openFileDialog_user;
    }
}