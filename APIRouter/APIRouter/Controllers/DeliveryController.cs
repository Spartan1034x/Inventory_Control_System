using APIRouter.DTO;
using Microsoft.AspNetCore.Mvc;
using APIRouter.Models;
using Microsoft.EntityFrameworkCore; // Add this for async queries

namespace APIRouter.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Base route: api/Delivery
    public class DeliveryController : ControllerBase // Use ControllerBase for API controllers
    {
        private readonly BullseyeContext _context; // Injected DbContext

        public DeliveryController(BullseyeContext context)
        {
            _context = context;
        }

        // POST: api/Delivery
        [HttpPost]
        public async Task<ActionResult> CreateTransaction([FromBody] DeliveryDTO delivery)
        {
            if (delivery == null || delivery.DeliveryDate == DateTime.MinValue)
            {
                return BadRequest(new { message = "Invalid data provided" }); // Status 400
            }

            try
            {
                // Get the smallest vehicle that can carry the weight
                var smallestVehicle = await _context.Vehicles
                    .Where(v => v.MaxWeight >= delivery.TotalWeight)
                    .Where(v=> delivery.EmergencyOrder == 1 || v.VehicleType != "Courier") // Courier only for emerg
                    .OrderBy(v => v.MaxWeight)
                    .FirstOrDefaultAsync();

                if (smallestVehicle == null)
                {
                    return BadRequest(new { message = "No available vehicle can handle this weight" });
                }

                // Get the distance to the store
                var site = await _context.Sites
                    .Where(s => s.SiteId == delivery.SiteIDTo)
                    .Select(s => s.DistanceFromWh)
                    .FirstOrDefaultAsync();

                if (site == 0)
                {
                    return BadRequest(new { message = "Invalid store location" });
                }

                decimal deliveryCost = site * smallestVehicle.CostPerKm;

                var newDelivery = new Delivery
                {
                    DeliveryDate = DateTime.UtcNow,
                    DistanceCost = deliveryCost,
                    VehicleType = smallestVehicle.VehicleType,
                    Notes = delivery.Notes
                };

                _context.Deliveries.Add(newDelivery);

                await _context.SaveChangesAsync();

                // Add DeliveryID to txn
                Txn txn = await _context.Txns.FirstOrDefaultAsync(t => t.TxnId == delivery.TxnID);

                if (txn == null)
                {
                    return BadRequest(new { message = "Transaction not found" });
                }

                txn.DeliveryId = newDelivery.DeliveryId; // Assign the delivery ID

                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDeliveryById), new { id = newDelivery.DeliveryId }, newDelivery);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating delivery: {ex}");

                return StatusCode(500, new
                {
                    message = "Database error occurred",
                    details = ex.Message
                });
            }
        }

        // GET: api/Delivery/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDeliveryById(int id)
        {
            var delivery = await _context.Deliveries.FindAsync(id);

            if (delivery == null)
            {
                return NotFound(new { message = "Delivery not found" });
            }

            return Ok(delivery);
        }
    }
}
