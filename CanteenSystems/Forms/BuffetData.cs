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
    public partial class BuffetData : Form
    {
        List<BuffetRegistration> buffetregistration;
        List<(DateTime,Double?)> selectedData;
        public BuffetData()
        {
            InitializeComponent();
            buffetregistration = new();
            selectedData = new();
            LoadData();
        }

        private async void LoadData()
        {
            try
            {
                using HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri("https://api.balleby.org/");
                string result = await httpClient.GetAsync($"buffet").Result.Content.ReadAsStringAsync();
                buffetregistration = JsonSerializer.Deserialize<List<BuffetRegistration>>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive= true });
            }
            catch (Exception)
            {

            }

        }

        private void comboBox_datespan_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime endDate;
            switch (comboBox_datespan.SelectedIndex)
            {
                case 0: // I dag
                    endDate = DateTime.Now;
                    ShowData(DateTime.Now,endDate);
                    break;
                case 1: // 1 uge
                    endDate = DateTime.Now.AddDays(-7);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 2: // 1 måned
                    endDate = DateTime.Now.AddMonths(-1);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 3: // 3 måneder
                    endDate = DateTime.Now.AddMonths(-3);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 4: // 6 måneder
                    endDate = DateTime.Now.AddMonths(-6);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 5: // 1 år
                    endDate = DateTime.Now.AddYears(-1);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 6: // 2 år
                    endDate = DateTime.Now.AddYears(-2);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 7: // 3 år
                    endDate = DateTime.Now.AddYears(-3);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 8: // 4 år
                    endDate = DateTime.Now.AddYears(-4);
                    ShowData(DateTime.Now, endDate);
                    break;
                case 9: // 5 år
                    endDate = DateTime.Now.AddYears(-5);
                    ShowData(DateTime.Now, endDate);
                    break;
                default:
                    break;
            }
        }


        private void ShowData(DateTime start,DateTime end)
        {
            try
            {
                List<BuffetRegistration> selected = buffetregistration.FindAll(x=>x.DateTime >= end && x.DateTime <= start);
                chart_data.Series.Clear();
                chart_data.Series.Add("AntalGæster");
                chart_data.Series["AntalGæster"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                var averages = selected.GroupBy(grp => grp.DateTime.Date)
                                    .Select(grp => new { Date = grp.Key, Average = grp.Average(it => it.Id) });
                foreach (var item in averages)
                {
                    selectedData.Add((item.Date,item.Average));
                    chart_data.Series["AntalGæster"].Points.AddXY(item.Date,item.Average);
                }
            }
            catch (Exception)
            {

            }
        }

        private void button_save_buffetdata_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_filetype.SelectedIndex == 0)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Dato");
                    dt.Columns.Add("Forbrug");
                    foreach (var item in selectedData)
                    {
                        dt.Rows.Add(item.Item1, item.Item2);
                    }
                    string csv = string.Empty;
                    foreach (DataColumn column in dt.Columns)
                    {
                        csv += column.ColumnName + ',';
                    }
                    csv += "\r\n";
                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (object cell in row.ItemArray)
                        {
                            csv += cell.ToString().Replace(",", ";") + ',';
                        }
                        csv += "\r\n";
                    }
                    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BuffetData.csv"), csv);
                }
                else if (comboBox_filetype.SelectedIndex == 1)
                {
                    string json = JsonSerializer.Serialize(selectedData);
                    File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BuffetData.json"), json);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
