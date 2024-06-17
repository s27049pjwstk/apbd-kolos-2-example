using Microsoft.AspNetCore.Mvc;
using MyTry.Models;
using MyTry.Services;

namespace MyTry.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController(IReservationService reservationService) : ControllerBase {
    [HttpPost]
    public async Task<IActionResult> Get(ReservationPostDto request, CancellationToken cancellationToken) {
        try {
            return StatusCode(201, await reservationService.CreateReservationAsync(request, cancellationToken));
        } catch (ArgumentException exc) {
            return BadRequest(exc.Message);
        }
    }
}