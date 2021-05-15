using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
      

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sum/{firstnumber}/{secondnumber}")]
        public IActionResult Get(string firstnumber, string secondnumber)
        {
            if (isNumeric(firstnumber) && isNumeric(secondnumber))
            {
                var sum = Convert.ToDecimal(firstnumber) + Convert.ToDecimal(secondnumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid Request");

        }

        private bool isNumeric(string strNumber)
        {
            double number;
            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out number);
            return isNumber;

            throw new NotImplementedException();
        }
    }
}
