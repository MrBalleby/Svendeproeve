using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CanteenSystems.Model
{
    public class BuffetRegistration
    {
        private DateTime datetime;
        public int? Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get => datetime.ToLocalTime(); set => datetime = value;}
    }
}
