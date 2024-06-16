using Microsoft.AspNetCore.Mvc;
using SailboatsApp.Services.Abstractions;

namespace SailboatsApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IClientsService _clientsService;

    public ClientsController(IClientsService clientsService)
    {
        _clientsService = clientsService;
    }

    [HttpGet("{idClient}")]
    public async Task<IActionResult> Get(int idClient, CancellationToken cancellationToken)
    {
        try
        {
            return Ok(await _clientsService.GetClientAsync(idClient, cancellationToken));
        }
        catch (ArgumentException exc)
        {
            return BadRequest(exc.Message);
        }
    }
}