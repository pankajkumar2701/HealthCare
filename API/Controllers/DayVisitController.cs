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
    /// Controller responsible for managing dayvisit-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting dayvisit information.
    /// </remarks>
    [Route("api/dayvisit")]
    [Authorize]
    public class DayVisitController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public DayVisitController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new dayvisit to the database</summary>
        /// <param name="model">The dayvisit data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("DayVisit",Entitlements.Create)]
        public IActionResult Post([FromBody] DayVisit model)
        {
            _context.DayVisit.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of dayvisits based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of dayvisits</returns>
        [HttpGet]
        [UserAuthorize("DayVisit",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.DayVisit.IncludeRelated().AsQueryable();
            var result = FilterService<DayVisit>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific dayvisit by its primary key</summary>
        /// <param name="entityId">The primary key of the dayvisit</param>
        /// <returns>The dayvisit data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("DayVisit",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.DayVisit.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific dayvisit by its primary key</summary>
        /// <param name="entityId">The primary key of the dayvisit</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("DayVisit",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.DayVisit.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.DayVisit.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific dayvisit by its primary key</summary>
        /// <param name="entityId">The primary key of the dayvisit</param>
        /// <param name="updatedEntity">The dayvisit data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("DayVisit",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] DayVisit updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.DayVisit.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}