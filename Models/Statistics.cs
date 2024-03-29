using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Statistics
{
    [Key]
    public int ID { get; set; }
    public string Date { get; set; }
    public int TotalReservations { get; set; }
    public int TotalCustomers { get; set; }
    public int AveragePartySize { get; set; }
    public int Revenue { get; set; }
    public int TotalTables { get; set; }
    public int AvailableTables { get; set; }
    public int ReservationStatusCounts { get; set; }

}
