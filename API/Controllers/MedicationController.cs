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
    /// Controller responsible for managing medication-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting medication information.
    /// </remarks>
    [Route("api/medication")]
    [Authorize]
    public class MedicationController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public MedicationController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new medication to the database</summary>
        /// <param name="model">The medication data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Medication",Entitlements.Create)]
        public IActionResult Post([FromBody] Medication model)
        {
            _context.Medication.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of medications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of medications</returns>
        [HttpGet]
        [UserAuthorize("Medication",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Medication.IncludeRelated().AsQueryable();
            var result = FilterService<Medication>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific medication by its primary key</summary>
        /// <param name="entityId">The primary key of the medication</param>
        /// <returns>The medication data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Medication",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Medication.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific medication by its primary key</summary>
        /// <param name="entityId">The primary key of the medication</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Medication",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Medication.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Medication.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific medication by its primary key</summary>
        /// <param name="entityId">The primary key of the medication</param>
        /// <param name="updatedEntity">The medication data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Medication",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Medication updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Medication.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}