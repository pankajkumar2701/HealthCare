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
    /// Controller responsible for managing uom-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting uom information.
    /// </remarks>
    [Route("api/uom")]
    [Authorize]
    public class UomController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public UomController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new uom to the database</summary>
        /// <param name="model">The uom data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Uom",Entitlements.Create)]
        public IActionResult Post([FromBody] Uom model)
        {
            _context.Uom.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of uoms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of uoms</returns>
        [HttpGet]
        [UserAuthorize("Uom",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Uom.IncludeRelated().AsQueryable();
            var result = FilterService<Uom>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific uom by its primary key</summary>
        /// <param name="entityId">The primary key of the uom</param>
        /// <returns>The uom data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Uom",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Uom.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific uom by its primary key</summary>
        /// <param name="entityId">The primary key of the uom</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Uom",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Uom.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Uom.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific uom by its primary key</summary>
        /// <param name="entityId">The primary key of the uom</param>
        /// <param name="updatedEntity">The uom data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Uom",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Uom updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Uom.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}