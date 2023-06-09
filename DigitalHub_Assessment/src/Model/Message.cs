using System;
using System.Collections.Generic;

namespace src.Model;

public partial class Message
{
    public long Id { get; set; }

    public long MessageNumber { get; set; }

    public long? ChatId { get; set; }

    public string Body { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Chat Chat { get; set; }
}
