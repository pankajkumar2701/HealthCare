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
    /// Controller responsible for managing appointmentservice-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting appointmentservice information.
    /// </remarks>
    [Route("api/appointmentservice")]
    [Authorize]
    public class AppointmentServiceController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public AppointmentServiceController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new appointmentservice to the database</summary>
        /// <param name="model">The appointmentservice data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("AppointmentService",Entitlements.Create)]
        public IActionResult Post([FromBody] AppointmentService model)
        {
            _context.AppointmentService.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of appointmentservices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of appointmentservices</returns>
        [HttpGet]
        [UserAuthorize("AppointmentService",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.AppointmentService.IncludeRelated().AsQueryable();
            var result = FilterService<AppointmentService>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific appointmentservice by its primary key</summary>
        /// <param name="entityId">The primary key of the appointmentservice</param>
        /// <returns>The appointmentservice data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("AppointmentService",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.AppointmentService.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific appointmentservice by its primary key</summary>
        /// <param name="entityId">The primary key of the appointmentservice</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("AppointmentService",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.AppointmentService.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.AppointmentService.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific appointmentservice by its primary key</summary>
        /// <param name="entityId">The primary key of the appointmentservice</param>
        /// <param name="updatedEntity">The appointmentservice data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("AppointmentService",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] AppointmentService updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.AppointmentService.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}