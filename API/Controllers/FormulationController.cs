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
    /// Controller responsible for managing formulation-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting formulation information.
    /// </remarks>
    [Route("api/formulation")]
    [Authorize]
    public class FormulationController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public FormulationController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new formulation to the database</summary>
        /// <param name="model">The formulation data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Formulation",Entitlements.Create)]
        public IActionResult Post([FromBody] Formulation model)
        {
            _context.Formulation.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of formulations based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of formulations</returns>
        [HttpGet]
        [UserAuthorize("Formulation",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Formulation.IncludeRelated().AsQueryable();
            var result = FilterService<Formulation>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific formulation by its primary key</summary>
        /// <param name="entityId">The primary key of the formulation</param>
        /// <returns>The formulation data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("Formulation",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.Formulation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific formulation by its primary key</summary>
        /// <param name="entityId">The primary key of the formulation</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("Formulation",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.Formulation.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.Formulation.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific formulation by its primary key</summary>
        /// <param name="entityId">The primary key of the formulation</param>
        /// <param name="updatedEntity">The formulation data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("Formulation",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] Formulation updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.Formulation.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}