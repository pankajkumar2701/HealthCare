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
    /// Controller responsible for managing paymentmode-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting paymentmode information.
    /// </remarks>
    [Route("api/paymentmode")]
    [Authorize]
    public class PaymentModeController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PaymentModeController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new paymentmode to the database</summary>
        /// <param name="model">The paymentmode data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PaymentMode",Entitlements.Create)]
        public IActionResult Post([FromBody] PaymentMode model)
        {
            _context.PaymentMode.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of paymentmodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of paymentmodes</returns>
        [HttpGet]
        [UserAuthorize("PaymentMode",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PaymentMode.IncludeRelated().AsQueryable();
            var result = FilterService<PaymentMode>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific paymentmode by its primary key</summary>
        /// <param name="entityId">The primary key of the paymentmode</param>
        /// <returns>The paymentmode data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("PaymentMode",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.PaymentMode.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific paymentmode by its primary key</summary>
        /// <param name="entityId">The primary key of the paymentmode</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("PaymentMode",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.PaymentMode.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.PaymentMode.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific paymentmode by its primary key</summary>
        /// <param name="entityId">The primary key of the paymentmode</param>
        /// <param name="updatedEntity">The paymentmode data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("PaymentMode",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] PaymentMode updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.PaymentMode.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}