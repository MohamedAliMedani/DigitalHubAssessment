using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentSection
{
    public ulong Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ulong AssessmentId { get; set; }

    public int Order { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Assessment Assessment { get; set; }
}
