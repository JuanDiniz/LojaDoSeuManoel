using Microsoft.AspNetCore.Mvc;
using LojaDoSeuManoel.Models;
using LojaDoSeuManoel.Services;

namespace LojaDoSeuManoel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmbalagemController : ControllerBase
{
    private readonly EmbalagemService _embalagemService;

    public EmbalagemController()
    {
        _embalagemService = new EmbalagemService();
    }

    [HttpPost]
    public IActionResult Post([FromBody] EntradaPedidos entrada)
    {
        if (entrada == null || entrada.pedidos == null || !entrada.pedidos.Any())
        {
            return BadRequest("A lista de pedidos está vazia ou nula.");
        }

        var resultado = _embalagemService.CalcularEmbalagem(entrada.pedidos);
        return Ok(new SaidaPedidos { pedidos = resultado });
    }
}