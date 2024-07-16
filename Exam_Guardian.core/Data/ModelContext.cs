using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exam_Guardian.core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Aboutpoint> Aboutpoints { get; set; } = null!;
        public virtual DbSet<Complement> Complements { get; set; } = null!;
        public virtual DbSet<ContactU> ContactUs { get; set; } = null!;
        public virtual DbSet<ExamInfo> ExamInfos { get; set; } = null!;
        public virtual DbSet<ExamProvider> ExamProviders { get; set; } = null!;
        public virtual DbSet<ExamReservation> ExamReservations { get; set; } = null!;
        public virtual DbSet<Examreservationstate> Examreservationstates { get; set; } = null!;
        public virtual DbSet<Plan> Plans { get; set; } = null!;
        public virtual DbSet<PlanFeature> PlanFeatures { get; set; } = null!;
        public virtual DbSet<TermsAndCondition> TermsAndConditions { get; set; } = null!;
        public virtual DbSet<Testimonalstate> Testimonalstates { get; set; } = null!;
        public virtual DbSet<Testimonial> Testimonials { get; set; } = null!;
        public virtual DbSet<UserCredential> UserCredentials { get; set; } = null!;
        public virtual DbSet<UserInfo> UserInfos { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public virtual DbSet<UserState> UserStates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("User Id=C##SYS_Guardian;PASSWORD=0000;DATA SOURCE=localhost:1521/xe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##SYS_GUARDIAN")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("ABOUT");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Aboutpoint>(entity =>
            {
                entity.HasKey(e => e.AboutpointsId)
                    .HasName("SYS_C0014701");

                entity.ToTable("ABOUTPOINTS");

                entity.Property(e => e.AboutpointsId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ABOUTPOINTS_ID");

                entity.Property(e => e.AboutId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ABOUT_ID");

                entity.Property(e => e.Listitem)
                    .HasMaxLength(255)
                    .HasColumnName("LISTITEM");

                entity.HasOne(d => d.About)
                    .WithMany(p => p.Aboutpoints)
                    .HasForeignKey(d => d.AboutId)
                    .HasConstraintName("SYS_C0014702");
            });

            modelBuilder.Entity<Complement>(entity =>
            {
                entity.ToTable("COMPLEMENT");

                entity.Property(e => e.ComplementId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("COMPLEMENT_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ExamReservationId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("EXAM_RESERVATION_ID");

                entity.Property(e => e.ProctorDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PROCTOR_DESC");

                entity.Property(e => e.StudentDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_DESC");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n   ");

                entity.HasOne(d => d.ExamReservation)
                    .WithMany(p => p.Complements)
                    .HasForeignKey(d => d.ExamReservationId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_RESERVATIONID");
            });

            modelBuilder.Entity<ContactU>(entity =>
            {
                entity.HasKey(e => e.ContactId)
                    .HasName("PK_CONTACT_ID");

                entity.ToTable("CONTACT_US");

                entity.Property(e => e.ContactId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CONTACT_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Message)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Subject)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<ExamInfo>(entity =>
            {
                entity.HasKey(e => e.ExamId)
                    .HasName("SYS_C0014499");

                entity.ToTable("EXAM_INFO");

                entity.Property(e => e.ExamId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAM_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.ExamImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXAM_IMAGE");

                entity.Property(e => e.ExamProviderId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAM_PROVIDER_ID");

                entity.Property(e => e.ExamTitle)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXAM_TITLE");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT");

                entity.HasOne(d => d.Exam)
                    .WithOne(p => p.ExamInfo)
                    .HasForeignKey<ExamInfo>(d => d.ExamId)
                    .HasConstraintName("EXAM_INFO_FK1");

                entity.HasOne(d => d.ExamProvider)
                    .WithMany(p => p.ExamInfos)
                    .HasForeignKey(d => d.ExamProviderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("EXAM_INFO_FK2");
            });

            modelBuilder.Entity<ExamProvider>(entity =>
            {
                entity.ToTable("EXAM_PROVIDER");

                entity.Property(e => e.ExamProviderId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAM_PROVIDER_ID");

                entity.Property(e => e.CommercialRecordImg)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("COMMERCIAL_RECORD_IMG");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.ExamProviderUniqueKey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EXAM_PROVIDER_UNIQUE_KEY");

                entity.Property(e => e.Image)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.PlanId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PLAN_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.ExamProviders)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_PLANNID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamProviders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("EXAM_PROVIDER_FK1");
            });

            modelBuilder.Entity<ExamReservation>(entity =>
            {
                entity.ToTable("EXAM_RESERVATION");

                entity.Property(e => e.ExamReservationId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAM_RESERVATION_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EndDate)
                    .HasPrecision(6)
                    .HasColumnName("END_DATE");

                entity.Property(e => e.ExamId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAM_ID");

                entity.Property(e => e.Phone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PHONE");

                entity.Property(e => e.ProctorTokenEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PROCTOR_TOKEN_EMAIL");

                entity.Property(e => e.Score)
                    .HasColumnType("NUMBER")
                    .HasColumnName("SCORE");

                entity.Property(e => e.StartDate)
                    .HasPrecision(6)
                    .HasColumnName("START_DATE");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_NAME");

                entity.Property(e => e.StudentTokenEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STUDENT_TOKEN_EMAIL");

                entity.Property(e => e.UniqueKey)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UNIQUE_KEY");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USER_ID");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.ExamReservations)
                    .HasForeignKey(d => d.ExamId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("EXAM_INFO_FK");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ExamReservations)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERSID");
            });

            modelBuilder.Entity<Examreservationstate>(entity =>
            {
                entity.ToTable("EXAMRESERVATIONSTATE");

                entity.Property(e => e.Examreservationstateid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EXAMRESERVATIONSTATEID");

                entity.Property(e => e.Examreservationstate1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EXAMRESERVATIONSTATE");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("PLAN");

                entity.Property(e => e.PlanId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PLAN_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.PlanDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("PLAN_DESCRIPTION");

                entity.Property(e => e.PlanName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PLAN_NAME");

                entity.Property(e => e.PlanPrice)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("PLAN_PRICE");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n   ");
            });

            modelBuilder.Entity<PlanFeature>(entity =>
            {
                entity.ToTable("PLAN_FEATURE");

                entity.Property(e => e.PlanFeatureId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PLAN_FEATURE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.FeaturesName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FEATURES_NAME");

                entity.Property(e => e.PlanId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PLAN_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlanFeatures)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("PLAN_FEATURE_FK1");
            });

            modelBuilder.Entity<TermsAndCondition>(entity =>
            {
                entity.HasKey(e => e.TermsId)
                    .HasName("PK_TERMS_ID");

                entity.ToTable("TERMS_AND_CONDITIONS");

                entity.Property(e => e.TermsId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TERMS_ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT");
            });

            modelBuilder.Entity<Testimonalstate>(entity =>
            {
                entity.ToTable("TESTIMONALSTATE");

                entity.Property(e => e.Testimonalstateid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONALSTATEID");

                entity.Property(e => e.Testimonalstate1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONALSTATE");
            });

            modelBuilder.Entity<Testimonial>(entity =>
            {
                entity.ToTable("TESTIMONIAL");

                entity.Property(e => e.Testimonialid)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMONIALID");

                entity.Property(e => e.Createdat)
                    .HasColumnType("DATE")
                    .HasColumnName("CREATEDAT");

                entity.Property(e => e.ExamProviderId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EXAM_PROVIDER_ID");

                entity.Property(e => e.Testimonalstateid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("TESTIMONALSTATEID");

                entity.Property(e => e.Testimonialtext)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("TESTIMONIALTEXT");

                entity.Property(e => e.Updatedat)
                    .HasColumnType("DATE")
                    .HasColumnName("UPDATEDAT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.ExamProvider)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.ExamProviderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_EXAM_PROVIDER");

                entity.HasOne(d => d.Testimonalstate)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Testimonalstateid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_TESTIMONALSTATEID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Testimonials)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_USERID");
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasKey(e => e.CredentialId);

                entity.ToTable("USER_CREDENTIAL");

                entity.HasIndex(e => e.Email, "SYS_C0014501")
                    .IsUnique();

                entity.HasIndex(e => e.Phonenum, "SYS_C0014502")
                    .IsUnique();

                entity.Property(e => e.CredentialId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CREDENTIAL_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Password)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Phonenum)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUM");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n   ");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_USER_ID");

                entity.ToTable("USER_INFO");

                entity.Property(e => e.UserId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USER_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CredentialId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CREDENTIAL_ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LAST_NAME");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.StateId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("STATE_ID");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n   ");

                entity.HasOne(d => d.Credential)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.CredentialId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_CREDENTIALID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_ROLEID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.UserInfos)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_STATEID");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_ROLE_ID");

                entity.ToTable("USER_ROLE");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ROLE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_NAME");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n   ");
            });

            modelBuilder.Entity<UserState>(entity =>
            {
                entity.HasKey(e => e.StateId)
                    .HasName("PK_STATE_ID");

                entity.ToTable("USER_STATES");

                entity.Property(e => e.StateId)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("STATE_ID");

                entity.Property(e => e.CreatedAt)
                    .HasPrecision(6)
                    .HasColumnName("CREATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_NAME");

                entity.Property(e => e.UpdatedAt)
                    .HasPrecision(6)
                    .HasColumnName("UPDATED_AT")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP\n   ");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
