using Luiz_Pereira.Model.Faturamento;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luiz_Pereira.Controllers.Q3_Faturamento
{
    [Route("api/[controller]")]
    [ApiController]
    public class Faturamento : ControllerBase
    {
        [HttpPost("calcFaturamento")]
        public IActionResult CalcularFaturamento([FromBody] List<DiaValor> faturamentoDiario)
        {
            try
            {
                // Filtrar dias com faturamento maior que 0
                var diasComFaturamento = faturamentoDiario.Where(d => d.Valor > 0).ToList();

                if (!diasComFaturamento.Any())
                {
                    return BadRequest("Nenhum dia com faturamento válido encontrado.");
                }

                // Calcular menor valor de faturamento
                double menorValor = diasComFaturamento.Min(d => d.Valor);

                // Calcular maior valor de faturamento
                double maiorValor = diasComFaturamento.Max(d => d.Valor);

                // Calcular média mensal de faturamento
                double mediaMensal = diasComFaturamento.Average(d => d.Valor);

                // Número de dias com faturamento acima da média
                int diasAcimaDaMedia = diasComFaturamento.Count(d => d.Valor > mediaMensal);

                // Retorna os resultados
                return Ok(new
                {
                    MenorValor = menorValor,
                    MaiorValor = maiorValor,
                    MediaMensal = mediaMensal,
                    DiasAcimaDaMedia = diasAcimaDaMedia
                });
            }
            catch (Exception ex)
            {
                // Tratar erros genéricos
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }
    }
}
