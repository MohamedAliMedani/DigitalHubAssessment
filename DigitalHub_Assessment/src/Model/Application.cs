using System;
using System.Collections.Generic;

namespace src.Model;

public partial class Application
{
    public string Id { get; set; }

    public string Name { get; set; }

    public int ChatsCount { get; set; }

    public bool IsDeleted { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();
}
