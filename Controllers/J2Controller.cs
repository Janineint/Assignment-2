using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class J2Controller : ControllerBase
    {
        
        private static readonly Dictionary<string, int> PepperSHU = new Dictionary<string, int>()
        {
            { "Poblano", 1500 },
            { "Mirasol", 6000 },
            { "Serrano", 15500 },
            { "Cayenne", 40000 },
            { "Thai", 75000 },
            { "Habanero", 125000 }
        };

        /// <summary>
        /// Calculates the total spiciness of the chili based on the peppers added.
        /// </summary>
        /// <param name="ingredients">Comma-separated list of pepper names</param>
        /// <returns>Total spiciness in SHU</returns>
        /// <example>
        /// GET: api/J2/ChiliPeppers?ingredients=Poblano,Cayenne,Thai,Poblano
        /// Response: 118000
        /// </example>
        [HttpGet("ChiliPeppers")]
        public IActionResult CalculateSpiciness([FromQuery] string ingredients)
        {
            if (string.IsNullOrWhiteSpace(ingredients))
            {
                return BadRequest("Please provide a list of ingredients.");
            }

            var peppers = ingredients.Split(',');

            
            int totalSpiciness = peppers.Sum(pepper => PepperSHU.GetValueOrDefault(pepper.Trim(), 0));

            return Ok(totalSpiciness);
        }


         /// <summary>
        /// Calculates the number of players with a star rating greater than 40
        /// and checks if the team is a gold team.
        /// </summary>
        /// <param name="totalPlayers">The total number of players on the team</param>
        /// <param name="scoresAndFouls">An array with alternating points and fouls for each player</param>
        /// <returns>The number of players with a rating greater than 40, and a "+" if the team is a gold team</returns>
        [HttpPost("FergusonballRatings")]
        public IActionResult CalculateFergusonballRatings([FromForm] int totalPlayers, [FromForm] int[] scoresAndFouls)
        {
            if (scoresAndFouls.Length != totalPlayers * 2)
            {
                return BadRequest("The number of points and fouls entries should match twice the number of players.");
            }

            int threshold = 40;
            int highRatingCount = 0;
            bool isGoldTeam = true;

            for (int i = 0; i < totalPlayers; i++)
            {
                int points = scoresAndFouls[i * 2];
                int fouls = scoresAndFouls[i * 2 + 1];
                int starRating = (points * 5) - (fouls * 3);

                if (starRating > threshold)
                {
                    highRatingCount++;
                }
                else
                {
                    isGoldTeam = false;
                }
            }

            return Ok(isGoldTeam ? $"{highRatingCount}+" : highRatingCount.ToString());
        }
    }
}
