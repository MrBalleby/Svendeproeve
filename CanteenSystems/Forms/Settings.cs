using CanteenSystems.Model;

using Microsoft.AspNet.Identity.EntityFramework;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenSystems
{
    public partial class Settings : Form
    {
        private List<User> users = new List<User>();
        public Settings()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button_readfile_Click(object sender, EventArgs e)
        {
            users.Clear();
            listBox_users.Items.Clear();
            try
            {
                if(openFileDialog_user.ShowDialog() == DialogResult.OK)
                {
                    textBox_selectfile.Text = openFileDialog_user.FileName;
                    openFileDialog_user.Dispose();
                }
                string[] file = File.ReadAllLines(textBox_selectfile.Text);
                List<User> values = file
                    .Skip(1)
                    .Select(v => User.FromCSV(v))
                    .ToList();
                foreach (User user in values)
                {
                    if (user!=null&&user.userPrincipalName!=null)
                    {
                        users.Add(user);
                        listBox_users.Items.Add(user.userPrincipalName);
                    }
                }
            }
            catch (Exception err)
            {
                listBox_users.Items.Add(err.Message);
            }
        }

        private async void button_transferusers_Click(object sender, EventArgs e)
        {
            foreach (User user in users)
            {
                try
                {
                    UserExtension userExtension = new();
                    userExtension.userName = user.userPrincipalName;
                    using HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                    var stringContent = new StringContent(JsonSerializer.Serialize(userExtension), Encoding.UTF8, "application/json");
                    var result = await httpClient.PostAsync("user",stringContent);
                    listBox_users.Items.Remove(user.userPrincipalName);
                }
                catch (Exception)
                {

                }
            }
            users.Clear();
        }
    }
    internal class UserExtension
    {
        public string userName { get; set; }
    }
}
