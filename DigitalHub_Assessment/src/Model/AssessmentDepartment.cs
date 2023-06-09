using System;
using System.Collections.Generic;

namespace src.Model;

public partial class AssessmentDepartment
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public ulong GroupId { get; set; }

    public ulong AssessmentId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
