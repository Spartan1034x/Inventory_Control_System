using APIRouter.DTO;
using Microsoft.AspNetCore.Mvc;
using APIRouter.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json; // Add this for async queries

namespace APIRouter.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Base route: api/Site
    public class SiteController : ControllerBase // Use ControllerBase for API controllers
    {

        private readonly BullseyeContext _context; // Injected DbContext

        public SiteController(BullseyeContext context)
        {
            _context = context;
        }

        // GET: api/Site
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetAllSites()
        {
            try
            {
                var sites = await _context.Sites.Where(s=>s.SiteName.Contains("Retail")).ToListAsync();
                
                List<SiteDTO> siteDTO = new List<SiteDTO>();

                foreach (var site in sites) {
                    SiteDTO newDTO = new SiteDTO()
                    {
                        ID = site.SiteId,
                        Name = site.SiteName,
                        Address = site.Address,
                        City = site.City,
                        Phone = site.Phone
                    };
                    siteDTO.Add(newDTO);
                }

                return Ok(siteDTO);

            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
