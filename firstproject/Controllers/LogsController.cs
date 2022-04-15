using firstproject.data.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private LogService _logService;
        public LogsController(LogService logService)
        {
            _logService = logService;
        }
        [HttpGet("get-all-logs-from-db")]
        public IActionResult GetAllLogsFromDB()
        {
            try
            {
                var allLogs = _logService.GetAllLogsFromDB();
                return Ok(allLogs);
            }
            catch (Exception)
            {

                return BadRequest("Could not load logs from DB");
            }
        }
    }
}
