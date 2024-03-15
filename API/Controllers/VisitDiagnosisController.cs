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
    /// Controller responsible for managing visitdiagnosis-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visitdiagnosis information.
    /// </remarks>
    [Route("api/visitdiagnosis")]
    [Authorize]
    public class VisitDiagnosisController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitDiagnosisController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitdiagnosis to the database</summary>
        /// <param name="model">The visitdiagnosis data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitDiagnosis",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitDiagnosis model)
        {
            _context.VisitDiagnosis.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitdiagnosiss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitdiagnosiss</returns>
        [HttpGet]
        [UserAuthorize("VisitDiagnosis",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitDiagnosis.IncludeRelated().AsQueryable();
            var result = FilterService<VisitDiagnosis>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitdiagnosis by its primary key</summary>
        /// <param name="entityId">The primary key of the visitdiagnosis</param>
        /// <returns>The visitdiagnosis data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("VisitDiagnosis",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.VisitDiagnosis.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visitdiagnosis by its primary key</summary>
        /// <param name="entityId">The primary key of the visitdiagnosis</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("VisitDiagnosis",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.VisitDiagnosis.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.VisitDiagnosis.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visitdiagnosis by its primary key</summary>
        /// <param name="entityId">The primary key of the visitdiagnosis</param>
        /// <param name="updatedEntity">The visitdiagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("VisitDiagnosis",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitDiagnosis updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.VisitDiagnosis.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}