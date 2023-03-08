using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CanteenSystems.Model
{
    public class Catering
    {
        public int? Id { get; set; }
        public string UserId { get; set; } = null!;
        public int? ReferenceNumber { get; set; }
        public int Amount { get; set; }
        public DateTime Time { get; set; }
        public int? Category { get; set; }
        public string? Description { get; set; }
        public string? MeetingRoom { get; set; }
    }
}
