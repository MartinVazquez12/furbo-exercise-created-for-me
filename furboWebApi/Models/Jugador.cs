using System;
using System.Collections.Generic;

namespace furboWebApi.Models;

public partial class Jugador
{
    public Guid Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Posicion { get; set; } = null!;

    public string ValorMercado { get; set; } = null!;

    public string Edad { get; set; } = null!;

    public Guid IdClub { get; set; }

    public virtual Clube IdClubNavigation { get; set; } = null!;
}
