using Microsoft.AspNetCore.Mvc;
using SailboatsApp.Models.Requests;
using SailboatsApp.Services.Abstractions;

namespace SailboatsApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly IReservationsService _reservationsService;

    public ReservationsController(IReservationsService reservationsService)
    {
        _reservationsService = reservationsService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateReservationAsync(CreateReservationDto request, CancellationToken cancellationToken)
    {
        try
        {
            return StatusCode(201, await _reservationsService.CreateReservationAsync(request, cancellationToken));
        }
        catch (ArgumentException exc)
        {
            return BadRequest(exc.Message);
        }
    }
}