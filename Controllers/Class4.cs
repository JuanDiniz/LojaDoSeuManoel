using System;

// EmbalagemController.cs
[ApiController]
[Route("api/[controller]")]
public class EmbalagemController : ControllerBase
{
    private readonly EmbalagemService _service;

    public EmbalagemController()
    {
        _service = new EmbalagemService();
    }

    [HttpPost]
    public IActionResult Post([FromBody] List<Pedido> pedidos)
    {
        var resultado = _service.CalcularEmbalagem(pedidos);
        return Ok(resultado);
    }
}