using BCTest.DB;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BCTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        private IBDService _dbservice;

        public TestController(ILogger<TestController> logger, IBDService dbservice   )
        {
            _logger  = logger;
            _dbservice = dbservice;
        }

        [HttpGet]
        public List<int> Get(int n)
        {
            return _dbservice.GetExaminee(n);
        }



        [HttpPut()]
        public List<int> Put()
        {
            return _dbservice.GetOrderExaminee();
        }



        // POST api/<TestController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // DELETE api/<TestController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
