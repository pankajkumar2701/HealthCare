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
    /// Controller responsible for managing productcategory-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting productcategory information.
    /// </remarks>
    [Route("api/productcategory")]
    [Authorize]
    public class ProductCategoryController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ProductCategoryController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new productcategory to the database</summary>
        /// <param name="model">The productcategory data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ProductCategory",Entitlements.Create)]
        public IActionResult Post([FromBody] ProductCategory model)
        {
            _context.ProductCategory.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of productcategorys based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of productcategorys</returns>
        [HttpGet]
        [UserAuthorize("ProductCategory",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ProductCategory.IncludeRelated().AsQueryable();
            var result = FilterService<ProductCategory>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific productcategory by its primary key</summary>
        /// <param name="entityId">The primary key of the productcategory</param>
        /// <returns>The productcategory data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ProductCategory",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ProductCategory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific productcategory by its primary key</summary>
        /// <param name="entityId">The primary key of the productcategory</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ProductCategory",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ProductCategory.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ProductCategory.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific productcategory by its primary key</summary>
        /// <param name="entityId">The primary key of the productcategory</param>
        /// <param name="updatedEntity">The productcategory data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ProductCategory",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ProductCategory updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ProductCategory.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}