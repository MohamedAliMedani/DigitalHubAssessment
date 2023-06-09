using System;
using System.Collections.Generic;

namespace src.Model;

public partial class Assessment
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public string Title { get; set; }

    public string ShortDescription { get; set; }

    public string Description { get; set; }

    public string Slug { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public int Duration { get; set; }

    public ulong? CategoryId { get; set; }

    public string Thumbnail { get; set; }

    public bool? Published { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AssessmentAnswer> AssessmentAnswers { get; set; } = new List<AssessmentAnswer>();

    public virtual ICollection<AssessmentDatum> AssessmentData { get; set; } = new List<AssessmentDatum>();

    public virtual ICollection<AssessmentEnrol> AssessmentEnrols { get; set; } = new List<AssessmentEnrol>();

    public virtual ICollection<AssessmentMetum> AssessmentMeta { get; set; } = new List<AssessmentMetum>();

    public virtual ICollection<AssessmentQuestionsRelation> AssessmentQuestionsRelations { get; set; } = new List<AssessmentQuestionsRelation>();

    public virtual ICollection<AssessmentSection> AssessmentSections { get; set; } = new List<AssessmentSection>();
}
