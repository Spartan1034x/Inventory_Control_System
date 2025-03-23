using APIRouter.DTO;
using Microsoft.AspNetCore.Mvc;
using APIRouter.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json; // Add this for async queries

namespace APIRouter.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Base route: api/Inventory
    public class InventoryController : ControllerBase // Use ControllerBase for API controllers
    {

        private readonly BullseyeContext _context; // Injected DbContext

        public InventoryController(BullseyeContext context)
        {
            _context = context;
        }

        // GET: api/Inventory/{siteID}
        [HttpGet("{siteID}")]
        public async Task<ActionResult<IEnumerable<Inventory>>> GetSiteInventory(int siteID)
        {
            try
            {
                // Get inventory and item for matching siteID , for active items, and quantities over 0
                var Inventorys = await _context.Inventories.Include(i=>i.Item).Where(i => i.SiteId == siteID && i.Item.Active == 1).ToListAsync();

                List<InventoryDTO> InventoryDTO = new List<InventoryDTO>();

                foreach (var i in Inventorys)
                {
                    // Change imageloc in real time
                    InventoryDTO newDTO = new InventoryDTO()
                    {
                        ItemID = i.ItemId,
                        SiteID = i.SiteId,
                        Name = i.Item.Name,
                        Description = i.Item.Description,
                        Quantity = i.Quantity,
                        Price = i.Item.RetailPrice,
                        Category = i.Item.Category,
                        SKU = i.Item.Sku,
                        ImageLocation = ""
                    };
                    InventoryDTO.Add(newDTO);
                }

                return Ok(InventoryDTO);

            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
