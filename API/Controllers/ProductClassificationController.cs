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
    /// Controller responsible for managing productclassification-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting productclassification information.
    /// </remarks>
    [Route("api/productclassification")]
    [Authorize]
    public class ProductClassificationController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ProductClassificationController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new productclassification to the database</summary>
        /// <param name="model">The productclassification data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ProductClassification",Entitlements.Create)]
        public IActionResult Post([FromBody] ProductClassification model)
        {
            _context.ProductClassification.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of productclassifications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of productclassifications</returns>
        [HttpGet]
        [UserAuthorize("ProductClassification",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ProductClassification.IncludeRelated().AsQueryable();
            var result = FilterService<ProductClassification>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific productclassification by its primary key</summary>
        /// <param name="entityId">The primary key of the productclassification</param>
        /// <returns>The productclassification data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ProductClassification",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ProductClassification.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific productclassification by its primary key</summary>
        /// <param name="entityId">The primary key of the productclassification</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ProductClassification",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ProductClassification.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ProductClassification.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific productclassification by its primary key</summary>
        /// <param name="entityId">The primary key of the productclassification</param>
        /// <param name="updatedEntity">The productclassification data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ProductClassification",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ProductClassification updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ProductClassification.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}