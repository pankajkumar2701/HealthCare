using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;
using HealthCare.Data;
using HealthCare.Filter;
using HealthCare.Entities;
using HealthCare.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;

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
            this._context.SaveChanges();
            return Ok(new { model.Id });
        }

        /// <summary>Retrieves a list of patientpatientcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>The filtered list of patientpatientcategorys</returns>
        [HttpGet]
        [UserAuthorize("PatientPatientCategory",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters, int pageNumber = 1, int pageSize = 10)
        {
            List<FilterCriteria> filterCriteria = null;
            if (pageSize < 1)
            {
                return BadRequest("Page size invalid.");
            }

            if (pageNumber < 1)
            {
                return BadRequest("Page mumber invalid.");
            }

            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientPatientCategory.IncludeRelated().AsQueryable();
            int skip = (pageNumber - 1) * pageSize;
            var result = FilterService<PatientPatientCategory>.ApplyFilter(query, filterCriteria);
            var paginatedResult = result.Skip(skip).Take(pageSize).ToList();
            return Ok(paginatedResult);
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
            var status = this._context.SaveChanges();
            return Ok(new { status });
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
            var status = this._context.SaveChanges();
            return Ok(new { status });
        }

        /// <summary>Updates a specific patientpatientcategory by its primary key</summary>
        /// <param name="entityId">The primary key of the patientpatientcategory</param>
        /// <param name="updatedEntity">The patientpatientcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPatch]
        [UserAuthorize("PatientPatientCategory",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] JsonPatchDocument<PatientPatientCategory> updatedEntity)
        {
            if (updatedEntity == null)
                return BadRequest("Patch document is missing.");
            var existingEntity = this._context.PatientPatientCategory.FirstOrDefault(t => t.Id == id);
            if (existingEntity == null)
                return NotFound();
            updatedEntity.ApplyTo(existingEntity, ModelState);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            this._context.PatientPatientCategory.Update(existingEntity);
            var status = this._context.SaveChanges();
            return Ok(new { status });
        }
    }
}