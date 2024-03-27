using System;

namespace AdminApi.Models.App
{
    public class DigitalCatalog
    {
        public int DigitalCatalogId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }


    }
}
