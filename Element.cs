using System;
using System.Collections;

namespace DXFLibrary
{
	/// <summary>
	/// This represent an DXF element in general. "Element" is an abstrat concept introduced by us to 
	/// describe everything in DXF that contains Data ( and/or other Elements ). 
	/// Most DXF library classes are derived from this class. 
	/// Examples of classes derived from this class are SECTION, LINE, TABLE, POLYLINE, VERTEX...
	/// </summary>
	public abstract class Element
	{
		internal Data startTag = new Data(-10,0);
		internal Data endTag = new Data(-10,0);
		protected ArrayList data;
		protected ArrayList elements;
		protected ArrayList dataAcceptanceList;
		protected ArrayList elementAcceptanceList;
		internal string s;

		protected Element()
		{
			data = new ArrayList();
			elements = new ArrayList();
			dataAcceptanceList = new ArrayList();
			elementAcceptanceList = new ArrayList();
		}
		public Element(string s)  // Used for createing an element with user dxf code
		{
			this.s = s;
		}

		internal int AddElement(Element e)
		{
			if(this.IsAccepted(e)) return this.elements.Add(e);
			else throw new UnexpectedElement();
		}
		internal void InsertElement(int index, Element e)
		{
			if(this.IsAccepted(e))  this.elements.Insert(index,e);
			else throw new UnexpectedElement();
		}
		internal void RemoveElementAt(int index)
		{
			this.elements.RemoveAt(index);
		}
		internal Element GetElement(int index)
		{
			return (Element) this.elements[index];
		}
		internal int ElementCount()
		{
			return this.elements.Count;
		}

		internal int AddData(Data e)
		{
			if(this.IsAccepted(e)) return this.data.Add(e);
			else throw new UnexpectedElement();
		}
		internal void InsertData(int index, Data e)
		{
			if(this.IsAccepted(e)) this.data.Insert(index,e);
			else throw new UnexpectedElement();
		}
		internal void RemoveDataAt(int index)
		{
			this.data.RemoveAt(index);
		}
		internal Data GetData(int index)
		{
			return (Data) this.data[index];
		}
		internal int GetIndexFor(int code)
		{
			foreach(Data d in this.data)
			{
				if(d.code==code) return this.data.IndexOf(d);
			}
			return -1;
		}
		internal Data GetDataFor(int code)
		{
			foreach(Data d in this.data)
			{
				if(d.code==code) return d;
			}
			return new Data(-10,0);
		}
		internal int DataCount()
		{
			return this.data.Count;
		}

		protected bool IsAccepted(Data d) // verifica daca tipul de date ( rep prin cod dxf ) este acceptat de element
		{

			return (dataAcceptanceList.Contains(d.code)&&this.isCorectData(d));
		}
		protected bool IsAccepted(Element e)
		{
			return true; // DEBUG : trebuie modificat
		//	return elementAcceptanceList.Contains(e);
		}
		protected bool isCorectData(Data d) // Verifica daca tipul datei corespunde cu codul acesteia
		{
			if(d.code>=290 && d.code<=299) 
				if(d.data.GetType().ToString()=="System.Boolean") return true;
				else return false;
			if((d.code>=60 && d.code<=79)||(d.code>=270 && d.code<=289)||(d.code>=370 && d.code<=389)||(d.code>=170 && d.code<=179))
				if(d.data.GetType().ToString()=="System.Int16") return true;
				else return false;
			if((d.code>=90 && d.code<=99)||(d.code == 1071))
				if(d.data.GetType().ToString()=="System.Int32") return true;
				else return false;
			if((d.code>=10 && d.code<=59)||(d.code>=110 && d.code<=149)||(d.code>=210 && d.code<=239)||(d.code>=1010 && d.code<=1059))
				if(d.data.GetType().ToString()=="System.Double") return true;
				else return false;
			if(d.code==100 || d.code==102 ||d.code==105 || d.code==999 || (d.code>=300 && d.code<=369)||(d.code>=390 && d.code<=399)||(d.code>=410 && d.code<=419))
				if((d.data.GetType().ToString()=="System.String")&&((string) d.data).Length <=255) return true;
				else return false;
			if((d.code>=0 && d.code<=9) || (d.code>=1000 && d.code <=1009))
				if(d.data.GetType().ToString()=="System.String") return true;
				else return false;
			return false;
		}

		public string Name
		{
			get
			{
				return ((Data)this.data[0]).data.ToString();
			}
		}
		public void AddReplace(int cod, object o)
		{
			int ind = this.GetIndexFor(cod);
			if(ind==-1) this.AddData(new Data(cod,o));
			else
			{
				this.data.RemoveAt(ind);
				this.InsertData(ind,new Data(cod,o));
			}
		}
		public void AddData(int cod, object o)
		{
			this.AddData(new Data(cod,o));
		}
	}
}
