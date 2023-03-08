using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CanteenSystems.Model
{
    public class BuffetMenu
    {
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int WeekNumber { get; set; }
        public string DayOfWeek { get; set; }
        public int Year { get; set; }
    }
}
