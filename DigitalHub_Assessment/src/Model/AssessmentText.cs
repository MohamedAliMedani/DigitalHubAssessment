using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentText
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public string Answer { get; set; }

    public ulong QuestionId { get; set; }

    public int Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AssessmentQuestion Question { get; set; }
}
