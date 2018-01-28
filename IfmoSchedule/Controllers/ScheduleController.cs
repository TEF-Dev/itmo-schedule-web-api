using IfmoSchedule.Services;
using Microsoft.AspNetCore.Mvc;


namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/Schedule")]
    public class ScheduleController : Controller
    {
        // GET: api/Schedule
        [HttpGet]
        public string Get()
        {
            var generator = new ScheduleGenerator();
            //TODO: Get current data
            var msg = generator.GenerateMessage(-1, -1);

            return msg;
        }

        //TODO: Request with params
        // GET: api/Schedule/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}
    }
}