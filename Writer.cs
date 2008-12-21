using System;
using System.IO;
using System.Globalization;

namespace DXFLibrary
{
	/// <summary>
	/// This class is used to write a dxf document to a stream
	/// </summary>
	public class Writer
	{
		/// <summary>
		/// Inplicit constructor for Writer
		/// </summary>
		public Writer()
		{
		}
		/// <summary>
		/// Method for writeing a Document into a stream.
		/// </summary>
		/// <param name="d">The document</param>
		/// <param name="s">The stream</param>
		public static void Write(Document d, Stream s)
		{
			StreamWriter sr = new StreamWriter(s);

			WriteHeader(d.header,sr);
			WriteTables(d.tables,sr);
			WriteBlocks(d.blocks,sr);
			WriteEntities(d.entities,sr);

			WriteData(new Data(0,"EOF"),sr);
			sr.Close();
		}
		private static void WriteHeader(Header h,StreamWriter sr)
		{
			if(h==null) return;
			WriteElement(h,sr);
		}
		private static void WriteEntities(Entities e, StreamWriter sr)
		{
			if(e==null) return;
			WriteElement(e,sr);
		}
		private static void WriteBlocks(Blocks b, StreamWriter sr)
		{
			if(b==null) return;
			WriteElement(b,sr);
		}
		private static void WriteTables(Tables t, StreamWriter sr)
		{
			if(t==null) return;
			WriteElement(t,sr);
		}
		private static void WriteElement(Element e, StreamWriter sr)
		{
			if(e==null) return;
			if(e.s!=null) 
			{
				sr.Write(e.s);
				return;
			}
			WriteData(e.startTag,sr);
			for(int i=0;i<e.DataCount();i++)
			{
				WriteData(e.GetData(i),sr);
			}
			for(int i=0;i<e.ElementCount();i++)
				WriteElement(e.GetElement(i),sr);
			WriteData(e.endTag,sr);
		}
		private static void WriteData(Data d, StreamWriter sr)
		{
			if(d.code == -10) return;
			sr.Write(d.code);
			sr.Write("\n");
			if(d.data.GetType().ToString()=="System.Double")
				sr.Write(((double)d.data).ToString(CultureInfo.InvariantCulture));
			else
				sr.Write(d.data);
			sr.Write("\n");
		}
	}
}
