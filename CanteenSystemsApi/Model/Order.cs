using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenSystemsApi.Model;

public partial class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string UserId { get; set; } = null!;
    public List<Item>? Items { get; set; }

    public decimal? TotalPrice { get; set; }
}
