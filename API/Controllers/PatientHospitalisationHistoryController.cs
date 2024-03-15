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
    /// Controller responsible for managing patienthospitalisationhistory-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patienthospitalisationhistory information.
    /// </remarks>
    [Route("api/patienthospitalisationhistory")]
    [Authorize]
    public class PatientHospitalisationHistoryController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientHospitalisationHistoryController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patienthospitalisationhistory to the database</summary>
        /// <param name="model">The patienthospitalisationhistory data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientHospitalisationHistory",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientHospitalisationHistory model)
        {
            _context.PatientHospitalisationHistory.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patienthospitalisationhistorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patienthospitalisationhistorys</returns>
        [HttpGet]
        [UserAuthorize("PatientHospitalisationHistory",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientHospitalisationHistory.IncludeRelated().AsQueryable();
            var result = FilterService<PatientHospitalisationHistory>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patienthospitalisationhistory by its primary key</summary>
        /// <param name="entityId">The primary key of the patienthospitalisationhistory</param>
        /// <returns>The patienthospitalisationhistory data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientHospitalisationHistory",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientHospitalisationHistory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patienthospitalisationhistory by its primary key</summary>
        /// <param name="entityId">The primary key of the patienthospitalisationhistory</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientHospitalisationHistory",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientHospitalisationHistory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientHospitalisationHistory.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patienthospitalisationhistory by its primary key</summary>
        /// <param name="entityId">The primary key of the patienthospitalisationhistory</param>
        /// <param name="updatedEntity">The patienthospitalisationhistory data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientHospitalisationHistory",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientHospitalisationHistory updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientHospitalisationHistory.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}