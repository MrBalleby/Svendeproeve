using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace CanteenSystemsApi.Model
{
    public class BuffetMenu
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int WeekNumber { get; set; }
        public string DayOfWeek { get; set; }
        public int Year { get;set;}
    }
}
