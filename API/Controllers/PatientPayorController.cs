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
    /// Controller responsible for managing patientpayor-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientpayor information.
    /// </remarks>
    [Route("api/patientpayor")]
    [Authorize]
    public class PatientPayorController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientPayorController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientpayor to the database</summary>
        /// <param name="model">The patientpayor data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientPayor",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientPayor model)
        {
            _context.PatientPayor.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientpayors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientpayors</returns>
        [HttpGet]
        [UserAuthorize("PatientPayor",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientPayor.IncludeRelated().AsQueryable();
            var result = FilterService<PatientPayor>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientpayor by its primary key</summary>
        /// <param name="entityId">The primary key of the patientpayor</param>
        /// <returns>The patientpayor data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientPayor",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientPayor.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientpayor by its primary key</summary>
        /// <param name="entityId">The primary key of the patientpayor</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientPayor",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientPayor.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientPayor.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientpayor by its primary key</summary>
        /// <param name="entityId">The primary key of the patientpayor</param>
        /// <param name="updatedEntity">The patientpayor data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientPayor",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientPayor updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientPayor.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}