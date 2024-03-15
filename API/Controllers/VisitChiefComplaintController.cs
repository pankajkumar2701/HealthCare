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
    /// Controller responsible for managing visitchiefcomplaint-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visitchiefcomplaint information.
    /// </remarks>
    [Route("api/visitchiefcomplaint")]
    [Authorize]
    public class VisitChiefComplaintController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitChiefComplaintController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitchiefcomplaint to the database</summary>
        /// <param name="model">The visitchiefcomplaint data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitChiefComplaint",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitChiefComplaint model)
        {
            _context.VisitChiefComplaint.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitchiefcomplaints based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitchiefcomplaints</returns>
        [HttpGet]
        [UserAuthorize("VisitChiefComplaint",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitChiefComplaint.IncludeRelated().AsQueryable();
            var result = FilterService<VisitChiefComplaint>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitchiefcomplaint by its primary key</summary>
        /// <param name="entityId">The primary key of the visitchiefcomplaint</param>
        /// <returns>The visitchiefcomplaint data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("VisitChiefComplaint",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.VisitChiefComplaint.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visitchiefcomplaint by its primary key</summary>
        /// <param name="entityId">The primary key of the visitchiefcomplaint</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("VisitChiefComplaint",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.VisitChiefComplaint.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.VisitChiefComplaint.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visitchiefcomplaint by its primary key</summary>
        /// <param name="entityId">The primary key of the visitchiefcomplaint</param>
        /// <param name="updatedEntity">The visitchiefcomplaint data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("VisitChiefComplaint",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitChiefComplaint updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.VisitChiefComplaint.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}