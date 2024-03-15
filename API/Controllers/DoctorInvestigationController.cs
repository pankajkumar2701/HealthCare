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
    /// Controller responsible for managing doctorinvestigation-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting doctorinvestigation information.
    /// </remarks>
    [Route("api/doctorinvestigation")]
    [Authorize]
    public class DoctorInvestigationController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public DoctorInvestigationController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new doctorinvestigation to the database</summary>
        /// <param name="model">The doctorinvestigation data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("DoctorInvestigation",Entitlements.Create)]
        public IActionResult Post([FromBody] DoctorInvestigation model)
        {
            _context.DoctorInvestigation.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of doctorinvestigations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of doctorinvestigations</returns>
        [HttpGet]
        [UserAuthorize("DoctorInvestigation",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.DoctorInvestigation.IncludeRelated().AsQueryable();
            var result = FilterService<DoctorInvestigation>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific doctorinvestigation by its primary key</summary>
        /// <param name="entityId">The primary key of the doctorinvestigation</param>
        /// <returns>The doctorinvestigation data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("DoctorInvestigation",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.DoctorInvestigation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific doctorinvestigation by its primary key</summary>
        /// <param name="entityId">The primary key of the doctorinvestigation</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("DoctorInvestigation",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.DoctorInvestigation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.DoctorInvestigation.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific doctorinvestigation by its primary key</summary>
        /// <param name="entityId">The primary key of the doctorinvestigation</param>
        /// <param name="updatedEntity">The doctorinvestigation data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("DoctorInvestigation",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] DoctorInvestigation updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.DoctorInvestigation.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}