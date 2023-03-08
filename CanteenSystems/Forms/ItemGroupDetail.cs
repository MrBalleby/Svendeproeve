using CanteenSystems.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenSystems
{
    public partial class ItemGroupDetail : Form
    {
        private ItemGroup? _currentItem { get;set; }

        public ItemGroupDetail(ItemGroup? group)
        {
            _currentItem = group;
            InitializeComponent();
            ItemDetail_LoadItem();
        }

        private async void ItemDetail_LoadItem()
        {
            try
            {
                if (_currentItem != null)
                {
                    //Set Title
                    textBox_Title.Text = _currentItem.Title;
                }
            }
            catch (Exception)
            {

            }
        }

        private async void button_Save_ClickAsync(object sender, EventArgs e)
        {
            if (_currentItem != null)
            {
                ItemGroup group = new()
                {
                    Id = _currentItem.Id,
                    Title = textBox_Title.Text
                };
                StringContent stringContent = new(JsonSerializer.Serialize(group), Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                string result = await httpClient.PutAsync($"itemsgroup/{_currentItem.Id}", stringContent).Result.Content.ReadAsStringAsync();
            }
            else
            {
                ItemGroup group = new()
                {
                    Id = null,
                    Title = textBox_Title.Text
                };
                StringContent stringContent = new(JsonSerializer.Serialize(group,new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull}), Encoding.UTF8, "application/json");
                using HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                string result = await httpClient.PostAsync($"itemsgroup", stringContent).Result.Content.ReadAsStringAsync();
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button_delete_itemgroup_Click(object sender, EventArgs e)
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.balleby.org/");
            string result = await httpClient.DeleteAsync($"itemsgroup/{_currentItem.Id}").Result.Content.ReadAsStringAsync();
            this.Close();
        }
    }
}
