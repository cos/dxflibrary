using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class TableEntry : DXFLibrary.Element
	{
		internal TableEntry(string type):base()
		{
			this.dataAcceptanceList.AddRange(new int[] {0, 5, 105, 102, 330, 360, 100 });
			this.startTag = new Data(0,type);
		}
		internal TableEntry(string dxfcode, bool withDxfCode):base(dxfcode)
		{
		}
	}
}
