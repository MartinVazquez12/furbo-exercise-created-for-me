using System;
using System.Collections.Generic;

namespace furboWebApi.Models;

public partial class Clube
{
    public Guid Id { get; set; }

    public string Club { get; set; } = null!;

    public virtual ICollection<Jugador> Jugadors { get; set; } = new List<Jugador>();
}
