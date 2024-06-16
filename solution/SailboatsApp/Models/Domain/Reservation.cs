namespace SailboatsApp.Models.Domain;

public class Reservation
{
    public int IdReservation { get; set; }
    public int IdClient { get; set; }
    public DateOnly DateFrom { get; set; }
    public DateOnly DateTo { get; set; }
    public int IdBoatStandard { get; set; }
    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public decimal Price { get; set; }
    public string? CancelReason { get; set; }
    public Client Client { get; set; }
    public BoatStandard Standard { get; set; }
    public ICollection<Sailboat> AssignedSailboats { get; set; } = new List<Sailboat>();
}