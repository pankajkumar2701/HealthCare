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
    /// Controller responsible for managing visitvitaltemplateparameter-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visitvitaltemplateparameter information.
    /// </remarks>
    [Route("api/visitvitaltemplateparameter")]
    [Authorize]
    public class VisitVitalTemplateParameterController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitVitalTemplateParameterController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitvitaltemplateparameter to the database</summary>
        /// <param name="model">The visitvitaltemplateparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitVitalTemplateParameter",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitVitalTemplateParameter model)
        {
            _context.VisitVitalTemplateParameter.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitvitaltemplateparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitvitaltemplateparameters</returns>
        [HttpGet]
        [UserAuthorize("VisitVitalTemplateParameter",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitVitalTemplateParameter.IncludeRelated().AsQueryable();
            var result = FilterService<VisitVitalTemplateParameter>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitvitaltemplateparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitvitaltemplateparameter</param>
        /// <returns>The visitvitaltemplateparameter data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("VisitVitalTemplateParameter",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.VisitVitalTemplateParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visitvitaltemplateparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitvitaltemplateparameter</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("VisitVitalTemplateParameter",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.VisitVitalTemplateParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.VisitVitalTemplateParameter.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visitvitaltemplateparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitvitaltemplateparameter</param>
        /// <param name="updatedEntity">The visitvitaltemplateparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("VisitVitalTemplateParameter",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitVitalTemplateParameter updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.VisitVitalTemplateParameter.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}