using System;

namespace AdminApi.Models.App
{
    public class InnerPage
    {
        public int InnerPageId { get; set; }
        public int DigitalCatalogId { get; set; }
        public string InsideImage { get; set; }
        public string DescriptionHeading { get; set; }
        public string Description { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
