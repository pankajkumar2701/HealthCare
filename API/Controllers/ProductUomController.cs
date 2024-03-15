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
    /// Controller responsible for managing productuom-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting productuom information.
    /// </remarks>
    [Route("api/productuom")]
    [Authorize]
    public class ProductUomController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ProductUomController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new productuom to the database</summary>
        /// <param name="model">The productuom data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ProductUom",Entitlements.Create)]
        public IActionResult Post([FromBody] ProductUom model)
        {
            _context.ProductUom.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of productuoms based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of productuoms</returns>
        [HttpGet]
        [UserAuthorize("ProductUom",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ProductUom.IncludeRelated().AsQueryable();
            var result = FilterService<ProductUom>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific productuom by its primary key</summary>
        /// <param name="entityId">The primary key of the productuom</param>
        /// <returns>The productuom data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ProductUom",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ProductUom.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific productuom by its primary key</summary>
        /// <param name="entityId">The primary key of the productuom</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ProductUom",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ProductUom.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ProductUom.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific productuom by its primary key</summary>
        /// <param name="entityId">The primary key of the productuom</param>
        /// <param name="updatedEntity">The productuom data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ProductUom",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ProductUom updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ProductUom.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}