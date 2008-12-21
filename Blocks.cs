using System;

namespace DXFLibrary
{
	/// <summary>
	/// The representation of BLOCKS section
	/// </summary>
	public class Blocks : DXFLibrary.Section
	{
		public Blocks():base("BLOCKS")
		{
			// 
			// TODO: Add constructor logic here
			//
		}
		public Blocks(string s):base(s,true)
		{
		}
		public void addBlock(Block b)
		{
			this.elements.Add(b);
		}
	}
}
