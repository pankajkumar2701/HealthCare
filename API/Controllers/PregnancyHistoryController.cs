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
    /// Controller responsible for managing pregnancyhistory-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting pregnancyhistory information.
    /// </remarks>
    [Route("api/pregnancyhistory")]
    [Authorize]
    public class PregnancyHistoryController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PregnancyHistoryController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new pregnancyhistory to the database</summary>
        /// <param name="model">The pregnancyhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PregnancyHistory",Entitlements.Create)]
        public IActionResult Post([FromBody] PregnancyHistory model)
        {
            _context.PregnancyHistory.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of pregnancyhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of pregnancyhistorys</returns>
        [HttpGet]
        [UserAuthorize("PregnancyHistory",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PregnancyHistory.IncludeRelated().AsQueryable();
            var result = FilterService<PregnancyHistory>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific pregnancyhistory by its primary key</summary>
        /// <param name="entityId">The primary key of the pregnancyhistory</param>
        /// <returns>The pregnancyhistory data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PregnancyHistory",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PregnancyHistory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific pregnancyhistory by its primary key</summary>
        /// <param name="entityId">The primary key of the pregnancyhistory</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PregnancyHistory",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PregnancyHistory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PregnancyHistory.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific pregnancyhistory by its primary key</summary>
        /// <param name="entityId">The primary key of the pregnancyhistory</param>
        /// <param name="updatedEntity">The pregnancyhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PregnancyHistory",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PregnancyHistory updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PregnancyHistory.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}