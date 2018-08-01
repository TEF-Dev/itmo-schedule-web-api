using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IfmoSchedule.Models;
using IfmoSchedule.Repositories;
using IfmoSchedule.Services;
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

            var list = new List<List<LessonModel>>
            {
                new ServerStorageRepository(groupFirst).LessonList,
                new ServerStorageRepository(groupSecond).LessonList
            };
            var compare = new CompareService(list);
        }
    }
}
