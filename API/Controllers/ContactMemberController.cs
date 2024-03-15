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
    /// Controller responsible for managing contactmember-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting contactmember information.
    /// </remarks>
    [Route("api/contactmember")]
    [Authorize]
    public class ContactMemberController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ContactMemberController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new contactmember to the database</summary>
        /// <param name="model">The contactmember data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ContactMember",Entitlements.Create)]
        public IActionResult Post([FromBody] ContactMember model)
        {
            _context.ContactMember.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of contactmembers based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of contactmembers</returns>
        [HttpGet]
        [UserAuthorize("ContactMember",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ContactMember.IncludeRelated().AsQueryable();
            var result = FilterService<ContactMember>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific contactmember by its primary key</summary>
        /// <param name="entityId">The primary key of the contactmember</param>
        /// <returns>The contactmember data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ContactMember",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ContactMember.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific contactmember by its primary key</summary>
        /// <param name="entityId">The primary key of the contactmember</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ContactMember",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ContactMember.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ContactMember.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific contactmember by its primary key</summary>
        /// <param name="entityId">The primary key of the contactmember</param>
        /// <param name="updatedEntity">The contactmember data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ContactMember",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ContactMember updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ContactMember.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}