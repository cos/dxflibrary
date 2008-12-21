using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class Table : DXFLibrary.Element
	{
		public Table(string type):base()
		{
			this.dataAcceptanceList.AddRange(new int[] { 0, 2, 5, 102, 360, 102, 330, 100, 70 });
			this.AddReplace(2,type);
			this.startTag = new Data(0,"TABLE");
			this.endTag = new Data(0,"ENDTAB");
		}
		public void AddTableEntry(TableEntry te)
		{
			this.AddElement(te);
		}
	}
}
