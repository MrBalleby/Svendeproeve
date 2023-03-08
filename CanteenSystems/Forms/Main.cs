namespace CanteenSystems
{
    public partial class Form_main : Form
    {
        private Form activeForm;

        public Form_main()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            Reset();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {

        }

        private void Button_MenuOnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name)
            {
                case "button_menu1":
                    OpenChildForm(new WebshopItems(), sender);
                    break;
                case "button_menu2":
                    OpenChildForm(new FoodMenu(),sender);
                    break;
                case "button_menu3":
                    OpenChildForm(new BuffetData(), sender);
                    break;
                case "button_menu4":
                    OpenChildForm(new Settings(), sender);
                    break;
                default:
                    break;
            }
        }

        void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.MinimumSize = panel_content.Size;
            activeForm.MaximumSize = panel_content.Size;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.AutoScroll = true;
            activeForm.Dock = DockStyle.Fill;
            panel_content.Controls.Add(activeForm);
            panel_content.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }

        void Reset()
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
            }
        }

    }
}