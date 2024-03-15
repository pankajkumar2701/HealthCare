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
    /// Controller responsible for managing diagnosis-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting diagnosis information.
    /// </remarks>
    [Route("api/diagnosis")]
    [Authorize]
    public class DiagnosisController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public DiagnosisController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new diagnosis to the database</summary>
        /// <param name="model">The diagnosis data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Diagnosis",Entitlements.Create)]
        public IActionResult Post([FromBody] Diagnosis model)
        {
            _context.Diagnosis.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of diagnosiss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of diagnosiss</returns>
        [HttpGet]
        [UserAuthorize("Diagnosis",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Diagnosis.IncludeRelated().AsQueryable();
            var result = FilterService<Diagnosis>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific diagnosis by its primary key</summary>
        /// <param name="entityId">The primary key of the diagnosis</param>
        /// <returns>The diagnosis data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Diagnosis",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Diagnosis.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific diagnosis by its primary key</summary>
        /// <param name="entityId">The primary key of the diagnosis</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Diagnosis",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Diagnosis.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Diagnosis.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific diagnosis by its primary key</summary>
        /// <param name="entityId">The primary key of the diagnosis</param>
        /// <param name="updatedEntity">The diagnosis data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Diagnosis",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Diagnosis updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Diagnosis.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}