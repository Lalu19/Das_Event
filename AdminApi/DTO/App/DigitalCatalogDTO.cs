using System;
using System.Collections.Generic;

namespace AdminApi.DTO.App
{
    public class DigitalCatalogDTO
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public List<InnerPageDTO> innerPageDTOs { get; set; }

    }
    public class UpdateDigitalCatalogDTO
    {
        public int DigitalCatalogId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
