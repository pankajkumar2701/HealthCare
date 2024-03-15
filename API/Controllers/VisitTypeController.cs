using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;
using HealthCare.Data;
using HealthCare.Filter;
using HealthCare.Entities;
using HealthCare.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare.Controllers
{
    [Route("api/visittype")]
    [Authorize]
    public class VisitTypeController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public VisitTypeController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new visittype to the database</summary>
        /// <param name="model">The visittype data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("VisitType",Entitlements.Create)]
        public IActionResult Post([FromBody] VisitType model)
        {
            _context.VisitType.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of visittypes based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of visittypes</returns>
        [HttpGet]
        [UserAuthorize("VisitType",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.VisitType.IncludeRelated().AsQueryable();
            var result = FilterService<VisitType>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }
    }
}