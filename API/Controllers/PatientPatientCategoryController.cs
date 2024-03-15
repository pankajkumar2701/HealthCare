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
    /// Controller responsible for managing patientpatientcategory-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientpatientcategory information.
    /// </remarks>
    [Route("api/patientpatientcategory")]
    [Authorize]
    public class PatientPatientCategoryController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientPatientCategoryController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientpatientcategory to the database</summary>
        /// <param name="model">The patientpatientcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientPatientCategory",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientPatientCategory model)
        {
            _context.PatientPatientCategory.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientpatientcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientpatientcategorys</returns>
        [HttpGet]
        [UserAuthorize("PatientPatientCategory",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientPatientCategory.IncludeRelated().AsQueryable();
            var result = FilterService<PatientPatientCategory>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientpatientcategory by its primary key</summary>
        /// <param name="entityId">The primary key of the patientpatientcategory</param>
        /// <returns>The patientpatientcategory data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientPatientCategory",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientPatientCategory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientpatientcategory by its primary key</summary>
        /// <param name="entityId">The primary key of the patientpatientcategory</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientPatientCategory",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientPatientCategory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientPatientCategory.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientpatientcategory by its primary key</summary>
        /// <param name="entityId">The primary key of the patientpatientcategory</param>
        /// <param name="updatedEntity">The patientpatientcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientPatientCategory",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientPatientCategory updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientPatientCategory.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}