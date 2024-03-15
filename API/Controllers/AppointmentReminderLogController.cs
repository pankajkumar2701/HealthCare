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
    /// Controller responsible for managing appointmentreminderlog-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting appointmentreminderlog information.
    /// </remarks>
    [Route("api/appointmentreminderlog")]
    [Authorize]
    public class AppointmentReminderLogController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public AppointmentReminderLogController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new appointmentreminderlog to the database</summary>
        /// <param name="model">The appointmentreminderlog data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("AppointmentReminderLog",Entitlements.Create)]
        public IActionResult Post([FromBody] AppointmentReminderLog model)
        {
            _context.AppointmentReminderLog.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of appointmentreminderlogs based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of appointmentreminderlogs</returns>
        [HttpGet]
        [UserAuthorize("AppointmentReminderLog",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.AppointmentReminderLog.IncludeRelated().AsQueryable();
            var result = FilterService<AppointmentReminderLog>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific appointmentreminderlog by its primary key</summary>
        /// <param name="entityId">The primary key of the appointmentreminderlog</param>
        /// <returns>The appointmentreminderlog data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("AppointmentReminderLog",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.AppointmentReminderLog.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific appointmentreminderlog by its primary key</summary>
        /// <param name="entityId">The primary key of the appointmentreminderlog</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("AppointmentReminderLog",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.AppointmentReminderLog.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.AppointmentReminderLog.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific appointmentreminderlog by its primary key</summary>
        /// <param name="entityId">The primary key of the appointmentreminderlog</param>
        /// <param name="updatedEntity">The appointmentreminderlog data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("AppointmentReminderLog",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] AppointmentReminderLog updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.AppointmentReminderLog.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}