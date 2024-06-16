namespace MyTry.Models;

public class ClientDto {
    public int IdClient { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string Pesel { get; set; }
    public string Email { get; set; }
    public ICollection<ReservationDto> Reservations { get; set; }

}