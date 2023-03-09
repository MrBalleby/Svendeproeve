using CanteenSystems.Model;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CanteenSystems
{
    public partial class FoodMenu : Form
    {
        List<BuffetMenu> menus { get;set;}
        int activeWeek;
        public FoodMenu()
        {
            InitializeComponent();
            menus = new();
            OnLoad();
        }

        private async void OnLoad()
        {
            using HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.balleby.org/");
            HttpResponseMessage result = await httpClient.GetAsync("buffetmenu");
            if (result.IsSuccessStatusCode)
            {
                var itemsstring = result.Content.ReadAsStringAsync().Result;
                menus = JsonSerializer.Deserialize<List<BuffetMenu>>(itemsstring, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            }
        }

        private void monthCalendar_menu_DateSelected(object sender, DateRangeEventArgs e)
        {
            LoadMenu(monthCalendar_menu.SelectionStart);
        }

        private async void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                List<BuffetMenu> selectedMenu = menus.Where(x => x.WeekNumber == activeWeek).ToList();
                foreach (BuffetMenu item in selectedMenu)
                {
                    switch (item.DayOfWeek)
                    {
                        case "Mandag":
                            item.Title = richTextBox_menu1.Text;
                            break;
                        case "Tirsdag":
                            item.Title = richTextBox_menu2.Text;
                            break;
                        case "Onsdag":
                            item.Title = richTextBox_menu3.Text;
                            break;
                        case "Torsdag":
                            item.Title = richTextBox_menu4.Text;
                            break;
                        case "Fredag":
                            item.Title = richTextBox_menu5.Text;
                            break;
                        case "Lørdag":
                            break;
                        case "Søndag":
                            break;
                        default:
                            break;
                    }
                    if (item.Id != null) //Update
                    {
                        StringContent stringContent = new(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json");
                        using HttpClient httpClient = new HttpClient();
                        httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                        HttpResponseMessage result = await httpClient.PutAsync($"buffetmenu/{item.Id}",stringContent);
                    }
                    else //Create
                    {
                        StringContent stringContent = new(JsonSerializer.Serialize(item, new JsonSerializerOptions() { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull}), Encoding.UTF8, "application/json");
                        using HttpClient httpClient = new HttpClient();
                        httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                        HttpResponseMessage result = await httpClient.PostAsync($"buffetmenu", stringContent);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadMenu(DateTime date)
        {
            try
            {
                DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);
                int weeknumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                activeWeek = weeknumber;
                List<BuffetMenu> selectedMenu = menus.Where(x => x.WeekNumber == weeknumber).ToList();
                foreach (BuffetMenu item in selectedMenu)
                {
                    if (item != null)
                    {
                        switch (item.DayOfWeek)
                        {
                            case "Mandag":
                                richTextBox_menu1.Text = item.Title;
                                break;
                            case "Tirsdag":
                                richTextBox_menu2.Text = item.Title;
                                break;
                            case "Onsdag":
                                richTextBox_menu3.Text = item.Title;
                                break;
                            case "Torsdag":
                                richTextBox_menu4.Text = item.Title;
                                break;
                            case "Fredag":
                                richTextBox_menu5.Text = item.Title;
                                break;
                            case "Lørdag":
                                break;
                            case "Søndag":
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
