using System;

namespace FastFood.Entites;

public abstract class Auditable : BaseEntitiy
{
    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
