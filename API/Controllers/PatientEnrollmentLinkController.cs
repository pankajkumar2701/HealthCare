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
    /// Controller responsible for managing patientenrollmentlink-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting patientenrollmentlink information.
    /// </remarks>
    [Route("api/patientenrollmentlink")]
    [Authorize]
    public class PatientEnrollmentLinkController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PatientEnrollmentLinkController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new patientenrollmentlink to the database</summary>
        /// <param name="model">The patientenrollmentlink data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PatientEnrollmentLink",Entitlements.Create)]
        public IActionResult Post([FromBody] PatientEnrollmentLink model)
        {
            _context.PatientEnrollmentLink.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of patientenrollmentlinks based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of patientenrollmentlinks</returns>
        [HttpGet]
        [UserAuthorize("PatientEnrollmentLink",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PatientEnrollmentLink.IncludeRelated().AsQueryable();
            var result = FilterService<PatientEnrollmentLink>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific patientenrollmentlink by its primary key</summary>
        /// <param name="entityId">The primary key of the patientenrollmentlink</param>
        /// <returns>The patientenrollmentlink data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PatientEnrollmentLink",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PatientEnrollmentLink.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific patientenrollmentlink by its primary key</summary>
        /// <param name="entityId">The primary key of the patientenrollmentlink</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PatientEnrollmentLink",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PatientEnrollmentLink.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PatientEnrollmentLink.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific patientenrollmentlink by its primary key</summary>
        /// <param name="entityId">The primary key of the patientenrollmentlink</param>
        /// <param name="updatedEntity">The patientenrollmentlink data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PatientEnrollmentLink",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PatientEnrollmentLink updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PatientEnrollmentLink.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}