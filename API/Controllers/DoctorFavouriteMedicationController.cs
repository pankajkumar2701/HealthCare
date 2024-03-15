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
    /// Controller responsible for managing doctorfavouritemedication-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting doctorfavouritemedication information.
    /// </remarks>
    [Route("api/doctorfavouritemedication")]
    [Authorize]
    public class DoctorFavouriteMedicationController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public DoctorFavouriteMedicationController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new doctorfavouritemedication to the database</summary>
        /// <param name="model">The doctorfavouritemedication data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("DoctorFavouriteMedication",Entitlements.Create)]
        public IActionResult Post([FromBody] DoctorFavouriteMedication model)
        {
            _context.DoctorFavouriteMedication.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of doctorfavouritemedications based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of doctorfavouritemedications</returns>
        [HttpGet]
        [UserAuthorize("DoctorFavouriteMedication",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.DoctorFavouriteMedication.IncludeRelated().AsQueryable();
            var result = FilterService<DoctorFavouriteMedication>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific doctorfavouritemedication by its primary key</summary>
        /// <param name="entityId">The primary key of the doctorfavouritemedication</param>
        /// <returns>The doctorfavouritemedication data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("DoctorFavouriteMedication",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.DoctorFavouriteMedication.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific doctorfavouritemedication by its primary key</summary>
        /// <param name="entityId">The primary key of the doctorfavouritemedication</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("DoctorFavouriteMedication",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.DoctorFavouriteMedication.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.DoctorFavouriteMedication.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific doctorfavouritemedication by its primary key</summary>
        /// <param name="entityId">The primary key of the doctorfavouritemedication</param>
        /// <param name="updatedEntity">The doctorfavouritemedication data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("DoctorFavouriteMedication",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] DoctorFavouriteMedication updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.DoctorFavouriteMedication.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}