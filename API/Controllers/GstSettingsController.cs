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
    /// Controller responsible for managing gstsettings-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting gstsettings information.
    /// </remarks>
    [Route("api/gstsettings")]
    [Authorize]
    public class GstSettingsController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public GstSettingsController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new gstsettings to the database</summary>
        /// <param name="model">The gstsettings data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("GstSettings",Entitlements.Create)]
        public IActionResult Post([FromBody] GstSettings model)
        {
            _context.GstSettings.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of gstsettingss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of gstsettingss</returns>
        [HttpGet]
        [UserAuthorize("GstSettings",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.GstSettings.IncludeRelated().AsQueryable();
            var result = FilterService<GstSettings>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific gstsettings by its primary key</summary>
        /// <param name="entityId">The primary key of the gstsettings</param>
        /// <returns>The gstsettings data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("GstSettings",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.GstSettings.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific gstsettings by its primary key</summary>
        /// <param name="entityId">The primary key of the gstsettings</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("GstSettings",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.GstSettings.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.GstSettings.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific gstsettings by its primary key</summary>
        /// <param name="entityId">The primary key of the gstsettings</param>
        /// <param name="updatedEntity">The gstsettings data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("GstSettings",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] GstSettings updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.GstSettings.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}