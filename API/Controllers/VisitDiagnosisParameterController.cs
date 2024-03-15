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
    /// Controller responsible for managing visitdiagnosisparameter-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visitdiagnosisparameter information.
    /// </remarks>
    [Route("api/visitdiagnosisparameter")]
    [Authorize]
    public class VisitDiagnosisParameterController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitDiagnosisParameterController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitdiagnosisparameter to the database</summary>
        /// <param name="model">The visitdiagnosisparameter data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitDiagnosisParameter",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitDiagnosisParameter model)
        {
            _context.VisitDiagnosisParameter.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitdiagnosisparameters based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitdiagnosisparameters</returns>
        [HttpGet]
        [UserAuthorize("VisitDiagnosisParameter",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitDiagnosisParameter.IncludeRelated().AsQueryable();
            var result = FilterService<VisitDiagnosisParameter>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitdiagnosisparameter</param>
        /// <returns>The visitdiagnosisparameter data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("VisitDiagnosisParameter",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.VisitDiagnosisParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitdiagnosisparameter</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("VisitDiagnosisParameter",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.VisitDiagnosisParameter.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.VisitDiagnosisParameter.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visitdiagnosisparameter by its primary key</summary>
        /// <param name="entityId">The primary key of the visitdiagnosisparameter</param>
        /// <param name="updatedEntity">The visitdiagnosisparameter data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("VisitDiagnosisParameter",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitDiagnosisParameter updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.VisitDiagnosisParameter.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}