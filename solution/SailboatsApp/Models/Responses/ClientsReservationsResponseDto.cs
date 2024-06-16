namespace SailboatsApp.Models.Responses;

public class ClientsReservationsResponseDto
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }

    public IEnumerable<ReservationDto> Reservations { get; set; }
}