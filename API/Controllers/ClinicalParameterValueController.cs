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
    /// Controller responsible for managing clinicalparametervalue-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting clinicalparametervalue information.
    /// </remarks>
    [Route("api/clinicalparametervalue")]
    [Authorize]
    public class ClinicalParameterValueController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ClinicalParameterValueController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new clinicalparametervalue to the database</summary>
        /// <param name="model">The clinicalparametervalue data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ClinicalParameterValue",Entitlements.Create)]
        public IActionResult Post([FromBody] ClinicalParameterValue model)
        {
            _context.ClinicalParameterValue.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of clinicalparametervalues based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of clinicalparametervalues</returns>
        [HttpGet]
        [UserAuthorize("ClinicalParameterValue",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ClinicalParameterValue.IncludeRelated().AsQueryable();
            var result = FilterService<ClinicalParameterValue>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific clinicalparametervalue by its primary key</summary>
        /// <param name="entityId">The primary key of the clinicalparametervalue</param>
        /// <returns>The clinicalparametervalue data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ClinicalParameterValue",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ClinicalParameterValue.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific clinicalparametervalue by its primary key</summary>
        /// <param name="entityId">The primary key of the clinicalparametervalue</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ClinicalParameterValue",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ClinicalParameterValue.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ClinicalParameterValue.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific clinicalparametervalue by its primary key</summary>
        /// <param name="entityId">The primary key of the clinicalparametervalue</param>
        /// <param name="updatedEntity">The clinicalparametervalue data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ClinicalParameterValue",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ClinicalParameterValue updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ClinicalParameterValue.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}