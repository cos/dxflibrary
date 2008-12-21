using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class EndBlk : DXFLibrary.Element
	{
		public EndBlk()
		{
			this.dataAcceptanceList.AddRange(new int[6] 
				{ 0, 5, 8, 102, 330, 100 });
			this.startTag = new Data(0,"ENDBLK");
		}
		public EndBlk(Block b):this()
		{
			if(b.GetIndexFor(5)!=-1) this.AddData(b.GetDataFor(5));
			if(b.GetIndexFor(8)!=-1) this.AddData(b.GetDataFor(8));
		}
	}
}
