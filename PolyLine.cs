using System;

namespace DXFLibrary
{
	/// <summary>
	/// Represents a POLYLINE entity.
	/// </summary>
	public class PolyLine : DXFLibrary.Entity
	{
		/// <summary>
		/// Constructs a polyline with minimal arguments.
		/// </summary>
		/// <param name="layer">The layer</param>
		public PolyLine(string layer):base("POLYLINE",layer)
		{
			this.dataAcceptanceList.AddRange(new int[] { 66, 10, 20, 30, 39, 70, 40, 41, 71, 72, 73, 74, 75, 210, 220, 230, 66 });
			this.AddElement(new SeqEnd(layer));
			this.AddReplace(66,(short)1);
		}
		/// <summary>
		/// Adds a VERTEX the the polyline.
		/// </summary>
		/// <param name="v">The added VERTEX.</param>
		public void AddVertex(Vertex v)
		{
			this.InsertElement(this.ElementCount()-1,v);
		}
		/// <summary>
		/// Adds a vertex to the polyline useing 2D coords.
		/// </summary>
		/// <param name="x">x coord</param>
		/// <param name="y">y coord</param>
		public void AddVertex(double x, double y)
		{
			this.AddVertex(new Vertex(x,y,this.layer));
		}
	}

}
