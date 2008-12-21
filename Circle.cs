using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class Circle : DXFLibrary.Entity
	{
		public Circle(double x, double y, double radius, string layer):base("CIRCLE",layer)
		{
			this.dataAcceptanceList.AddRange(new int[] { 39, 10, 20, 30, 40, 210, 220, 230 });
			this.AddReplace(10,x);
			this.AddReplace(20,y);
			this.AddReplace(40,radius);
		}
	}
}
