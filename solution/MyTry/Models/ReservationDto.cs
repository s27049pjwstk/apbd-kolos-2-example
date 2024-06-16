﻿namespace MyTry.Models;

public class ReservationDto {
    public int IdReservation { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int Capacity { get; set; }
    public int NumOfBoats { get; set; }
    public bool Fulfilled { get; set; }
    public decimal? Price { get; set; }
    public string? CancelReason { get; set; }
}