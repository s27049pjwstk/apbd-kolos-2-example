namespace SailboatsApp.Models.Domain;

public class Client
{
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateOnly Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }

    public int IdClientCategory { get; set; }
    public ClientCategory Category { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
}