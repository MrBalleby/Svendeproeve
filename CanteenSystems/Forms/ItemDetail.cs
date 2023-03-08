using CanteenSystems.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenSystems
{
    public partial class ItemDetail : Form
    {
        private Item? _currentItem { get;set; }
        private List<ItemGroup> _itemsgroup = new List<ItemGroup>();

        public ItemDetail(Item? item)
        {
            _currentItem = item;
            InitializeComponent();
            ItemDetail_LoadItem();
        }

        private async void ItemDetail_LoadItem()
        {
            try
            {
                comboBox_ItemGroup.Items.Clear();
                comboBox_Vissible.Items.Clear();
                using HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                string itemgroups = await httpClient.GetAsync("itemsgroup").Result.Content.ReadAsStringAsync();
                _itemsgroup = JsonSerializer.Deserialize<List<ItemGroup>>(itemgroups, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                comboBox_ItemGroup.DataSource = _itemsgroup;
                comboBox_ItemGroup.DisplayMember = "Title";
                comboBox_Vissible.DataSource = new List<string>() { "Ja", "Nej" };
                if (_currentItem != null)
                {


                    //Set Title
                    textBox_Title.Text = _currentItem.Title;
                    //Set Description
                    richTextBox_Description.Text = _currentItem.Description;
                    //Set Price
                    textBox_Price.Text = _currentItem.Price.ToString();
                    //Set Amount
                    textBox_Amount.Text = _currentItem.Amount.ToString();
                    ////Set Vissible
                    comboBox_Vissible.SelectedIndex = comboBox_Vissible.FindString(_currentItem.IsHidden == false ? "Ja" : "Nej");
                    //Set ItemGroup
                    var selecteditemgroup = await httpClient.GetAsync($"itemsgroup/{_currentItem.ItemGroup}").Result.Content.ReadAsStringAsync();
                    if (selecteditemgroup != "")
                    {
                        comboBox_ItemGroup.SelectedIndex = comboBox_ItemGroup.FindString(JsonSerializer.Deserialize<ItemGroup>(selecteditemgroup, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).Title);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private async void button_Save_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                ItemGroup? itemGroup = (ItemGroup)comboBox_ItemGroup.SelectedItem;
                string isvissible = (string)comboBox_Vissible.SelectedItem;
                if (_currentItem != null)
                {
                    Item item = new()
                    {
                        Id = _currentItem.Id,
                        Title = textBox_Title.Text,
                        Description = richTextBox_Description.Text,
                        Price = Convert.ToDecimal(textBox_Price.Text),
                        Amount = Convert.ToInt32(textBox_Amount.Text),
                        IsHidden = isvissible == "Ja" ? false : true,
                        ItemGroup= itemGroup.Id
                    };
                    StringContent stringContent = new(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
                    using HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                    string result = await httpClient.PutAsync($"items/{_currentItem.Id}", stringContent).Result.Content.ReadAsStringAsync();
                }
                else
                {
                    Item item = new()
                    {
                        Id = null,
                        Title = textBox_Title.Text,
                        Description = richTextBox_Description.Text,
                        Price = Convert.ToInt32(textBox_Price.Text == "" ? 0 : textBox_Price.Text),
                        Amount = Convert.ToInt32(textBox_Amount.Text==""?0:textBox_Amount.Text),
                        IsHidden = isvissible == "Ja" ? false : true,
                        ItemGroup = itemGroup.Id
                    };
                    StringContent stringContent = new(JsonSerializer.Serialize(item, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull }), Encoding.UTF8, "application/json");
                    using HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                    string result = await httpClient.PostAsync($"items", stringContent).Result.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button_delete_item_Click(object sender, EventArgs e)
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.balleby.org/");
            string result = await httpClient.DeleteAsync($"items/{_currentItem.Id}").Result.Content.ReadAsStringAsync();
            this.Close();
        }
    }
}
