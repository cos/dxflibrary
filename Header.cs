using System;
using System.Collections;

namespace DXFLibrary
{
	/// <summary>
	/// The representation of DXF header section
	/// </summary>
	public class Header : Section
	{
		internal Header() : base("HEADER")
		{
		}
		public int VariableCount()
		{
			return this.elements.Count;
		}
		public Variable getVariable(int index)
		{
			return (Variable)this.elements[index];
		}
		public object valueOf(string varName)
		{
			foreach(Variable v in this.elements)
			{
				if(v.VarName == varName) return v.Value;
			}
			return null;
		}
		public void addVariable(Variable v)
		{
			this.elements.Add(v);
		}
	}
}
