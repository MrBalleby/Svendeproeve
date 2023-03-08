using CanteenSystems.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanteenSystems
{
    public partial class WebshopItems : Form
    {
        private Form activeForm;
        List<Item> items;
        List<ItemGroup> groups;
        public WebshopItems()
        {
            InitializeComponent();
            items = new();
            groups = new();
            WebshopItems_LoadItemsAsync();
        }

        private async void WebshopItems_LoadItemsAsync()
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                HttpResponseMessage result = await httpClient.GetAsync("items");
                if (result.IsSuccessStatusCode)
                {
                    var itemsstring = result.Content.ReadAsStringAsync().Result;
                    items = JsonSerializer.Deserialize<List<Item>>(itemsstring,new JsonSerializerOptions() { PropertyNameCaseInsensitive=true });
                    listBox_items.DataSource = items;
                    listBox_items.DisplayMember = "Title";
                    button_additem.Text = "Tilføj vare";
                    button_change_itemgroups.Text = "Varegruppe overblik";
                }
            }
            catch (Exception)
            {

            }
        }

        private async void listBox_items_SelectedIndexChangedAsync(object sender, EventArgs e)
        {
            try
            {
                if (listBox_items.DataSource == items)
                {
                    Item selectedItem = (Item)listBox_items.SelectedItem;
                    using HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                    string result = await httpClient.GetAsync($"items/{selectedItem.Id}").Result.Content.ReadAsStringAsync();
                    OpenItemDetailForm(new ItemDetail(JsonSerializer.Deserialize<Item>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })), sender);
                }
                else if (listBox_items.DataSource == groups)
                {
                    ItemGroup selectedItem = (ItemGroup)listBox_items.SelectedItem;
                    using HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                    string result = await httpClient.GetAsync($"itemsgroup/{selectedItem.Id}").Result.Content.ReadAsStringAsync();
                    OpenItemDetailForm(new ItemGroupDetail(JsonSerializer.Deserialize<ItemGroup>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })), sender);
                }
            }
            catch (Exception)
            {

            }
        }

        void OpenItemDetailForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            activeForm.TopLevel = false;
            activeForm.MinimumSize = panel_itemcontent.Size;
            activeForm.MaximumSize = panel_itemcontent.Size;
            activeForm.FormBorderStyle = FormBorderStyle.None;
            activeForm.AutoScroll = true;
            activeForm.Dock = DockStyle.Fill;
            panel_itemcontent.Controls.Add(activeForm);
            panel_itemcontent.Tag = activeForm;
            activeForm.BringToFront();
            activeForm.Show();
        }

        private void button_additem_Click(object sender, EventArgs e)
        {
            if (listBox_items.DataSource == items)
            {
                OpenItemDetailForm(new ItemDetail(null), sender);
            }
            else if (listBox_items.DataSource == groups)
            {
                OpenItemDetailForm(new ItemGroupDetail(null), sender);
            }
        }

        private async void button_change_itemgroups_Click(object sender, EventArgs e)
        {
            if (listBox_items.DataSource == items)
            {
                try
                {
                    using HttpClient httpClient = new HttpClient();
                    httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                    HttpResponseMessage result = await httpClient.GetAsync("itemsgroup");
                    if (result.IsSuccessStatusCode)
                    {
                        var itemsgroupstring = result.Content.ReadAsStringAsync().Result;
                        groups = JsonSerializer.Deserialize<List<ItemGroup>>(itemsgroupstring, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                        listBox_items.DataSource = groups;
                        listBox_items.DisplayMember = "Title";
                        button_additem.Text = "Tilføj varegruppe";
                        button_change_itemgroups.Text = "Vare overblik";
                    }
                }
                catch (Exception)
                {

                }

            }
            else if (listBox_items.DataSource == groups)
            {
                WebshopItems_LoadItemsAsync();
            }
        }
    }
}
