namespace CanteenSystems
{
    partial class WebshopItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WebshopItems));
            this.listBox_items = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_change_itemgroups = new System.Windows.Forms.Button();
            this.button_additem = new System.Windows.Forms.Button();
            this.panel_itemcontent = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_items
            // 
            resources.ApplyResources(this.listBox_items, "listBox_items");
            this.listBox_items.FormattingEnabled = true;
            this.listBox_items.Name = "listBox_items";
            this.listBox_items.SelectedIndexChanged += new System.EventHandler(this.listBox_items_SelectedIndexChangedAsync);
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.button_change_itemgroups);
            this.panel1.Controls.Add(this.button_additem);
            this.panel1.Name = "panel1";
            // 
            // button_change_itemgroups
            // 
            resources.ApplyResources(this.button_change_itemgroups, "button_change_itemgroups");
            this.button_change_itemgroups.Name = "button_change_itemgroups";
            this.button_change_itemgroups.UseVisualStyleBackColor = true;
            this.button_change_itemgroups.Click += new System.EventHandler(this.button_change_itemgroups_Click);
            // 
            // button_additem
            // 
            resources.ApplyResources(this.button_additem, "button_additem");
            this.button_additem.Name = "button_additem";
            this.button_additem.UseVisualStyleBackColor = true;
            this.button_additem.Click += new System.EventHandler(this.button_additem_Click);
            // 
            // panel_itemcontent
            // 
            resources.ApplyResources(this.panel_itemcontent, "panel_itemcontent");
            this.panel_itemcontent.Name = "panel_itemcontent";
            // 
            // WebshopItems
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_itemcontent);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listBox_items);
            this.Name = "WebshopItems";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBox_items;
        private Panel panel1;
        private Button button_additem;
        private Panel panel_itemcontent;
        private Button button_change_itemgroups;
    }
}