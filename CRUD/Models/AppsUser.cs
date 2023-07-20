using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class AppsUser
{
    /// <summary>
    /// Clave primaria
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// id esquema
    /// </summary>
    public string AppsUser1 { get; set; } = null!;

    /// <summary>
    /// id usuario
    /// </summary>
    public string AppsFullNames { get; set; } = null!;

    public string? AppsDescritionUser { get; set; }
}
