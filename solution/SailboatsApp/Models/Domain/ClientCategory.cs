namespace SailboatsApp.Models.Domain;

public class ClientCategory
{
    public int IdCategory { get; set; }
    public string Name { get; set; }
    public int DiscountPerc { get; set; }
    public decimal DiscountDec => DiscountPerc / 100;

    public ICollection<Client> Clients { get; set; }
}