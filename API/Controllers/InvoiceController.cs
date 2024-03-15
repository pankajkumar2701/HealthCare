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
    /// Controller responsible for managing invoice-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting invoice information.
    /// </remarks>
    [Route("api/invoice")]
    [Authorize]
    public class InvoiceController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public InvoiceController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new invoice to the database</summary>
        /// <param name="model">The invoice data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Invoice",Entitlements.Create)]
        public IActionResult Post([FromBody] Invoice model)
        {
            _context.Invoice.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of invoices based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of invoices</returns>
        [HttpGet]
        [UserAuthorize("Invoice",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Invoice.IncludeRelated().AsQueryable();
            var result = FilterService<Invoice>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific invoice by its primary key</summary>
        /// <param name="entityId">The primary key of the invoice</param>
        /// <returns>The invoice data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Invoice",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Invoice.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific invoice by its primary key</summary>
        /// <param name="entityId">The primary key of the invoice</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Invoice",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Invoice.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Invoice.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific invoice by its primary key</summary>
        /// <param name="entityId">The primary key of the invoice</param>
        /// <param name="updatedEntity">The invoice data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Invoice",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Invoice updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Invoice.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}