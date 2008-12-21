using System;

namespace DXFLibrary
{
	/// <summary>
	/// Representation of a DXF header variable
	/// </summary>
	public class Variable : Element
	{
		/// <summary>
		/// Constructor for a header variable
		/// </summary>
		/// <param name="nume">The name</param>
		/// <param name="dataType">The datatype</param>
		/// <param name="val">The value</param>
		public Variable(string nume, int dataType, object val)
		{
			startTag = new Data(0,0);
			endTag = new Data(0,0);

			this.data.Add(new Data(9,nume));
			this.data.Add(new Data(dataType,val));
		}
		/// <summary>
		/// The header variable's name. Just get.
		/// </summary>
		public string VarName
		{
			get
			{
				return (string)((Data)this.data[0]).data;
			}
		}
		/// <summary>
		/// The header variable's value. Just get.
		/// </summary>
		public object Value
		{
			get
			{
				return ((Data)this.data[1]).data;
			}
		}
	}
}