using System;

namespace DXFLibrary
{
	/// <summary>
	/// Representation of DXF tables section.
	/// </summary>
	public class Tables : DXFLibrary.Section
	{
		/// <summary>
		/// Constructot for the TABLES section.
		/// </summary>
		public Tables() : base("TABLES")
		{
		}
		/// <summary>
		/// Adds a table to the TABLES section.
		/// </summary>
		/// <param name="t"></param>
		public void addTable(Table t)
		{
			this.AddElement(t);
		}
	}
}
