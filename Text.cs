using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class Text : DXFLibrary.Entity
	{
		/// <summary>
		/// Constructor for a TEXT entity.
		/// </summary>
		/// <param name="text">The text</param>
		/// <param name="x">x coord</param>
		/// <param name="y">y coord</param>
		/// <param name="height">the height</param>
		/// <param name="layer">the layer</param>
		public Text(string text, double x, double y, double height, string layer):base("TEXT",layer)
		{
			this.dataAcceptanceList.AddRange(new int[] 
				{ 39, 10, 20, 30, 40, 1, 50, 41, 51, 7, 71, 72, 11, 21, 31, 210, 220, 230, 73} );
			this.AddReplace(10,x);
			this.AddReplace(20,y);
			this.AddReplace(1,text);
			this.AddReplace(40,height);
		}
		/// <summary>
		/// Horizontal text justification type (optional, default = 0) integer codes (not bit-coded)
		/// 0 = Left; 1= Center; 2 = Right
		/// 3 = Aligned (if vertical alignment = 0)
		/// 4 = Middle (if vertical alignment = 0)
		/// 5 = Fit (if vertical alignment = 0)
		/// See the Group 72 and 73 integer codes table for clarification
		/// </summary>
		public void SetHorizontalJustification(short flag)
		{
			this.AddReplace(72,flag);
		}
		///<summary>
		/// Vertical text justification type (optional, default = 0): integer codes (not bit-coded):
		/// 0 = Baseline; 1 = Bottom; 2 = Middle; 3 = Top
		/// See the Group 72 and 73 integer codes table for clarification
		/// </summary>
		public void SetVerticalJustification(short flag)
		{
			this.AddReplace(73,flag);
		}
		/// <summary>
		/// The secound alignament coords.
		/// </summary>
		/// <param name="x">x coord (horizontal)</param>
		/// <param name="y">y coord (vertical)</param>
		public void SetSecoundAlignament(double x, double y)
		{
			this.AddReplace(11,x);
			this.AddReplace(21,y);
		}
	}
}
