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
    /// Controller responsible for managing druglistitems-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting druglistitems information.
    /// </remarks>
    [Route("api/druglistitems")]
    [Authorize]
    public class DrugListItemsController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public DrugListItemsController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new druglistitems to the database</summary>
        /// <param name="model">The druglistitems data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("DrugListItems",Entitlements.Create)]
        public IActionResult Post([FromBody] DrugListItems model)
        {
            _context.DrugListItems.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of druglistitemss based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of druglistitemss</returns>
        [HttpGet]
        [UserAuthorize("DrugListItems",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.DrugListItems.IncludeRelated().AsQueryable();
            var result = FilterService<DrugListItems>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific druglistitems by its primary key</summary>
        /// <param name="entityId">The primary key of the druglistitems</param>
        /// <returns>The druglistitems data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("DrugListItems",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.DrugListItems.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific druglistitems by its primary key</summary>
        /// <param name="entityId">The primary key of the druglistitems</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("DrugListItems",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.DrugListItems.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.DrugListItems.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific druglistitems by its primary key</summary>
        /// <param name="entityId">The primary key of the druglistitems</param>
        /// <param name="updatedEntity">The druglistitems data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("DrugListItems",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] DrugListItems updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.DrugListItems.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}