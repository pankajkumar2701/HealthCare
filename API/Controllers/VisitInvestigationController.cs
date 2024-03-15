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
    /// Controller responsible for managing visitinvestigation-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visitinvestigation information.
    /// </remarks>
    [Route("api/visitinvestigation")]
    [Authorize]
    public class VisitInvestigationController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitInvestigationController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitinvestigation to the database</summary>
        /// <param name="model">The visitinvestigation data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitInvestigation",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitInvestigation model)
        {
            _context.VisitInvestigation.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitinvestigations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitinvestigations</returns>
        [HttpGet]
        [UserAuthorize("VisitInvestigation",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitInvestigation.IncludeRelated().AsQueryable();
            var result = FilterService<VisitInvestigation>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitinvestigation by its primary key</summary>
        /// <param name="entityId">The primary key of the visitinvestigation</param>
        /// <returns>The visitinvestigation data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("VisitInvestigation",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.VisitInvestigation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visitinvestigation by its primary key</summary>
        /// <param name="entityId">The primary key of the visitinvestigation</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("VisitInvestigation",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.VisitInvestigation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.VisitInvestigation.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visitinvestigation by its primary key</summary>
        /// <param name="entityId">The primary key of the visitinvestigation</param>
        /// <param name="updatedEntity">The visitinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("VisitInvestigation",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitInvestigation updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.VisitInvestigation.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}