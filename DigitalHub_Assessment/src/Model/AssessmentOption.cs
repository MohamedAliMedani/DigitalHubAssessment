using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentOption
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public string Option { get; set; }

    public ulong QuestionId { get; set; }

    public bool Correct { get; set; }

    public int Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AssessmentQuestion Question { get; set; }
}
