using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfmoSchedule.ScheduleManager.Models;
using IfmoSchedule.ScheduleManager.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IfmoSchedule.Controllers
{
    [Produces("application/json")]
    [Route("api/Comparing")]
    public class ComparingController : Controller
    {
        [HttpGet("{groupFirst/groupSecond}")]
        public string GroupLessonCompare(string groupFirst, string groupSecond)
        {
            throw new NotImplementedException();
            var repository = new ServerStorageRepository();

            var compare = new CompareService(repository.GetLessonList(groupFirst),
                repository.GetLessonList(groupSecond));
        }
    }
}
