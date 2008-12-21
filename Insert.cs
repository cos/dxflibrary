using System;

namespace DXFLibrary
{
	/// <summary>
	/// Representation of INSERT entity
	/// </summary>
	public class Insert : DXFLibrary.Entity
	{
		public Insert(string block, double x, double y, string layer):base("INSERT",layer)
		{
			this.dataAcceptanceList.AddRange(new int[]
				{ 66, 2, 10, 20, 30, 41, 42 ,43, 50, 70, 71, 44, 45, 210, 220, 230 } );
			this.AddData(new Data(2,block));
			this.AddData(new Data(10,x));
			this.AddData(new Data(20,y));
		}
	}
}
