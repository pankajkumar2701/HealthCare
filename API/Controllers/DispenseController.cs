using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;
using HealthCare.Data;
using HealthCare.Filter;
using HealthCare.Entities;
using HealthCare.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare.Controllers
{
    [Route("api/dispense")]
    [Authorize]
    public class DispenseController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public DispenseController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new dispense to the database</summary>
        /// <param name="model">The dispense data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("Dispense",Entitlements.Create)]
        public IActionResult Post([FromBody] Dispense model)
        {
            _context.Dispense.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of dispenses based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of dispenses</returns>
        [HttpGet]
        [UserAuthorize("Dispense",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.Dispense.IncludeRelated().AsQueryable();
            var result = FilterService<Dispense>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }
    }
}