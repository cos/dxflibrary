using System;

namespace DXFLibrary
{
	/// <summary>
	/// A dxf BLOCK element.
	/// </summary>
	public class Block : DXFLibrary.Element
	{
		/// <summary>
		/// Constructor for block
		/// </summary>
		public Block():base()
		{
			this.dataAcceptanceList.AddRange(new int[14] 
				{ 0, 5, 102, 330, 100, 8, 70,10 ,20 ,30 ,3, 1, 4, 2});
			this.startTag = new Data(0,"BLOCK");
		}
		/// <summary>
		/// Used to create an BLOCK with user dxf code.
		/// </summary>
		/// <param name="s">Contains the DXF code that will be writen directly to the dxf file</param>
		public Block(string s):base(s)
		{
		}
		public void SetEndBlk(EndBlk eb) 
		{
			if(this.elements.Count>0&&((Element)this.elements[this.elements.Count-1]).Name == "ENDBLK")
			{
				this.elements.RemoveAt(this.data.Count-1);
			}
			this.elements.Add(eb);
		}
		/// <summary>
		/// Add an dxf entity to a BLOCK
		/// </summary>
		/// <param name="e">The added entity</param>
		public void AddEntity(Entity e)
		{
			if(this.data.Count==0) this.elements.Add(e);
			else this.elements.Insert(this.elements.Count-1,e);
		}
		/// <summary>
		/// Specifies the layer for the block.
		/// </summary>
		/// <param name="l"></param>
		public void SetLayer(string l)
		{
			int ind = this.GetIndexFor(8);
			if(ind>-1)
			{
				this.data.RemoveAt(ind);
				this.data.Insert(ind,new Data(8,l));
			}
			else
				this.data.Add(new Data(8,l));
		}
		public void SetPosition(double x, double y, double z)
		{
			Data dx,dy,dz;
			bool swx = false,swy = false,swz = false;
			foreach(Data d in this.data)
			{
				if(d.code==10) 
				{
					dx = d;
					swx = true;
				}
				if(d.code==20) 
				{
					dy = d;
					swy=true;
				}
				if(d.code==30) 
				{
					dz = d;
					swz = true;
				}
			}
			if(swx) dx.data = x;
			else
			{
				dx.code = 10;
				dx.data = x;
				this.data.Add(dx);
			}
			if(swy) dy.data = y;
			else
			{
				dy.code = 20;
				dy.data = y;
				this.data.Add(dy);
			}
			if(swz) dz.data = z;
			else
			{
				dy.code = 30;
				dy.data = y;
				this.data.Add(dy);
			}
		}
		/// <summary>
		/// Sets the block name.
		/// </summary>
		/// <param name="name">Contains the name.</param>
		public void SetName(string name)
		{
			this.AddReplace(2,name);
		}
		/// <summary>
		/// Sets the handle for the block.
		/// </summary>
		/// <param name="handle">The handle value</param>
		public void SetHandle(string handle)
		{
			this.AddReplace(5,handle);
		}
		public void SetFlag(short flag)
		{
			this.AddReplace(70,flag);
		}
	}
}
