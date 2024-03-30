namespace BTLONKY5.Models
{
    public class Statistics
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int TotalReservations { get; set; }
        public int TotalCustomers { get; set; }
        public int AveragePartySize { get; set; }
        public int NamRevenuee { get; set; }
        public int TotalTables { get; set; }

        public int AvailableTables { get; set; }
        public int ReservationStatusCounts { get; set; }
    }
}
