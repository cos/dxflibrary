using System;
using System.Collections;

namespace DXFLibrary
{
	/// <summary>
	/// The representation of a DXF SECTION
	/// </summary>
	public class Section : Element
	{

		public Section(string s) : base()
		{
			startTag = new Data(0,"SECTION");
			endTag = new Data(0,"ENDSEC");

			data = new ArrayList();
			elements = new ArrayList();
			data.Add(new Data(2,s));
		}
		public Section(string s, bool userDxfCode):base(s)
		{
		}
	}
}
