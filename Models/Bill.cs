using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Bill
{

		[Key]
		public int ID { get; set; }
		public string DateCheckin { get; set; }
		public string DateCheckout { get; set; }
		public int IDBooking { get; set; } 
		public int TotalAmount { get; set; }
		public int IDAccount { get; set; }


}
