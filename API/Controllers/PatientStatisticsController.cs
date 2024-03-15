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
    /// Controller responsible for managing patientstatistics-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientstatistics information.
    /// </remarks>
    [Route("api/patientstatistics")]
    [Authorize]
    public class PatientStatisticsController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientStatisticsController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientstatistics to the database</summary>
        /// <param name="model">The patientstatistics data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientStatistics",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientStatistics model)
        {
            _context.PatientStatistics.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientstatisticss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientstatisticss</returns>
        [HttpGet]
        [UserAuthorize("PatientStatistics",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientStatistics.IncludeRelated().AsQueryable();
            var result = FilterService<PatientStatistics>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientstatistics by its primary key</summary>
        /// <param name="entityId">The primary key of the patientstatistics</param>
        /// <returns>The patientstatistics data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientStatistics",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientStatistics.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientstatistics by its primary key</summary>
        /// <param name="entityId">The primary key of the patientstatistics</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientStatistics",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientStatistics.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientStatistics.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientstatistics by its primary key</summary>
        /// <param name="entityId">The primary key of the patientstatistics</param>
        /// <param name="updatedEntity">The patientstatistics data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientStatistics",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientStatistics updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientStatistics.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}