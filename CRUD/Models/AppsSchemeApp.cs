using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class AppsSchemeApp
{
    /// <summary>
    /// Clave primaria
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// id esquema
    /// </summary>
    public string IdAppsScheme { get; set; } = null!;

    /// <summary>
    /// id usuario
    /// </summary>
    public string IdAppsApps { get; set; } = null!;
}
