using System;
using System.Collections;

namespace DXFLibrary
{
	/// <summary>
	/// The representation of a dxf document.
	/// </summary>
	public class Document
	{
		internal Header header;
		internal Entities entities;
		internal Blocks blocks;
		internal Tables tables;
		public Document()
		{
			this.entities = new Entities();
		}
		public void SetHeader(Header h)
		{
			this.header = h;
		}
		public void SetEntities(Entities e)
		{
			this.entities = e;
		}
		public void SetBlocks(Blocks b)
		{
			this.blocks = b;
		}
		public void SetTables(Tables t)
		{
			this.tables = t;
		}
		public void add(Entity e)
		{
			this.entities.AddEntity(e);
		}
		public void add(Block b)
		{
			this.blocks.addBlock(b);
		}
	}
}
