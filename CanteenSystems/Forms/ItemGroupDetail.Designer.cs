namespace CanteenSystems
{
    partial class ItemGroupDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemGroupDetail));
            this.button_Save = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_delete_itemgroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            resources.ApplyResources(this.button_Save, "button_Save");
            this.button_Save.Name = "button_Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_ClickAsync);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox_Title
            // 
            resources.ApplyResources(this.textBox_Title, "textBox_Title");
            this.textBox_Title.Name = "textBox_Title";
            // 
            // button_Cancel
            // 
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_delete_itemgroup
            // 
            resources.ApplyResources(this.button_delete_itemgroup, "button_delete_itemgroup");
            this.button_delete_itemgroup.Name = "button_delete_itemgroup";
            this.button_delete_itemgroup.UseVisualStyleBackColor = true;
            this.button_delete_itemgroup.Click += new System.EventHandler(this.button_delete_itemgroup_Click);
            // 
            // ItemGroupDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_delete_itemgroup);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Save);
            this.Name = "ItemGroupDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_Save;
        private Label label2;
        private TextBox textBox_Title;
        private Button button_Cancel;
        private Button button_delete_itemgroup;
    }
}