using Microsoft.AspNetCore.Mvc;
using AdminApi;
using AdminApi.Models;
using AdminApi.Models.App;
using AdminApi.DTO;
using AdminApi.DTO.App;
using AdminApi.Models.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class DigitalCatalogController : Controller
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _context;
        private readonly ISqlRepository<DigitalCatalog> _digitalCatalogRepo;
        private readonly ISqlRepository<InnerPage> _innerPageRepo;

        public DigitalCatalogController(IConfiguration config,
                                AppDbContext context,
                                ISqlRepository<DigitalCatalog> digitalCatalogRepo,
                                ISqlRepository<InnerPage> innerPageRepo)
        {
            _config = config;
            _context = context;
            _digitalCatalogRepo = digitalCatalogRepo;
            _innerPageRepo = innerPageRepo;
        }
    
        [HttpPost]
        public IActionResult DigitalCatalogCreate(DigitalCatalogDTO digitalCatalogDTO)
        {
            var objCheck = _context.DigitalCatalogs.SingleOrDefault(opt => opt.Name == digitalCatalogDTO.Name && opt.IsDeleted == false);
            try
            {
                if (objCheck == null)
                {
                    DigitalCatalog digitalCatalog = new DigitalCatalog();
                    digitalCatalog.Name = digitalCatalogDTO.Name;
                    digitalCatalog.Image = digitalCatalogDTO.Image;
                    digitalCatalog.CreatedBy = digitalCatalogDTO.CreatedBy;
                    var obj = _digitalCatalogRepo.Insert(digitalCatalog);
                    for (int i = 0; i < digitalCatalogDTO.innerPageDTOs.Count; i++)
                    {
                        InnerPage innerPage = new InnerPage();
                        innerPage.DigitalCatalogId = obj.DigitalCatalogId;
                        innerPage.InsideImage = digitalCatalogDTO.innerPageDTOs[i].InsideImage;
                        innerPage.DescriptionHeading = digitalCatalogDTO.innerPageDTOs[i].DescriptionHeading;
                        innerPage.Description = digitalCatalogDTO.innerPageDTOs[i].Description;
                        innerPage.CreatedBy = digitalCatalogDTO.CreatedBy;
                        var detailsfilterTableobj = _innerPageRepo.Insert(innerPage);
                    }
                    return Ok(obj);

                }
                else if (objCheck != null)
                {
                    return Accepted(new Confirmation { Status = "duplicate", ResponseMsg = "Duplicate name !" });
                }
                return Accepted(new Confirmation { Status = "error", ResponseMsg = "Something unexpected!" });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }

        }
        [HttpGet]
        public ActionResult GetDigitalCatalogList()
        {
            try
            {
                var list = (from u in _context.DigitalCatalogs
                            join a in _context.InnerPages on u.DigitalCatalogId equals a.DigitalCatalogId
                            select new
                            {
                                u.DigitalCatalogId,
                                u.Name,
                                u.Image,
                                a.InsideImage,
                                a.DescriptionHeading,
                                a.Description,
                                u.IsDeleted
                            }).Where(x => x.IsDeleted == false);
                int totalRecords = list.Count();
                return Ok(new { data = list, recordsTotal = totalRecords, recordsFiltered = totalRecords });
            }
            catch (Exception ex)
            {
                return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
            }
        }
        //[HttpGet("{DigitalCatalogId}")]
        //public ActionResult GetSingleDigitalCatalogId(int DigitalCatalogId)
        //{
        //    try
        //    {
        //        var singledigitalCatalog = _digitalCatalogRepo.SelectById(DigitalCatalogId);

        //        return Ok(singledigitalCatalog);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}
        //[HttpPost]
        //public ActionResult UpdateDigitalCatalog(UpdateDigitalCatalogDTO updateDigitalCatalogDTO)
        //{
        //    try
        //    {
        //        var digitalCatalog = _context.DigitalCatalogs.SingleOrDefault(opt => opt.DigitalCatalogId == updateDigitalCatalogDTO.DigitalCatalogId);
        //        digitalCatalog.Name = updateDigitalCatalogDTO.Name;
        //        digitalCatalog.Image = updateDigitalCatalogDTO.Image;
        //        digitalCatalog.DescriptionHeading = updateDigitalCatalogDTO.DescriptionHeading;
        //        digitalCatalog.Description = updateDigitalCatalogDTO.Description;
        //        digitalCatalog.UpdatedBy = updateDigitalCatalogDTO.UpdatedBy;
        //        digitalCatalog.UpdatedOn = System.DateTime.Now;


        //        _context.SaveChanges();
        //        return Ok(digitalCatalog);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }
        //}

        //[HttpGet("{digitalCatalogId}/{DeletedBy}")]
        //public ActionResult DeleteDigitalCatalog(int digitalCatalogId, int DeletedBy)
        //{
        //    try
        //    {
        //        var digitalCatalog = _context.DigitalCatalogs.SingleOrDefault(opt => opt.DigitalCatalogId == digitalCatalogId);
        //        digitalCatalog.IsDeleted = true;
        //        digitalCatalog.UpdatedBy = DeletedBy;
        //        digitalCatalog.UpdatedOn = System.DateTime.Now;
        //        _context.SaveChanges();
        //        return Ok(digitalCatalog);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Accepted(new Confirmation { Status = "error", ResponseMsg = ex.Message });
        //    }

        //}

    }
}
