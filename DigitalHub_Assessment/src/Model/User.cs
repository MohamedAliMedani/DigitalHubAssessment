using System;
using System.Collections.Generic;

namespace src.Model;

public partial class User
{
    public ulong Id { get; set; }

    public Guid Id1 { get; set; }

    public Guid? ApiKey { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public bool IsBanned { get; set; }

    public bool IsVerified { get; set; }

    public Guid ConfirmCode { get; set; }

    public DateTime? ConfirmedAt { get; set; }

    public DateTime? PasswordChangedAt { get; set; }

    public string DisplayName { get; set; }

    public string UserUrl { get; set; }

    public byte IsLdap { get; set; }

    public ulong CreatedBy { get; set; }

    public ulong UpdatedBy { get; set; }

    public string RememberToken { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string Otp { get; set; }

    public DateTime? OtpCreatedAt { get; set; }

    public ulong? ProfilePictureId { get; set; }

    public virtual ICollection<AssessmentAnswer> AssessmentAnswers { get; set; } = new List<AssessmentAnswer>();

    public virtual ICollection<AssessmentEnrol> AssessmentEnrols { get; set; } = new List<AssessmentEnrol>();
}
