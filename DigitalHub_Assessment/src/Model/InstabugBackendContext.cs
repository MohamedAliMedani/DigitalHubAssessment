using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace src.Model;

public partial class InstabugBackendContext : DbContext
{
    public InstabugBackendContext()
    {
    }

    public InstabugBackendContext(DbContextOptions<InstabugBackendContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<AssessmentAnswer> AssessmentAnswers { get; set; }

    public virtual DbSet<AssessmentDatum> AssessmentData { get; set; }

    public virtual DbSet<AssessmentDepartment> AssessmentDepartments { get; set; }

    public virtual DbSet<AssessmentEnrol> AssessmentEnrols { get; set; }

    public virtual DbSet<AssessmentMatch> AssessmentMatches { get; set; }

    public virtual DbSet<AssessmentMetum> AssessmentMeta { get; set; }

    public virtual DbSet<AssessmentOption> AssessmentOptions { get; set; }

    public virtual DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }

    public virtual DbSet<AssessmentQuestionsRelation> AssessmentQuestionsRelations { get; set; }

    public virtual DbSet<AssessmentSection> AssessmentSections { get; set; }

    public virtual DbSet<AssessmentText> AssessmentTexts { get; set; }

    public virtual DbSet<AssessmentTrueFalse> AssessmentTrueFalses { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=127.0.0.1;user=root;password=Mohamedali0#;port=3306;database=instabug_backend");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("applications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ChatsCount).HasColumnName("chats_count");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ArInternalMetadatum>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("PRIMARY");

            entity.ToTable("ar_internal_metadata");

            entity.Property(e => e.Key).HasColumnName("key");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasMaxLength(255)
                .HasColumnName("value");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessments");

            entity.HasIndex(e => e.Id1, "assessments__id_unique").IsUnique();

            entity.HasIndex(e => e.CategoryId, "assessments_category_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration)
                .HasDefaultValueSql("'7'")
                .HasColumnName("duration");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.Published)
                .IsRequired()
                .HasDefaultValueSql("'1'")
                .HasColumnName("published");
            entity.Property(e => e.ShortDescription).HasColumnName("short_description");
            entity.Property(e => e.Slug)
                .HasMaxLength(255)
                .HasColumnName("slug");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
        });

        modelBuilder.Entity<AssessmentAnswer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_answers");

            entity.HasIndex(e => e.Id1, "assessment_answers__id_unique").IsUnique();

            entity.HasIndex(e => e.AssessmentId, "assessment_answers_assessment_id_foreign");

            entity.HasIndex(e => e.QuestionId, "assessment_answers_question_id_foreign");

            entity.HasIndex(e => e.UserId, "assessment_answers_user_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("answer");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentAnswers)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("assessment_answers_assessment_id_foreign");

            entity.HasOne(d => d.Question).WithMany(p => p.AssessmentAnswers)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("assessment_answers_question_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.AssessmentAnswers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("assessment_answers_user_id_foreign");
        });

        modelBuilder.Entity<AssessmentDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_data");

            entity.HasIndex(e => e.Id1, "assessment_data__id_unique").IsUnique();

            entity.HasIndex(e => e.AssessmentId, "assessment_data_assessment_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Data).HasColumnName("data");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentData)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("assessment_data_assessment_id_foreign");
        });

        modelBuilder.Entity<AssessmentDepartment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_department");

            entity.HasIndex(e => e.Id1, "assessment_department__id_unique").IsUnique();

            entity.HasIndex(e => e.AssessmentId, "assessment_department_assessment_id_foreign");

            entity.HasIndex(e => e.GroupId, "assessment_department_group_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AssessmentEnrol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_enrols");

            entity.HasIndex(e => e.Id1, "assessment_enrols__id_unique").IsUnique();

            entity.HasIndex(e => e.AssessmentId, "assessment_enrols_assessment_id_foreign");

            entity.HasIndex(e => e.UserId, "assessment_enrols_user_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.Score).HasColumnName("score");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentEnrols)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("assessment_enrols_assessment_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.AssessmentEnrols)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("assessment_enrols_user_id_foreign");
        });

        modelBuilder.Entity<AssessmentMatch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_match");

            entity.HasIndex(e => e.AnswerId, "assessment_match__answer_id_unique").IsUnique();

            entity.HasIndex(e => e.QuestionId, "assessment_match__question_id_unique").IsUnique();

            entity.HasIndex(e => e.QuestionId1, "assessment_match_question_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer)
                .HasColumnType("text")
                .HasColumnName("answer");
            entity.Property(e => e.AnswerId).HasColumnName("_answer_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Option)
                .HasColumnType("text")
                .HasColumnName("option");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.QuestionId).HasColumnName("_question_id");
            entity.Property(e => e.QuestionId1).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.QuestionId1Navigation).WithMany(p => p.AssessmentMatches)
                .HasForeignKey(d => d.QuestionId1)
                .HasConstraintName("assessment_match_question_id_foreign");
        });

        modelBuilder.Entity<AssessmentMetum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_meta");

            entity.HasIndex(e => e.Id1, "assessment_meta__id_unique").IsUnique();

            entity.HasIndex(e => e.AssessmentId, "assessment_meta_assessment_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentMeta)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("assessment_meta_assessment_id_foreign");
        });

        modelBuilder.Entity<AssessmentOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_options");

            entity.HasIndex(e => e.Id1, "assessment_options__id_unique").IsUnique();

            entity.HasIndex(e => e.QuestionId, "assessment_options_question_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Correct).HasColumnName("correct");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.Option)
                .HasColumnType("text")
                .HasColumnName("option");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Question).WithMany(p => p.AssessmentOptions)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("assessment_options_question_id_foreign");
        });

        modelBuilder.Entity<AssessmentQuestion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_questions");

            entity.HasIndex(e => e.Id1, "assessment_questions__id_unique").IsUnique();

            entity.HasIndex(e => e.CategoryId, "assessment_questions_category_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.Level).HasColumnName("level");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Question)
                .HasColumnType("text")
                .HasColumnName("question");
            entity.Property(e => e.Type)
                .HasColumnType("text")
                .HasColumnName("type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AssessmentQuestionsRelation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_questions_relation");

            entity.HasIndex(e => e.Id1, "assessment_questions_relation__id_unique").IsUnique();

            entity.HasIndex(e => e.AssessmentId, "assessment_questions_relation_assessment_id_foreign");

            entity.HasIndex(e => e.QuestionId, "assessment_questions_relation_question_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentQuestionsRelations)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("assessment_questions_relation_assessment_id_foreign");

            entity.HasOne(d => d.Question).WithMany(p => p.AssessmentQuestionsRelations)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("assessment_questions_relation_question_id_foreign");
        });

        modelBuilder.Entity<AssessmentSection>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_sections");

            entity.HasIndex(e => e.AssessmentId, "assessment_sections_assessment_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AssessmentId).HasColumnName("assessment_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Assessment).WithMany(p => p.AssessmentSections)
                .HasForeignKey(d => d.AssessmentId)
                .HasConstraintName("assessment_sections_assessment_id_foreign");
        });

        modelBuilder.Entity<AssessmentText>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_text");

            entity.HasIndex(e => e.Id1, "assessment_text__id_unique").IsUnique();

            entity.HasIndex(e => e.QuestionId, "assessment_text_question_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Answer).HasColumnName("answer");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.Order).HasColumnName("order");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Question).WithMany(p => p.AssessmentTexts)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("assessment_text_question_id_foreign");
        });

        modelBuilder.Entity<AssessmentTrueFalse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("assessment_true_false");

            entity.HasIndex(e => e.Id1, "assessment_true_false__id_unique").IsUnique();

            entity.HasIndex(e => e.QuestionId, "assessment_true_false_question_id_foreign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.IsTrue).HasColumnName("is_true");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Question).WithMany(p => p.AssessmentTrueFalses)
                .HasForeignKey(d => d.QuestionId)
                .HasConstraintName("assessment_true_false_question_id_foreign");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("chats");

            entity.HasIndex(e => e.ApplicationId, "index_chats_on_application_id");

            entity.HasIndex(e => new { e.ChatNumber, e.ApplicationId }, "index_chats_on_chat_number_and_application_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApplicationId)
                .IsRequired()
                .HasColumnName("application_id");
            entity.Property(e => e.ChatNumber).HasColumnName("chat_number");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.MessagesCount).HasColumnName("messages_count");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Application).WithMany(p => p.Chats)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rails_3b5054ba3a");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("messages");

            entity.HasIndex(e => e.ChatId, "index_messages_on_chat_id");

            entity.HasIndex(e => new { e.MessageNumber, e.ChatId }, "index_messages_on_message_number_and_chat_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Body)
                .IsRequired()
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.ChatId).HasColumnName("chat_id");
            entity.Property(e => e.CreatedAt)
                .HasMaxLength(6)
                .HasColumnName("created_at");
            entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");
            entity.Property(e => e.MessageNumber).HasColumnName("message_number");
            entity.Property(e => e.UpdatedAt)
                .HasMaxLength(6)
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Chat).WithMany(p => p.Messages)
                .HasForeignKey(d => d.ChatId)
                .HasConstraintName("fk_rails_0f670de7ba");
        });

        modelBuilder.Entity<SchemaMigration>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PRIMARY");

            entity.ToTable("schema_migrations");

            entity.Property(e => e.Version).HasColumnName("version");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Id1, "users__id_unique").IsUnique();

            entity.HasIndex(e => e.ApiKey, "users_api_key_unique").IsUnique();

            entity.HasIndex(e => e.Email, "users_email_unique").IsUnique();

            entity.HasIndex(e => e.Username, "users_username_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ApiKey).HasColumnName("api_key");
            entity.Property(e => e.ConfirmCode).HasColumnName("confirm_code");
            entity.Property(e => e.ConfirmedAt)
                .HasColumnType("datetime")
                .HasColumnName("confirmed_at");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DeletedAt)
                .HasColumnType("timestamp")
                .HasColumnName("deleted_at");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(255)
                .HasColumnName("display_name");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.Id1).HasColumnName("_id");
            entity.Property(e => e.IsBanned).HasColumnName("is_banned");
            entity.Property(e => e.IsLdap).HasColumnName("is_ldap");
            entity.Property(e => e.IsVerified).HasColumnName("is_verified");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Otp)
                .HasMaxLength(255)
                .HasColumnName("otp");
            entity.Property(e => e.OtpCreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("otp_created_at");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PasswordChangedAt)
                .HasColumnType("datetime")
                .HasColumnName("password_changed_at");
            entity.Property(e => e.ProfilePictureId).HasColumnName("profile_picture_id");
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .HasColumnName("remember_token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");
            entity.Property(e => e.UserUrl)
                .HasMaxLength(255)
                .HasColumnName("user_url");
            entity.Property(e => e.Username)
                .IsRequired()
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
