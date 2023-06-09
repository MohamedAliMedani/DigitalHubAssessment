using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentEnrol
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public ulong AssessmentId { get; set; }

    public ulong UserId { get; set; }

    public int? Result { get; set; }

    public sbyte Score { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Assessment Assessment { get; set; }

    public virtual User User { get; set; }
}
