namespace SailboatsApp.Models.Domain;

public class Sailboat
{
    public int IdSailboat { get; set; }
    public string Name { get; set; }
    public int Capacity { get; set; }
    public string Description { get; set; }
    public int IdBoatStandard { get; set; }
    public decimal Price { get; set; }

    public BoatStandard BoatStandard { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}