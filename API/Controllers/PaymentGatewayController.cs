using Microsoft.AspNetCore.Mvc;
using HealthCare.Models;
using HealthCare.Data;
using HealthCare.Filter;
using HealthCare.Entities;
using HealthCare.Authorization;
using Microsoft.AspNetCore.Authorization;

namespace HealthCare.Controllers
{
    [Route("api/paymentgateway")]
    [Authorize]
    public class PaymentGatewayController : ControllerBase
    {
        private readonly HealthCareContext _context;

        public PaymentGatewayController(HealthCareContext context)
        {
            _context = context;
        }

        /// <summary>Adds a new paymentgateway to the database</summary>
        /// <param name="model">The paymentgateway data to be added</param>
        /// <returns>The result of the operation</returns>
        [HttpPost]
        [UserAuthorize("PaymentGateway",Entitlements.Create)]
        public IActionResult Post([FromBody] PaymentGateway model)
        {
            _context.PaymentGateway.Add(model);
            var returnData = this._context.SaveChanges();
            return Ok(returnData);
        }

        /// <summary>Retrieves a list of paymentgateways based on specified filters</summary>
        /// <param name="filters">The filter criteria in JSON format. Use the following format: [{"PropertyName": "PropertyName", "Operator": "Equal", "Value": "FilterValue"}] </param>
        /// <returns>The filtered list of paymentgateways</returns>
        [HttpGet]
        [UserAuthorize("PaymentGateway",Entitlements.Read)]
        public IActionResult Get([FromQuery] string filters)
        {
            List<FilterCriteria> filterCriteria = null;
            if (!string.IsNullOrEmpty(filters))
            {
                filterCriteria = JsonHelper.Deserialize<List<FilterCriteria>>(filters);
            }

            var query = _context.PaymentGateway.IncludeRelated().AsQueryable();
            var result = FilterService<PaymentGateway>.ApplyFilter(query, filterCriteria);
            return Ok(result);
        }
    }
}