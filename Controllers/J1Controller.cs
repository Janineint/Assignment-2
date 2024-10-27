using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class J1 : ControllerBase
    {
        /// <summary>
        /// Calculates the final score based on deliveries and collisions.
        /// </summary>
        /// <param name="deliveries">The number of deliveries made</param>
        /// <param name="collisions">The number of collisions encountered</param>
        /// <returns>Final score as an integer</returns>
        /// <example>
        /// POST: api/J1/Delivedroid
        /// Request Body: Collisions=2&Deliveries=5
        /// </example>
        /// 

        [HttpPost("Delivedroid")]
        public IActionResult CalculateScore([FromForm] int deliveries, [FromForm] int collisions)
        {
            int score = (deliveries * 50) - (collisions * 10);
            
            if (deliveries > collisions)
            {
                score += 500;
            }

            return Ok(score);
        }

         /// <summary>
        /// Calculates the number of leftover cupcakes after distributing one to each student.
        /// </summary>
        /// <param name="regularBox">The number of regular boxes (each holding 8 cupcakes)</param>
        /// <param name="smallBox">The number of small boxes (each holding 3 cupcakes)</param>
        /// <returns>The number of cupcakes left over</returns>
        /// <example>
        /// POST: api/J1/LeftoverCupcake
        /// Request Body: regularBox=2&smallBox=5
        /// </example>
        
        [HttpPost("LeftoverCupcake")]
        public IActionResult CalculateCupcakeLeftovers([FromForm] int regularBox, [FromForm] int smallBox)
        {
            int totalCupcakes = (regularBox * 8) + (smallBox * 3);
            int leftoverCupcakes = totalCupcakes - 28;

            return Ok(leftoverCupcakes >= 0 ? leftoverCupcakes : 0); 
        }
    }
}
