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
    /// Controller responsible for managing patientlifestyle-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientlifestyle information.
    /// </remarks>
    [Route("api/patientlifestyle")]
    [Authorize]
    public class PatientLifeStyleController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientLifeStyleController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientlifestyle to the database</summary>
        /// <param name="model">The patientlifestyle data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientLifeStyle",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientLifeStyle model)
        {
            _context.PatientLifeStyle.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientlifestyles based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientlifestyles</returns>
        [HttpGet]
        [UserAuthorize("PatientLifeStyle",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientLifeStyle.IncludeRelated().AsQueryable();
            var result = FilterService<PatientLifeStyle>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientlifestyle by its primary key</summary>
        /// <param name="entityId">The primary key of the patientlifestyle</param>
        /// <returns>The patientlifestyle data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientLifeStyle",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientLifeStyle.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientlifestyle by its primary key</summary>
        /// <param name="entityId">The primary key of the patientlifestyle</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientLifeStyle",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientLifeStyle.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientLifeStyle.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientlifestyle by its primary key</summary>
        /// <param name="entityId">The primary key of the patientlifestyle</param>
        /// <param name="updatedEntity">The patientlifestyle data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientLifeStyle",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientLifeStyle updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientLifeStyle.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}