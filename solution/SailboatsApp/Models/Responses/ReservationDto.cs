namespace SailboatsApp.Models.Responses;

public class ReservationDto
{
    public int IdReservation { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public decimal Price { get; set; }
    public string? CancelReason { get; set; }
}