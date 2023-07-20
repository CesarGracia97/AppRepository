using System;
using System.Collections.Generic;

namespace CRUD.Models;

public partial class AppsApplication
{
    public int Id { get; set; }

    public string? NameApplication { get; set; }

    public string? DescriptionApplication { get; set; }
}
