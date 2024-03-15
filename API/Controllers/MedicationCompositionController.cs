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
    /// Controller responsible for managing medicationcomposition-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting medicationcomposition information.
    /// </remarks>
    [Route("api/medicationcomposition")]
    [Authorize]
    public class MedicationCompositionController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public MedicationCompositionController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new medicationcomposition to the database</summary>
        /// <param name="model">The medicationcomposition data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("MedicationComposition",Entitlements.Create)]
        public IActionResult Post([FromBody] MedicationComposition model)
        {
            _context.MedicationComposition.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of medicationcompositions based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of medicationcompositions</returns>
        [HttpGet]
        [UserAuthorize("MedicationComposition",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.MedicationComposition.IncludeRelated().AsQueryable();
            var result = FilterService<MedicationComposition>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific medicationcomposition by its primary key</summary>
        /// <param name="entityId">The primary key of the medicationcomposition</param>
        /// <returns>The medicationcomposition data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("MedicationComposition",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.MedicationComposition.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific medicationcomposition by its primary key</summary>
        /// <param name="entityId">The primary key of the medicationcomposition</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("MedicationComposition",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.MedicationComposition.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.MedicationComposition.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific medicationcomposition by its primary key</summary>
        /// <param name="entityId">The primary key of the medicationcomposition</param>
        /// <param name="updatedEntity">The medicationcomposition data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("MedicationComposition",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] MedicationComposition updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.MedicationComposition.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}