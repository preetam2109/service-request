using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServiceRequestManager.Data;
using ServiceRequestManager.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServiceRequestManager.Controllers
{
    [Authorize] // All endpoints in this controller require authentication
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ServiceRequestsController> _logger; // For logging

        public ServiceRequestsController(ApplicationDbContext context, ILogger<ServiceRequestsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/ServiceRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequest>>> GetServiceRequests([FromQuery] string? statusFilter = null)
        {
            _logger.LogInformation("Fetching all service requests.");
            try
            {
                var requests = await _context.ServiceRequests.ToListAsync();

                if (!string.IsNullOrEmpty(statusFilter))
                {
                    requests = requests.Where(r => r.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase)).ToList();
                    _logger.LogInformation($"Filtered service requests by status: {statusFilter}");
                }

                return Ok(requests);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching service requests.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // GET: api/ServiceRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequest>> GetServiceRequest(int id)
        {
            _logger.LogInformation($"Fetching service request with ID: {id}");
            try
            {
                var serviceRequest = await _context.ServiceRequests.FindAsync(id);

                if (serviceRequest == null)
                {
                    _logger.LogWarning($"Service request with ID {id} not found.");
                    return NotFound();
                }

                return Ok(serviceRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching service request with ID: {id}.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT: api/ServiceRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceRequest(int id, ServiceRequest serviceRequest)
        {
            _logger.LogInformation($"Attempting to update service request with ID: {id}");
            if (id != serviceRequest.Id)
            {
                _logger.LogWarning($"Mismatched ID in PUT request. Route ID: {id}, Request Body ID: {serviceRequest.Id}");
                return BadRequest("ID mismatch");
            }

            // Ensure CreatedDate and CreatedBy are not changed by client for existing requests
            var existingRequest = await _context.ServiceRequests.AsNoTracking().FirstOrDefaultAsync(sr => sr.Id == id);
            if (existingRequest == null)
            {
                _logger.LogWarning($"Service request with ID {id} not found for update.");
                return NotFound();
            }

            serviceRequest.CreatedDate = existingRequest.CreatedDate;
            serviceRequest.CreatedBy = existingRequest.CreatedBy;

            _context.Entry(serviceRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Service request with ID {id} updated successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ServiceRequestExists(id))
                {
                    _logger.LogWarning($"Service request with ID {id} not found during update concurrency check.");
                    return NotFound();
                }
                else
                {
                    _logger.LogError(ex, $"Concurrency error updating service request with ID: {id}.");
                    throw; // Re-throw if it's a genuine concurrency issue
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating service request with ID: {id}.");
                return StatusCode(500, "Internal server error.");
            }

            return NoContent(); // 204 No Content for successful update
        }

        // POST: api/ServiceRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceRequest>> PostServiceRequest(ServiceRequest serviceRequest)
        {
            _logger.LogInformation($"Attempting to create new service request with title: {serviceRequest.Title}");
            try
            {
                // Set CreatedDate and ensure Status is valid upon creation
                serviceRequest.CreatedDate = DateTime.UtcNow;
                if (string.IsNullOrEmpty(serviceRequest.Status))
                {
                    serviceRequest.Status = "Open"; // Default status
                }

                _context.ServiceRequests.Add(serviceRequest);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Service request '{serviceRequest.Title}' created successfully with ID: {serviceRequest.Id}");

                return CreatedAtAction("GetServiceRequest", new { id = serviceRequest.Id }, serviceRequest);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error creating service request with title: {serviceRequest.Title}.");
                return StatusCode(500, "Internal server error.");
            }
        }

        // DELETE: api/ServiceRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceRequest(int id)
        {
            _logger.LogInformation($"Attempting to delete service request with ID: {id}");
            try
            {
                var serviceRequest = await _context.ServiceRequests.FindAsync(id);
                if (serviceRequest == null)
                {
                    _logger.LogWarning($"Service request with ID {id} not found for deletion.");
                    return NotFound();
                }

                _context.ServiceRequests.Remove(serviceRequest);
                await _context.SaveChangesAsync();
                _logger.LogInformation($"Service request with ID {id} deleted successfully.");

                return NoContent(); // 204 No Content for successful deletion
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting service request with ID: {id}.");
                return StatusCode(500, "Internal server error.");
            }
        }

        private bool ServiceRequestExists(int id)
        {
            return _context.ServiceRequests.Any(e => e.Id == id);
        }
    }
}

