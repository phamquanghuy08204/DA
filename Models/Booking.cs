using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Booking
{

		[Key]
		public int ID {  get; set; }
		public int IDTable { get; set; }
		public int IDAccount { get; set; }
		public int IDFood { get; set; }


}
