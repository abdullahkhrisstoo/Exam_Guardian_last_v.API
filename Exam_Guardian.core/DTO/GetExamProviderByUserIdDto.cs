using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.DTO
{
    public class GetExamProviderByUserIdDto
    {
        public decimal ExamProviderId { get; set; }
        public string ExamProviderUniqueKey { get; set; }
        public decimal PlanId { get; set; }
        public decimal UserId { get; set; }
        public string CommercialRecordImg { get; set; }
        public string Image { get; set; }
        public PlanDto Plan { get; set; }
    }
    
    public class PlanDto
    {
        public decimal PlanId { get; set; }
        public string PlanName { get; set; }
        public string PlanDescription { get; set; }
        public decimal PlanPrice { get; set; }
        public List<PlanFeatureDto> PlanFeatures { get; set; }
    }
    public class PlanFeatureDto
    {
        public decimal PlanFeatureId { get; set; }
        public string FeaturesName { get; set; }
    }
   
}
