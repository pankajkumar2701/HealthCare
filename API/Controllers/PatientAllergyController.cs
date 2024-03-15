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
    /// Controller responsible for managing patientallergy-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientallergy information.
    /// </remarks>
    [Route("api/patientallergy")]
    [Authorize]
    public class PatientAllergyController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientAllergyController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientallergy to the database</summary>
        /// <param name="model">The patientallergy data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientAllergy",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientAllergy model)
        {
            _context.PatientAllergy.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientallergys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientallergys</returns>
        [HttpGet]
        [UserAuthorize("PatientAllergy",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientAllergy.IncludeRelated().AsQueryable();
            var result = FilterService<PatientAllergy>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientallergy by its primary key</summary>
        /// <param name="entityId">The primary key of the patientallergy</param>
        /// <returns>The patientallergy data</returns>
        [HttpGet]
        [Route("{id:int}")]
        [UserAuthorize("PatientAllergy",Entitlements.Read)]
        public IActionResult GetById([FromRoute] int id)
        {
            var entityData = _context.PatientAllergy.IncludeRelated().FirstOrDefault(entity => entity.Sequence == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientallergy by its primary key</summary>
        /// <param name="entityId">The primary key of the patientallergy</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientAllergy",Entitlements.Delete)]
        [Route("{id:int}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var entityData = _context.PatientAllergy.IncludeRelated().FirstOrDefault(entity => entity.Sequence == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientAllergy.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientallergy by its primary key</summary>
        /// <param name="entityId">The primary key of the patientallergy</param>
        /// <param name="updatedEntity">The patientallergy data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientAllergy",Entitlements.Update)]
        [Route("{id:int}")]
        public IActionResult UpdateById(int id, [FromBody] PatientAllergy updatedEntity)
        {
            if (id != updatedEntity.Sequence)
            {
                return BadRequest("Mismatched Sequence");
            }

            this._context.PatientAllergy.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}