using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class J3 : ControllerBase
    {
        
         /// <summary>
        /// Determines the best day(s) to hold a special event based on maximum availability of attendees.
        /// </summary>
        /// <param name="attendeeAvailabilities">A list of availability strings, where each string represents a person's availability over five days (e.g., "YY.Y.").</param>
        /// <returns>A comma-separated list of the day number(s) (1-based index) with the highest number of available attendees.</returns>
        /// <example>Example request payload: ["YY.Y.", "...Y.", ".YYY."]</example>
        /// <example>Example response: "4"</example>
        [HttpPost("specialevent")]
        public IActionResult FindBestDay([FromBody] List<string> availabilities)
        {
            if (availabilities == null || availabilities.Count == 0)
                return BadRequest("No availability data provided.");

            int[] dayCount = new int[5];

            
            foreach (var availability in availabilities)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (availability[i] == 'Y')
                    {
                        dayCount[i]++;
                    }
                }
            }

            
            int maxAttendees = dayCount.Max();

            
            var bestDays = Enumerable.Range(1, 5)
                                      .Where(i => dayCount[i - 1] == maxAttendees)
                                      .ToList();

            
            return Ok(string.Join(",", bestDays));
        }
    }
}
