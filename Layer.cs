using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class Layer : DXFLibrary.TableEntry
	{
		public Layer(string name, short color, string linetype):base("LAYER")
		{
			this.dataAcceptanceList.AddRange(new int[] {2, 70, 62, 6, 290, 370, 390 });
			this.AddReplace(70,(short) 0);
			this.AddReplace(2,name);
			this.AddReplace(62,(short)color);
			this.AddReplace(6,linetype);
		}
	}
}
