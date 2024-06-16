using System.ComponentModel.DataAnnotations;

namespace SailboatsApp.Models.Requests;

public class CreateReservationDto
{
    [Range(1, int.MaxValue)] public int IdClient { get; set; }

    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }

    [Range(1, int.MaxValue)] public int IdBoatStandard { get; set; }

    [Range(1, int.MaxValue)] public int NumOfBoats { get; set; }
}