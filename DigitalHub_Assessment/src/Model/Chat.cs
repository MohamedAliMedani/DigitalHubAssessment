using System;
using System.Collections.Generic;

namespace src.Model;

public partial class Chat
{
    public long Id { get; set; }

    public long ChatNumber { get; set; }

    public string ApplicationId { get; set; }

    public int MessagesCount { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Application Application { get; set; }

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
