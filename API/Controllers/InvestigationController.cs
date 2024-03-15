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
    /// Controller responsible for managing investigation-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting investigation information.
    /// </remarks>
    [Route("api/investigation")]
    [Authorize]
    public class InvestigationController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public InvestigationController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new investigation to the database</summary>
        /// <param name="model">The investigation data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Investigation",Entitlements.Create)]
        public IActionResult Post([FromBody] Investigation model)
        {
            _context.Investigation.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of investigations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of investigations</returns>
        [HttpGet]
        [UserAuthorize("Investigation",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Investigation.IncludeRelated().AsQueryable();
            var result = FilterService<Investigation>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific investigation by its primary key</summary>
        /// <param name="entityId">The primary key of the investigation</param>
        /// <returns>The investigation data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Investigation",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Investigation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific investigation by its primary key</summary>
        /// <param name="entityId">The primary key of the investigation</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Investigation",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Investigation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Investigation.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific investigation by its primary key</summary>
        /// <param name="entityId">The primary key of the investigation</param>
        /// <param name="updatedEntity">The investigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Investigation",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Investigation updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Investigation.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}