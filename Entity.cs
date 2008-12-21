using System;

namespace DXFLibrary
{
	/// <summary>
	/// Representation of an enetity in DXF ( in general ). The class is refined trough derivation.
	/// </summary>
	public abstract class Entity : DXFLibrary.Element
	{
		public Entity(string name, string layer):base()
		{
			this.dataAcceptanceList.AddRange(new int[] 
				{ 0 , 5 , 102 , 330 , 360 , 100 , 67 , 410 , 8 , 6 , 62 , 370 , 48 , 60 , 92 , 310} );
			this.startTag = new Data(0,name);
			this.AddData(new Data(8, layer));
		}

		public string layer
		{
			get
			{
				return (string)(this.GetDataFor(8)).data;
			}
			set
			{
				this.AddReplace(8,s);
			}
		}
	}
}
