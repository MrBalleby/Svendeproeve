using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CanteenSystemsApi.Model;

public partial class Auth
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
