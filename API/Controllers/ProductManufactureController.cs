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
    /// Controller responsible for managing productmanufacture-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting productmanufacture information.
    /// </remarks>
    [Route("api/productmanufacture")]
    [Authorize]
    public class ProductManufactureController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ProductManufactureController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new productmanufacture to the database</summary>
        /// <param name="model">The productmanufacture data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ProductManufacture",Entitlements.Create)]
        public IActionResult Post([FromBody] ProductManufacture model)
        {
            _context.ProductManufacture.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of productmanufactures based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of productmanufactures</returns>
        [HttpGet]
        [UserAuthorize("ProductManufacture",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ProductManufacture.IncludeRelated().AsQueryable();
            var result = FilterService<ProductManufacture>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific productmanufacture by its primary key</summary>
        /// <param name="entityId">The primary key of the productmanufacture</param>
        /// <returns>The productmanufacture data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ProductManufacture",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ProductManufacture.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific productmanufacture by its primary key</summary>
        /// <param name="entityId">The primary key of the productmanufacture</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ProductManufacture",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ProductManufacture.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ProductManufacture.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific productmanufacture by its primary key</summary>
        /// <param name="entityId">The primary key of the productmanufacture</param>
        /// <param name="updatedEntity">The productmanufacture data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ProductManufacture",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ProductManufacture updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ProductManufacture.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}