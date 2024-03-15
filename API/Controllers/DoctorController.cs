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
    /// Controller responsible for managing doctor-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting doctor information.
    /// </remarks>
    [Route("api/doctor")]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public DoctorController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new doctor to the database</summary>
        /// <param name="model">The doctor data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Doctor",Entitlements.Create)]
        public IActionResult Post([FromBody] Doctor model)
        {
            _context.Doctor.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of doctors based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of doctors</returns>
        [HttpGet]
        [UserAuthorize("Doctor",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Doctor.IncludeRelated().AsQueryable();
            var result = FilterService<Doctor>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific doctor by its primary key</summary>
        /// <param name="entityId">The primary key of the doctor</param>
        /// <returns>The doctor data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Doctor",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Doctor.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific doctor by its primary key</summary>
        /// <param name="entityId">The primary key of the doctor</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Doctor",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Doctor.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Doctor.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific doctor by its primary key</summary>
        /// <param name="entityId">The primary key of the doctor</param>
        /// <param name="updatedEntity">The doctor data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Doctor",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Doctor updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Doctor.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}