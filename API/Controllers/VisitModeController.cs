using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;
using HealthCare.Data;
using HealthCare.Filter;
using HealthCare.Entities;
using HealthCare.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare.Controllers
{
    [Route("api/visitmode")]
    [Authorize]
    public class VisitModeController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitModeController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visitmode to the database</summary>
        /// <param name="model">The visitmode data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitMode",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitMode model)
        {
            _context.VisitMode.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visitmodes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visitmodes</returns>
        [HttpGet]
        [UserAuthorize("VisitMode",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitMode.IncludeRelated().AsQueryable();
            var result = FilterService<VisitMode>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }
    }
}