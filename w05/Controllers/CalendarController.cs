using Dapper;
using w05.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
namespace w05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase
    {
        private readonly string _connectString = DBUtil.ConnectionString();

        [HttpGet]
        public async Task<IEnumerable<Calendar>> GetCalendars()
        {
            string sqlQuery = "SELECT * FROM MyCalendar";
            using (var connection = new SqlConnection(_connectString))
            {
                var Calendars = await connection.QueryAsync<Calendar>(sqlQuery);
                return Calendars.ToList();
            }
        }
    }
}


