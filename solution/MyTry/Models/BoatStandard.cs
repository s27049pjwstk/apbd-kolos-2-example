namespace MyTry.Models;

public class BoatStandard {
    public int IdBoatStandard { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public ICollection<Sailboat> Sailboats { get; set; }
}