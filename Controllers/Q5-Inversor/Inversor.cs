using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luiz_Pereira.Controllers.Q5_Inversor
{
    [Route("api/[controller]")]
    [ApiController]
    public class Inversor : ControllerBase
    {
        [HttpGet("txtInversor")]
        public IActionResult InverterString([FromQuery] string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return BadRequest("A string fornecida está vazia ou é nula.");
            }

            // Invertendo a string
            string stringInvertida = "";
            for (int i = input.Length - 1; i >= 0; i--)
            {
                stringInvertida += input[i];
            }

            return Ok(new
            {
                Original = input,
                Invertida = stringInvertida
            });
        }
    }
}
