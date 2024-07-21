using System;
using System.Collections.Generic;

namespace Exam_Guardian.core.Data
{
    public partial class UserInfo
    {
        public UserInfo()
        {
            ExamProviders = new HashSet<ExamProvider>();
            ExamReservations = new HashSet<ExamReservation>();
            Testimonials = new HashSet<Testimonial>();
        }

        public decimal UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public decimal? CredentialId { get; set; }
        public decimal? RoleId { get; set; }
        public decimal? StateId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual UserCredential? Credential { get; set; }
        public virtual UserRole? Role { get; set; }
        public virtual UserState? State { get; set; }
        public virtual ICollection<ExamProvider> ExamProviders { get; set; }
        public virtual ICollection<ExamReservation> ExamReservations { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
    }
}
