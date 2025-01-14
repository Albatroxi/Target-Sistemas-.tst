using Luiz_Pereira.Model.Percentual;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luiz_Pereira.Controllers.Q4_Percentual
{
    [Route("api/[controller]")]
    [ApiController]
    public class Percentual : ControllerBase
    {
        [HttpPost("calcPercentual")]
        public IActionResult CalcularPercentual([FromBody] List<EstadoFaturamento> faturamentoEstados)
        {
            try
            {
                // Validação: verificar se os dados são válidos
                if (faturamentoEstados == null || !faturamentoEstados.Any())
                {
                    return BadRequest("Nenhum dado de faturamento fornecido.");
                }

                // Calcular o valor total
                double totalFaturamento = faturamentoEstados.Sum(f => f.Valor);

                if (totalFaturamento <= 0)
                {
                    return BadRequest("O faturamento total deve ser maior que zero.");
                }

                // Calcular o percentual de cada estado
                var percentuais = faturamentoEstados.Select(f => new
                {
                    Estado = f.Estado,
                    Valor = f.Valor,
                    Percentual = Math.Round((f.Valor / totalFaturamento) * 100, 2)
                });

                // Retorna os percentuais calculados
                return Ok(new
                {
                    TotalFaturamento = totalFaturamento,
                    Percentuais = percentuais
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
