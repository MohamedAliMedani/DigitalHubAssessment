using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentQuestionsRelation
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public ulong QuestionId { get; set; }

    public ulong AssessmentId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Assessment Assessment { get; set; }

    public virtual AssessmentQuestion Question { get; set; }
}
