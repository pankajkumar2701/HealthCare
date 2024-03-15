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
    /// Controller responsible for managing membership-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting membership information.
    /// </remarks>
    [Route("api/membership")]
    [Authorize]
    public class MembershipController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public MembershipController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new membership to the database</summary>
        /// <param name="model">The membership data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Membership",Entitlements.Create)]
        public IActionResult Post([FromBody] Membership model)
        {
            _context.Membership.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of memberships based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of memberships</returns>
        [HttpGet]
        [UserAuthorize("Membership",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Membership.IncludeRelated().AsQueryable();
            var result = FilterService<Membership>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific membership by its primary key</summary>
        /// <param name="entityId">The primary key of the membership</param>
        /// <returns>The membership data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Membership",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Membership.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific membership by its primary key</summary>
        /// <param name="entityId">The primary key of the membership</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Membership",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Membership.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Membership.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific membership by its primary key</summary>
        /// <param name="entityId">The primary key of the membership</param>
        /// <param name="updatedEntity">The membership data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Membership",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Membership updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Membership.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}