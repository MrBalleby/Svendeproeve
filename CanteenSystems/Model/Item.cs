using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenSystems.Model
{
    public class Item
    {
        public int? Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int Amount { get; set; }

        public bool IsHidden { get; set; }

        public int? ItemGroup { get; set; }
    }
}
