using APIRouter.DTO;
using Microsoft.AspNetCore.Mvc;
using APIRouter.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json; // Add this for async queries

namespace APIRouter.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Base route: api/Delivery
    public class DeliveryController : ControllerBase // Use ControllerBase for API controllers
    {
        private readonly BullseyeContext _context; // Injected DbContext
        private readonly ILogger<DeliveryController> _logger;

        public DeliveryController(BullseyeContext context, ILogger<DeliveryController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST: api/Delivery 
        [HttpPost]
        public async Task<ActionResult> CreateDelivery([FromBody] DeliveryDTO delivery)
        {

            _logger.LogInformation("Received CreateDelivery request with payload: {Payload}",
        JsonSerializer.Serialize(delivery, new JsonSerializerOptions { WriteIndented = true }));

            if (delivery == null)
            {
                return BadRequest(new { message = "Invalid data provided" }); // Status 400
            }

            try
            {

                // Get the vehicle from context
                var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.VehicleType == delivery.VehicleType);

                // Get distance from WH for each locations in delivery (not super accurate because its to and from the WH and not from store to store)
                int distance = 0;
                foreach (var txn in delivery.TxnIDs)
                {
                    Txn txn1 = await _context.Txns.Include(t=>t.SiteIdtoNavigation).FirstOrDefaultAsync(t => t.TxnId == txn) ?? new Txn();
                    if (txn1.TxnId == 0)
                    {
                        return BadRequest(new { message = "TXN not found in DB in distance loop" });
                    }
                    else
                        distance += txn1.SiteIdtoNavigation.DistanceFromWh * 2; // There and back
                }

                decimal deliveryCost = distance * vehicle.CostPerKm; // DISTANCE COST

                double hours = Math.Round((double)distance / 100, 0); // 100km/h speed rounded up

                hours = hours > 2 ? hours : 2; // Minimum 2 hours

                deliveryCost += ((decimal)hours * vehicle.HourlyTruckCost) + ((decimal)hours * 35); // TRUCK HOURLY + DRIVER COST

                var newDelivery = new Delivery
                {
                    DeliveryDate = DateTime.UtcNow,
                    DistanceCost = deliveryCost,
                    VehicleType = delivery.VehicleType,
                    Notes = delivery.Notes
                };

                _context.Deliveries.Add(newDelivery);

                await _context.SaveChangesAsync();

                foreach (var txn in delivery.TxnIDs)
                {
                    Txn updatedTxn = await _context.Txns.FirstOrDefaultAsync(t => t.TxnId == txn) ?? new Txn();

                    if (updatedTxn.TxnId == 0)
                    {
                        return BadRequest(new { message = "Transaction not found" });
                    }

                    updatedTxn.DeliveryId = newDelivery.DeliveryId; // Assign the delivery ID

                    await _context.SaveChangesAsync();
                }


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

        // GET: api/Delivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetAllDeliveries()
        {
            try
            {
                var deliveries = await _context.Deliveries.ToListAsync();

                // Sort deliveries by soonest first
                deliveries = deliveries.OrderBy(d => d.DeliveryDate).ToList();

                // Create deliveryDTO for each delivery 
                List<DeliveryDTO> deliveryDTO = new List<DeliveryDTO>();
                foreach (var delivery in deliveries)
                {
                    DeliveryDTO newDTO = new DeliveryDTO()
                    {
                        DeliveryId = delivery.DeliveryId,
                        EmergencyOrder = delivery.VehicleType == "Courier",
                        DeliveryDate = delivery.DeliveryDate.ToString(),
                        Notes = delivery.Notes,
                        VehicleType = delivery.VehicleType,
                        TotalWeight = 0,                    // N/A
                        TxnIDs = new List<int>()            // N/A
                    };
                    deliveryDTO.Add(newDTO);
                }
                return Ok(deliveryDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
