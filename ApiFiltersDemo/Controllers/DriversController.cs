using ApiFiltersDemo.Configurations.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiFiltersDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MyActionFilter("DriversController.Get.ContollerLevel")]
    public class DriversController : ControllerBase
    {
        private readonly ILogger<DriversController> _logger;
        private List<string> _drivers;

        public DriversController(ILogger<DriversController> logger)
        {
            _drivers = new List<string>() { "Jhonty", "Philip", "Steve",
            "Carlos", "Arthur", };
            _logger = logger;
        }

        // GET: api/<DriversController>
        [HttpGet]
        [MyAsyncActionFilter("DriversController.Get.MethodLevel")]
        [MySecondAsyncActionFilter("DriversController.Get.MethodLevel", -10)] //min order gets precedence, even before global filters
        [MyActionFilter("DriversController.Get.MethodLevel")] //even if sync is added later, sync gets priority over async
        public IActionResult Get()
        {
            _logger.LogInformation("Executed DriversController.Get ActionMethod");
            return Ok(_drivers);
        }

        //// GET api/<DriversController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<DriversController>
        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            _drivers.Add(value);
            _logger.LogInformation("Executed DriversController.Post ActionMethod");
            return Ok(_drivers);
        }

        //// PUT api/<DriversController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<DriversController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
