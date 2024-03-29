using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class BillInfo
{
		[Key]
		public int ID {  get; set; }
		public int IDBill { get; set; }
		public int IDFood { get; set; }
		public float Amount { get; set; }
}
