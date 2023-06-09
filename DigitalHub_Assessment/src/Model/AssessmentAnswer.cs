using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentAnswer
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public ulong AssessmentId { get; set; }

    public ulong QuestionId { get; set; }

    public string Answer { get; set; }

    public ulong UserId { get; set; }

    public sbyte Score { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Assessment Assessment { get; set; }

    public virtual AssessmentQuestion Question { get; set; }

    public virtual User User { get; set; }
}
