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
    /// Controller responsible for managing visitchiefcomplaintparameter-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visitchiefcomplaintparameter information.
    /// </remarks>
    [Route("api/visitchiefcomplaintparameter")]
    [Authorize]
    public class VisitChiefComplaintParameterController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitChiefComplaintParameterController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitchiefcomplaintparameter to the database</summary>
        /// <param name="model">The visitchiefcomplaintparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitChiefComplaintParameter",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitChiefComplaintParameter model)
        {
            _context.VisitChiefComplaintParameter.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitchiefcomplaintparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitchiefcomplaintparameters</returns>
        [HttpGet]
        [UserAuthorize("VisitChiefComplaintParameter",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitChiefComplaintParameter.IncludeRelated().AsQueryable();
            var result = FilterService<VisitChiefComplaintParameter>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitchiefcomplaintparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitchiefcomplaintparameter</param>
        /// <returns>The visitchiefcomplaintparameter data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("VisitChiefComplaintParameter",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.VisitChiefComplaintParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visitchiefcomplaintparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitchiefcomplaintparameter</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("VisitChiefComplaintParameter",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.VisitChiefComplaintParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.VisitChiefComplaintParameter.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visitchiefcomplaintparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitchiefcomplaintparameter</param>
        /// <param name="updatedEntity">The visitchiefcomplaintparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("VisitChiefComplaintParameter",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitChiefComplaintParameter updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.VisitChiefComplaintParameter.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}