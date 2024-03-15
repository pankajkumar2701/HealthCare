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
    /// Controller responsible for managing visit-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visit information.
    /// </remarks>
    [Route("api/visit")]
    [Authorize]
    public class VisitController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visit to the database</summary>
        /// <param name="model">The visit data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Visit",Entitlements.Create)]
        public IActionResult Post([FromBody] Visit model)
        {
            _context.Visit.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visits based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visits</returns>
        [HttpGet]
        [UserAuthorize("Visit",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Visit.IncludeRelated().AsQueryable();
            var result = FilterService<Visit>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visit by its primary key</summary>
        /// <param name="entityId">The primary key of the visit</param>
        /// <returns>The visit data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Visit",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Visit.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visit by its primary key</summary>
        /// <param name="entityId">The primary key of the visit</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Visit",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Visit.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Visit.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visit by its primary key</summary>
        /// <param name="entityId">The primary key of the visit</param>
        /// <param name="updatedEntity">The visit data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Visit",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Visit updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Visit.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}