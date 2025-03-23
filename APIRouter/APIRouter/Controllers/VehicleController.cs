using APIRouter.DTO;
using APIRouter.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRouter.Controllers
{
    // return Ok(object); → Returns 200 OK with JSON
    // return NotFound(object); → Returns 404 Not Found
    // return CreatedAtAction(); → Returns 201 Created
    // return BadRequest(object); → Returns 400 Bad Request

    [ApiController]
    [Route("api/[controller]")] // Base route: api/Vehicle
    public class VehicleController : Controller
    {
        private readonly BullseyeContext _context; // Injected DbContext

        public VehicleController(BullseyeContext context)
        {
            _context = context;
        }

        // GET: VehicleController
        [HttpGet] // GET all request
        public ActionResult Index()
        {
            try // Try to get all vehicles
            {
                var vehicles = _context.Vehicles.ToList(); // List of all vehicles from db

                vehicles = vehicles.OrderBy(v => v.MaxWeight).ToList();

                List<VehicleDTO> vehicleDTO = new List<VehicleDTO>(); // List of vehicleDTO to return

                // Add each active vehicle
                foreach (var vehicle in vehicles) {
                    if (vehicle.Active == 1)
                    {
                        VehicleDTO newDTO = new VehicleDTO()
                        {
                            VehicleType = vehicle.VehicleType,
                            MaxWeight = vehicle.MaxWeight,
                            Notes = vehicle.Notes,
                            Active = vehicle.Active
                        };
                        vehicleDTO.Add(newDTO); // Add newDTO to list
                    }
                }

                return Ok(vehicleDTO); // Return 200 OK with JSON
            }
            catch (Exception e) // Catch any exceptions
            {
                return BadRequest(e); // Return 400 Bad Request with exception
            }
        }
    }
}
