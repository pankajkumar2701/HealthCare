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
    /// Controller responsible for managing patientmedicalhistorynote-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientmedicalhistorynote information.
    /// </remarks>
    [Route("api/patientmedicalhistorynote")]
    [Authorize]
    public class PatientMedicalHistoryNoteController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientMedicalHistoryNoteController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientmedicalhistorynote to the database</summary>
        /// <param name="model">The patientmedicalhistorynote data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientMedicalHistoryNote",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientMedicalHistoryNote model)
        {
            _context.PatientMedicalHistoryNote.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientmedicalhistorynotes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientmedicalhistorynotes</returns>
        [HttpGet]
        [UserAuthorize("PatientMedicalHistoryNote",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientMedicalHistoryNote.IncludeRelated().AsQueryable();
            var result = FilterService<PatientMedicalHistoryNote>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientmedicalhistorynote by its primary key</summary>
        /// <param name="entityId">The primary key of the patientmedicalhistorynote</param>
        /// <returns>The patientmedicalhistorynote data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientMedicalHistoryNote",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientMedicalHistoryNote.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientmedicalhistorynote by its primary key</summary>
        /// <param name="entityId">The primary key of the patientmedicalhistorynote</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientMedicalHistoryNote",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientMedicalHistoryNote.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientMedicalHistoryNote.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientmedicalhistorynote by its primary key</summary>
        /// <param name="entityId">The primary key of the patientmedicalhistorynote</param>
        /// <param name="updatedEntity">The patientmedicalhistorynote data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientMedicalHistoryNote",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientMedicalHistoryNote updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientMedicalHistoryNote.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}