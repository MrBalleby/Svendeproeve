namespace CanteenSystems
{
    partial class ItemDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemDetail));
            this.button_Save = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox_Price = new System.Windows.Forms.TextBox();
            this.textBox_Amount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox_Description = new System.Windows.Forms.RichTextBox();
            this.comboBox_ItemGroup = new System.Windows.Forms.ComboBox();
            this.comboBox_Vissible = new System.Windows.Forms.ComboBox();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_delete_item = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_Save
            // 
            resources.ApplyResources(this.button_Save, "button_Save");
            this.button_Save.Name = "button_Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_ClickAsync);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
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
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // textBox_Title
            // 
            resources.ApplyResources(this.textBox_Title, "textBox_Title");
            this.textBox_Title.Name = "textBox_Title";
            // 
            // textBox_Price
            // 
            resources.ApplyResources(this.textBox_Price, "textBox_Price");
            this.textBox_Price.Name = "textBox_Price";
            // 
            // textBox_Amount
            // 
            resources.ApplyResources(this.textBox_Amount, "textBox_Amount");
            this.textBox_Amount.Name = "textBox_Amount";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // richTextBox_Description
            // 
            resources.ApplyResources(this.richTextBox_Description, "richTextBox_Description");
            this.richTextBox_Description.Name = "richTextBox_Description";
            // 
            // comboBox_ItemGroup
            // 
            resources.ApplyResources(this.comboBox_ItemGroup, "comboBox_ItemGroup");
            this.comboBox_ItemGroup.FormattingEnabled = true;
            this.comboBox_ItemGroup.Name = "comboBox_ItemGroup";
            // 
            // comboBox_Vissible
            // 
            resources.ApplyResources(this.comboBox_Vissible, "comboBox_Vissible");
            this.comboBox_Vissible.FormattingEnabled = true;
            this.comboBox_Vissible.Items.AddRange(new object[] {
            resources.GetString("comboBox_Vissible.Items"),
            resources.GetString("comboBox_Vissible.Items1")});
            this.comboBox_Vissible.Name = "comboBox_Vissible";
            // 
            // button_Cancel
            // 
            resources.ApplyResources(this.button_Cancel, "button_Cancel");
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // button_delete_item
            // 
            resources.ApplyResources(this.button_delete_item, "button_delete_item");
            this.button_delete_item.Name = "button_delete_item";
            this.button_delete_item.UseVisualStyleBackColor = true;
            this.button_delete_item.Click += new System.EventHandler(this.button_delete_item_Click);
            // 
            // ItemDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_delete_item);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.comboBox_Vissible);
            this.Controls.Add(this.comboBox_ItemGroup);
            this.Controls.Add(this.richTextBox_Description);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Amount);
            this.Controls.Add(this.textBox_Price);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Save);
            this.Name = "ItemDetail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button_Save;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox_Title;
        private TextBox textBox_Price;
        private TextBox textBox_Amount;
        private Label label5;
        private Label label6;
        private RichTextBox richTextBox_Description;
        private ComboBox comboBox_ItemGroup;
        private ComboBox comboBox_Vissible;
        private Button button_Cancel;
        private Button button_delete_item;
    }
}