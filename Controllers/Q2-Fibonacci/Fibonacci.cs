using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luiz_Pereira.Controllers.Q2_Fibonacci
{
    [Route("api/[controller]")]
    [ApiController]
    public class Fibonacci : ControllerBase
    {
        // Função que gera a sequência de Fibonacci até o número informado
        private List<int> GenerateFibonacciSequence(int n)
        {
            List<int> fibonacciSequence = new List<int> { 0, 1 };
            while (fibonacciSequence[fibonacciSequence.Count - 1] < n)
            {
                int nextValue = fibonacciSequence[fibonacciSequence.Count - 1] + fibonacciSequence[fibonacciSequence.Count - 2];
                fibonacciSequence.Add(nextValue);
            }
            return fibonacciSequence;
        }

        // Endpoint para verificar se o número pertence à sequência de Fibonacci
        [HttpGet("checkFibonacci/{number}")]
        public IActionResult CheckFibonacciNumber(int number)
        {
            if (number < 0)
            {
                return BadRequest("Número não pode ser negativo.");
            }

            // Gerar a sequência de Fibonacci até o número informado
            List<int> fibonacciSequence = GenerateFibonacciSequence(number);

            // Verificar se o número pertence à sequência
            if (fibonacciSequence.Contains(number))
            {
                return Ok($"O número {number} pertence à sequência de Fibonacci.");
            }
            else
            {
                return Ok($"O número {number} NÃO pertence à sequência de Fibonacci.");
            }
        }
    }
}
