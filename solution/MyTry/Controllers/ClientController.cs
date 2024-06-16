using Microsoft.AspNetCore.Mvc;
using MyTry.Services;

namespace MyTry.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController(IClientsService _clientsService) : ControllerBase {

    [HttpGet("{idClient:int}")]
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