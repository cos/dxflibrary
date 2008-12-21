using System;

namespace DXFLibrary
{
	/// <summary>
	/// 
	/// </summary>
	public class Style : DXFLibrary.TableEntry
	{
		public Style(string name, bool shape, double height, double width, double obliqueAngle, bool backward, bool upsidedown,double lastHeightUsed, string primaryFontFile):base("STYLE")
		{
			this.dataAcceptanceList.AddRange(new int[] { 2, 70, 40, 41, 50, 71, 42, 3, 4 });
			this.AddData(2,name);
			short c70 = 0;
			if(shape) c70+=1;
			this.AddData(70,c70);
			this.AddData(40,height);
			this.AddData(41,width);
			this.AddData(50,obliqueAngle);
			short c71 = 0;
			if(backward) c71+=2;
			if(upsidedown) c71+=4;
			this.AddData(71,c71);
			if(height==0) this.AddData(42,lastHeightUsed);
			this.AddData(3,primaryFontFile);
		}
	}
}
