using System;

namespace BeerTents.Common
{
	public class Tent : IComparable<Tent>
	{
		public int Id;
		public TentType TentType;
		public string Name;
		public string Proprietor;
		public string PhoneNumber;
		public string FaxNumber;
		public string Url;
		public string SeatingInside;
		public string SeatingOutside;
		public string Brewery;
		public string Music;
		public string Notes;
		
		public int CompareTo(Tent other)
		{
		    return Name.CompareTo(other.Name);
		}
		
		public override string ToString ()
		{
			return Name;
		}
	}
	
	public enum TentType
	{
		Big = 0,
		Small = 1
	}
}