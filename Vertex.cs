using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class Vertex : DXFLibrary.Entity
	{
		/// <summary>
		/// Construtor for a VERTEX entity.
		/// </summary>
		/// <param name="x">The x coord</param>
		/// <param name="y">The y coord</param>
		/// <param name="layer">The layer</param>
		public Vertex(double x, double y, string layer):base("VERTEX",layer)
		{
			this.dataAcceptanceList.AddRange(new int[] { 10, 20, 30, 70, 40, 41, 42, 50, 71, 72, 73, 74,  });
			this.AddReplace(10,x);
			this.AddReplace(20,y);
		}
	}
}
