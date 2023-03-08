using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenSystemsApi.Model
{
    public class BuffetRegistration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateTime { get; set; }
    }
}
