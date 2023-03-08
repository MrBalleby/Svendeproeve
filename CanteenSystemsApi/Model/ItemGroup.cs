using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenSystemsApi.Model;

public partial class ItemGroup
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string Title { get; set; } = null!;
}
