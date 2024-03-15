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
    /// Controller responsible for managing comorbidity-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting comorbidity information.
    /// </remarks>
    [Route("api/comorbidity")]
    [Authorize]
    public class ComorbidityController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ComorbidityController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new comorbidity to the database</summary>
        /// <param name="model">The comorbidity data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Comorbidity",Entitlements.Create)]
        public IActionResult Post([FromBody] Comorbidity model)
        {
            _context.Comorbidity.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of comorbiditys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of comorbiditys</returns>
        [HttpGet]
        [UserAuthorize("Comorbidity",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Comorbidity.IncludeRelated().AsQueryable();
            var result = FilterService<Comorbidity>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific comorbidity by its primary key</summary>
        /// <param name="entityId">The primary key of the comorbidity</param>
        /// <returns>The comorbidity data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Comorbidity",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Comorbidity.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific comorbidity by its primary key</summary>
        /// <param name="entityId">The primary key of the comorbidity</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Comorbidity",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Comorbidity.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Comorbidity.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific comorbidity by its primary key</summary>
        /// <param name="entityId">The primary key of the comorbidity</param>
        /// <param name="updatedEntity">The comorbidity data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Comorbidity",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Comorbidity updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Comorbidity.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}