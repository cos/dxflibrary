using System;

namespace DXFLibrary
{
	/// <summary>
	/// A SEQEND entity.
	/// </summary>
	public class SeqEnd : DXFLibrary.Entity
	{
		/// <summary>
		/// A SEQEND entity constructor.
		/// </summary>
		/// <param name="layer"></param>
		public SeqEnd(string layer):base("SEQEND",layer)
		{
		}
	}
}
