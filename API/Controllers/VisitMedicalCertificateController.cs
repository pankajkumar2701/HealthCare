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
    /// Controller responsible for managing visitmedicalcertificate-related operations in the API.
    /// </summary>
    /// <remarks>
    /// This controller provides endpoints for adding, retrieving, updating, and deleting visitmedicalcertificate information.
    /// </remarks>
    [Route("api/visitmedicalcertificate")]
    [Authorize]
    public class VisitMedicalCertificateController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitMedicalCertificateController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitmedicalcertificate to the database</summary>
        /// <param name="model">The visitmedicalcertificate data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitMedicalCertificate",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitMedicalCertificate model)
        {
            _context.VisitMedicalCertificate.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitmedicalcertificates based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitmedicalcertificates</returns>
        [HttpGet]
        [UserAuthorize("VisitMedicalCertificate",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitMedicalCertificate.IncludeRelated().AsQueryable();
            var result = FilterService<VisitMedicalCertificate>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }

        /// <summary>Retrieves a specific visitmedicalcertificate by its primary key</summary>
        /// <param name="entityId">The primary key of the visitmedicalcertificate</param>
        /// <returns>The visitmedicalcertificate data</returns>
        [HttpGet]
        [Route("{id:Guid}")]
        [UserAuthorize("VisitMedicalCertificate",Entitlements.Read)]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var entityData = _context.VisitMedicalCertificate.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            return Ok(entityData);
        }

        /// <summary>Deletes a specific visitmedicalcertificate by its primary key</summary>
        /// <param name="entityId">The primary key of the visitmedicalcertificate</param>
        /// <returns>The result of the operation</returns>
        [HttpDelete]
        [UserAuthorize("VisitMedicalCertificate",Entitlements.Delete)]
        [Route("{id:Guid}")]
        public IActionResult DeleteById([FromRoute] Guid id)
        {
            var entityData = _context.VisitMedicalCertificate.IncludeRelated().FirstOrDefault(entity => entity.Id == id);
            if (entityData == null)
            {
                return NotFound();
            }

            _context.VisitMedicalCertificate.Remove(entityData);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Updates a specific visitmedicalcertificate by its primary key</summary>
        /// <param name="entityId">The primary key of the visitmedicalcertificate</param>
        /// <param name="updatedEntity">The visitmedicalcertificate data to be updated</param>
        /// <returns>The result of the operation</returns>
        [HttpPut]
        [UserAuthorize("VisitMedicalCertificate",Entitlements.Update)]
        [Route("{id:Guid}")]
        public IActionResult UpdateById(Guid id, [FromBody] VisitMedicalCertificate updatedEntity)
        {
            if (id != updatedEntity.Id)
            {
                return BadRequest("Mismatched Id");
            }

            this._context.VisitMedicalCertificate.Update(updatedEntity);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }
    }
}