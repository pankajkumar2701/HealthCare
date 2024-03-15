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
    /// Controller responsible for managing clinicalparameter-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting clinicalparameter information.
    /// </remarks>
    [Route("api/clinicalparameter")]
    [Authorize]
    public class ClinicalParameterController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ClinicalParameterController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new clinicalparameter to the database</summary>
        /// <param name="model">The clinicalparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ClinicalParameter",Entitlements.Create)]
        public IActionResult Post([FromBody] ClinicalParameter model)
        {
            _context.ClinicalParameter.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of clinicalparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of clinicalparameters</returns>
        [HttpGet]
        [UserAuthorize("ClinicalParameter",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ClinicalParameter.IncludeRelated().AsQueryable();
            var result = FilterService<ClinicalParameter>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific clinicalparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the clinicalparameter</param>
        /// <returns>The clinicalparameter data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ClinicalParameter",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ClinicalParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific clinicalparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the clinicalparameter</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ClinicalParameter",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ClinicalParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ClinicalParameter.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific clinicalparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the clinicalparameter</param>
        /// <param name="updatedEntity">The clinicalparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ClinicalParameter",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ClinicalParameter updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ClinicalParameter.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}