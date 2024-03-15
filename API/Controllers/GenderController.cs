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
    /// Controller responsible for managing gender-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting gender information.
    /// </remarks>
    [Route("api/gender")]
    [Authorize]
    public class GenderController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public GenderController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new gender to the database</summary>
        /// <param name="model">The gender data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Gender",Entitlements.Create)]
        public IActionResult Post([FromBody] Gender model)
        {
            _context.Gender.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of genders based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of genders</returns>
        [HttpGet]
        [UserAuthorize("Gender",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Gender.IncludeRelated().AsQueryable();
            var result = FilterService<Gender>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific gender by its primary key</summary>
        /// <param name="entityId">The primary key of the gender</param>
        /// <returns>The gender data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Gender",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Gender.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific gender by its primary key</summary>
        /// <param name="entityId">The primary key of the gender</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Gender",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Gender.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Gender.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific gender by its primary key</summary>
        /// <param name="entityId">The primary key of the gender</param>
        /// <param name="updatedEntity">The gender data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Gender",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Gender updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Gender.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}