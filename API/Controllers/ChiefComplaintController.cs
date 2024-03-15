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
    /// Controller responsible for managing chiefcomplaint-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting chiefcomplaint information.
    /// </remarks>
    [Route("api/chiefcomplaint")]
    [Authorize]
    public class ChiefComplaintController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public ChiefComplaintController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new chiefcomplaint to the database</summary>
        /// <param name="model">The chiefcomplaint data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("ChiefComplaint",Entitlements.Create)]
        public IActionResult Post([FromBody] ChiefComplaint model)
        {
            _context.ChiefComplaint.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of chiefcomplaints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of chiefcomplaints</returns>
        [HttpGet]
        [UserAuthorize("ChiefComplaint",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.ChiefComplaint.IncludeRelated().AsQueryable();
            var result = FilterService<ChiefComplaint>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific chiefcomplaint by its primary key</summary>
        /// <param name="entityId">The primary key of the chiefcomplaint</param>
        /// <returns>The chiefcomplaint data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("ChiefComplaint",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.ChiefComplaint.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific chiefcomplaint by its primary key</summary>
        /// <param name="entityId">The primary key of the chiefcomplaint</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("ChiefComplaint",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.ChiefComplaint.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.ChiefComplaint.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific chiefcomplaint by its primary key</summary>
        /// <param name="entityId">The primary key of the chiefcomplaint</param>
        /// <param name="updatedEntity">The chiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("ChiefComplaint",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] ChiefComplaint updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.ChiefComplaint.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}