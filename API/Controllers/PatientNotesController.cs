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
    /// Controller responsible for managing patientnotes-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientnotes information.
    /// </remarks>
    [Route("api/patientnotes")]
    [Authorize]
    public class PatientNotesController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientNotesController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientnotes to the database</summary>
        /// <param name="model">The patientnotes data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientNotes",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientNotes model)
        {
            _context.PatientNotes.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientnotess based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientnotess</returns>
        [HttpGet]
        [UserAuthorize("PatientNotes",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientNotes.IncludeRelated().AsQueryable();
            var result = FilterService<PatientNotes>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientnotes by its primary key</summary>
        /// <param name="entityId">The primary key of the patientnotes</param>
        /// <returns>The patientnotes data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientNotes",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientNotes.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientnotes by its primary key</summary>
        /// <param name="entityId">The primary key of the patientnotes</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientNotes",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientNotes.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientNotes.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientnotes by its primary key</summary>
        /// <param name="entityId">The primary key of the patientnotes</param>
        /// <param name="updatedEntity">The patientnotes data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientNotes",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientNotes updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientNotes.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}