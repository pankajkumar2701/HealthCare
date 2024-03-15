using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;
using HealthCare.Data;
using HealthCare.Filter;
using HealthCare.Entities;
using HealthCare.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare.Controllers
{
    /// <summary>
    /// Controller responsible for managing appointment-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting appointment information.
    /// </remarks>
    [Route("api/appointment")]
    [Authorize]
    public class AppointmentController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public AppointmentController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new appointment to the database</summary>
        /// <param name="model">The appointment data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Appointment",Entitlements.Create)]
        public IActionResult Post([FromBody] Appointment model)
        {
            _context.Appointment.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of appointments based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of appointments</returns>
        [HttpGet]
        [UserAuthorize("Appointment",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Appointment.IncludeRelated().AsQueryable();
            var result = FilterService<Appointment>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific appointment by its primary key</summary>
        /// <param name="entityId">The primary key of the appointment</param>
        /// <returns>The appointment data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Appointment",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Appointment.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific appointment by its primary key</summary>
        /// <param name="entityId">The primary key of the appointment</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Appointment",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Appointment.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Appointment.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific appointment by its primary key</summary>
        /// <param name="entityId">The primary key of the appointment</param>
        /// <param name="updatedEntity">The appointment data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Appointment",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Appointment updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Appointment.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}