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
    /// Controller responsible for managing procedure-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting procedure information.
    /// </remarks>
    [Route("api/procedure")]
    [Authorize]
    public class ProcedureController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ProcedureController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new procedure to the database</summary>
        /// <param name="model">The procedure data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Procedure",Entitlements.Create)]
        public IActionResult Post([FromBody] Procedure model)
        {
            _context.Procedure.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of procedures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of procedures</returns>
        [HttpGet]
        [UserAuthorize("Procedure",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Procedure.IncludeRelated().AsQueryable();
            var result = FilterService<Procedure>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific procedure by its primary key</summary>
        /// <param name="entityId">The primary key of the procedure</param>
        /// <returns>The procedure data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Procedure",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Procedure.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific procedure by its primary key</summary>
        /// <param name="entityId">The primary key of the procedure</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Procedure",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Procedure.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Procedure.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific procedure by its primary key</summary>
        /// <param name="entityId">The primary key of the procedure</param>
        /// <param name="updatedEntity">The procedure data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Procedure",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Procedure updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Procedure.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}