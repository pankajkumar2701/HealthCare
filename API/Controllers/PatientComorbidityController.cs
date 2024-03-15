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
    /// Controller responsible for managing patientcomorbidity-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientcomorbidity information.
    /// </remarks>
    [Route("api/patientcomorbidity")]
    [Authorize]
    public class PatientComorbidityController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientComorbidityController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientcomorbidity to the database</summary>
        /// <param name="model">The patientcomorbidity data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientComorbidity",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientComorbidity model)
        {
            _context.PatientComorbidity.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientcomorbiditys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientcomorbiditys</returns>
        [HttpGet]
        [UserAuthorize("PatientComorbidity",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientComorbidity.IncludeRelated().AsQueryable();
            var result = FilterService<PatientComorbidity>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientcomorbidity by its primary key</summary>
        /// <param name="entityId">The primary key of the patientcomorbidity</param>
        /// <returns>The patientcomorbidity data</returns>
        [HttpGet]
        [Route("{id:int}")]
        [UserAuthorize("PatientComorbidity",Entitlements.Read)]
        public IActionResult GetById([FromRoute] int id)
        {
            var entityData = _context.PatientComorbidity.IncludeRelated().FirstOrDefault(entity => entity.Sequence == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientcomorbidity by its primary key</summary>
        /// <param name="entityId">The primary key of the patientcomorbidity</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientComorbidity",Entitlements.Delete)]
        [Route("{id:int}")]
        public IActionResult DeleteById([FromRoute] int id)
        {
            var entityData = _context.PatientComorbidity.IncludeRelated().FirstOrDefault(entity => entity.Sequence == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientComorbidity.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientcomorbidity by its primary key</summary>
        /// <param name="entityId">The primary key of the patientcomorbidity</param>
        /// <param name="updatedEntity">The patientcomorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientComorbidity",Entitlements.Update)]
        [Route("{id:int}")]
        public IActionResult UpdateById(int id, [FromBody] PatientComorbidity updatedEntity)
        {
            if (id != updatedEntity.Sequence)
            {
                return BadRequest("Mismatched Sequence");
            }

            this._context.PatientComorbidity.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}