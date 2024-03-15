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
    /// Controller responsible for managing accountsettlement-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting accountsettlement information.
    /// </remarks>
    [Route("api/accountsettlement")]
    [Authorize]
    public class AccountSettlementController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public AccountSettlementController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new accountsettlement to the database</summary>
        /// <param name="model">The accountsettlement data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("AccountSettlement",Entitlements.Create)]
        public IActionResult Post([FromBody] AccountSettlement model)
        {
            _context.AccountSettlement.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of accountsettlements based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of accountsettlements</returns>
        [HttpGet]
        [UserAuthorize("AccountSettlement",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.AccountSettlement.IncludeRelated().AsQueryable();
            var result = FilterService<AccountSettlement>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific accountsettlement by its primary key</summary>
        /// <param name="entityId">The primary key of the accountsettlement</param>
        /// <returns>The accountsettlement data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("AccountSettlement",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.AccountSettlement.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific accountsettlement by its primary key</summary>
        /// <param name="entityId">The primary key of the accountsettlement</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("AccountSettlement",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.AccountSettlement.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.AccountSettlement.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific accountsettlement by its primary key</summary>
        /// <param name="entityId">The primary key of the accountsettlement</param>
        /// <param name="updatedEntity">The accountsettlement data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("AccountSettlement",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] AccountSettlement updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.AccountSettlement.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}