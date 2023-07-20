using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class AppsUserSchemeApp
{
    /// <summary>
    /// Clave primaria
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// id esquema
    /// </summary>
    public string IdAppsSchemeApps { get; set; } = null!;

    /// <summary>
    /// id usuario
    /// </summary>
    public string IdAppsUser { get; set; } = null!;
}
