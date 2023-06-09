using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentTrueFalse
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public ulong QuestionId { get; set; }

    public int IsTrue { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AssessmentQuestion Question { get; set; }
}
