using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentMatch
{
    public ulong Id { get; set; }

    public Guid AnswerId { get; set; }

    public Guid QuestionId { get; set; }

    public string Option { get; set; }

    public string Answer { get; set; }

    public ulong QuestionId1 { get; set; }

    public int Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual AssessmentQuestion QuestionId1Navigation { get; set; }
}
