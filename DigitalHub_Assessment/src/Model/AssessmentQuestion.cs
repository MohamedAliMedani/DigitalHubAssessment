namespace src.Model;

public partial class AssessmentQuestion
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public string Question { get; set; }

    public ulong CategoryId { get; set; }

    public int Level { get; set; }

    public int Order { get; set; }

    public string Type { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<AssessmentAnswer> AssessmentAnswers { get; set; } = new List<AssessmentAnswer>();

    public virtual ICollection<AssessmentMatch> AssessmentMatches { get; set; } = new List<AssessmentMatch>();

    public virtual ICollection<AssessmentOption> AssessmentOptions { get; set; } = new List<AssessmentOption>();

    public virtual ICollection<AssessmentQuestionsRelation> AssessmentQuestionsRelations { get; set; } = new List<AssessmentQuestionsRelation>();

    public virtual ICollection<AssessmentText> AssessmentTexts { get; set; } = new List<AssessmentText>();

    public virtual ICollection<AssessmentTrueFalse> AssessmentTrueFalses { get; set; } = new List<AssessmentTrueFalse>();
}
