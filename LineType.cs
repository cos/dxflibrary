using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class LineType : DXFLibrary.TableEntry
	{
		short nrElements;
		public LineType(string name, string description, double patternLength):base("LTYPE")
		{
			this.dataAcceptanceList.AddRange(new int[] {2, 70, 3, 72, 73, 40, 49, 74, 75, 340, 46, 50, 44, 45, 9 });
			this.AddReplace(2,name);
			this.AddData(70,(short)0);
			this.AddData(3,description);
			this.AddData(72,(short)65);
			this.nrElements = 0;
			this.AddReplace(73,this.nrElements);
			this.AddReplace(40,patternLength);
		}
		public LineType(string s):base(s,true)
		{
		}
		/// <summary>
		/// Add a simple section to the pattern. If positive, represents continuous line, if negative, represents space.
		/// </summary>
		/// <param name="length">The length of the section added</param>
		public void AddElement(double length)
		{
			this.AddData(49,length);
			this.nrElements++;
			this.AddReplace(73,this.nrElements);
		}
		/// <summary>
		/// Add a text element to the pattern.
		/// </summary>
		/// <param name="length">Dash, dot or space length</param>
		/// <param name="text">Text string</param>
		/// <param name="rotation">R = (relative) or A = (absolute) rotation value in radians of embedded text. -1000 value represents no rotation</param>
		public void AddElement(double length, string text, bool absoluteRotation, double rotation)
		{
			this.AddData(49,length);
			if(absoluteRotation)
   				this.AddData(74,(short)3);
			else
				this.AddData(74,(short)2);
			this.AddData(75,(short)0);
			this.AddData(50,rotation);
			this.AddData(9,text);
			this.nrElements++;
			this.AddReplace(73,this.nrElements);
		}
		/// <summary>
		/// Add a shape element to the pattern.
		/// </summary>
		/// <param name="length">The length of the added section to the pattern</param>
		/// <param name="shapeNumber">The SHAPE element number</param>
		/// <param name="rotation">R = (relative) or A = (absolute) rotation value in radians of embedded text. -1000 value represents no rotation</param>
		public void AddElement(double length, short shapeNumber, bool absoluteRotation, double rotation)
		{
			this.AddData(49,length);
			if(absoluteRotation) 
				this.AddData(74,(short)5);
			else
				this.AddData(74,(short)4);
			this.AddData(75,shapeNumber);
			if(rotation!=-1000)
				this.AddData(50,rotation);
			this.nrElements++;
			this.AddReplace(73,this.nrElements);
		}
	}
}
