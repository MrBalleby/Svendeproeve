using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenSystemsApi.Model;

public partial class Catering
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string UserId { get; set; } = null!;

    public int? ReferenceNumber { get; set; }

    public int Amount { get; set; }

    public DateTime Time { get; set; }

    public int? Category { get; set; }

    public string? Description { get; set; }

    public string? MeetingRoom { get; set; }
}
