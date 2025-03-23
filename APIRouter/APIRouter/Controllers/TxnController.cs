using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using APIRouter.Models;
using APIRouter.DTO;
using Microsoft.EntityFrameworkCore;

namespace APIRouter.Controllers
{
    // return Ok(object); → Returns 200 OK with JSON
    // return NotFound(object); → Returns 404 Not Found
    // return CreatedAtAction(); → Returns 201 Created
    // return BadRequest(object); → Returns 400 Bad Request

    [ApiController]
    [Route("api/[controller]")] // Base route: api/Txn
    public class TxnController : ControllerBase // Use ControllerBase for API controllers
    {
        private readonly BullseyeContext _context; // Injected DbContext

        public TxnController(BullseyeContext context)
        {
            _context = context;
        }

        // GET: api/Txn
        // GET ALL
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TxnDTO>>> GetAllTransactions()
        {
            try
            {
                var txn = await _context.Txns.Include(t=>t.SiteIdtoNavigation)
                    .Include(t => t.Txnitems)
                    .ThenInclude(t => t.Item)
                    .ToListAsync(); // List of all orders with txnitems and items tables

                // Sort by ASSEMBLED then by soonest date to ship
                txn = txn.OrderBy(t=>t.TxnStatus!="ASSEMBLED").ThenByDescending(t=>t.EmergencyDelivery).ThenBy(t => t.ShipDate).ToList();

                List<TxnDTO> txnDTO = new List<TxnDTO>(); // List of txnDTO to return

                // Foreach order in txns create a DTO
                foreach (var order in txn)
                {
                    TxnDTO newDTO = new TxnDTO()
                    {
                        TxnId = order.TxnId,
                        SiteTo = order.SiteIdtoNavigation.SiteName,
                        TxnStatus = order.TxnStatus,
                        ShipDate = order.ShipDate,
                        BarCode = order.BarCode,
                        DeliveryId = null,
                        EmergencyDelivery = order.EmergencyDelivery == 1 ? true : false,
                        TxnType = order.TxnType,
                        Notes = order.Notes
                    };

                    decimal weight = 0;
                    int itemQuantity = 0;

                    // Calculate Total Weight and total items
                    List<Txnitem> txnItems = (List<Txnitem>)order.Txnitems;
                    foreach (var item in txnItems)
                    {
                        itemQuantity += item.Quantity; // Add quantity to total
                        weight += (item.Quantity / item.Item.CaseSize) * item.Item.Weight; // Calculate weight of items and add to total weight
                    }

                    newDTO.TotalWeight = weight;
                    newDTO.TotalItems = itemQuantity;

                    txnDTO.Add(newDTO);
                } // End creating DTO

                if (!txnDTO.Any())
                    return NotFound(new { message = "No Txns Found" });

                return Ok(txnDTO); // Return txnDTO list
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching transactions: {ex.Message + ex.InnerException}");

                return StatusCode(500, new { message = "DB Error", details = ex.Message + ex.InnerException });
            }
        }


        // GET: api/Txn/id
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTransactionById(int id)
        {
            var txn = await _context.Txns.FindAsync(id);

            if (txn == null)
                return NotFound(new { message = $"Transaction with ID {id} not found" });

            return Ok(txn);
        }


        // POST: api/Txn
        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] NewTxnDTO txn)
        {
            if (txn == null || txn.Items == null)
                return BadRequest(new { message = "Invalid data provided (Null)" });

            try
            {
                // Create new txn
                Txn newTxn = new Txn()
                {
                    EmployeeId = 10000, // Emp id for online
                    SiteIdfrom = txn.SiteIdTo,
                    SiteIdto = txn.SiteIdTo,
                    ShipDate = DateTime.Now,
                    TxnStatus = "SUBMITTED",
                    TxnType = "Online",
                    BarCode = "N/A",
                    EmergencyDelivery = 0,
                    Notes = txn.Notes
                };

                _context.Txns.Add(newTxn);

                await _context.SaveChangesAsync();

                List<Txnitem> txnItems = new List<Txnitem>();

                // Create txnItems
                foreach (var item in txn.Items)
                {
                    txnItems.Add(new Txnitem()
                    {
                        TxnId = newTxn.TxnId,
                        ItemId = item.ItemId,
                        Quantity = item.Quantity
                    });
                }

                _context.Txnitems.AddRange(txnItems);

                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTransactionById", new { id = newTxn.TxnId, itemsAdded = txnItems.Count }, txn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating transaction: {ex.Message + ex.InnerException}");
                return StatusCode(500, new { message = "DB Error", details = ex.Message + ex.InnerException });
            }
        }
    }
}
