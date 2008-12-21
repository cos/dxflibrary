namespace DXFLibrary
{
	/// <summary>
	/// The smallest but the most used part of C#DXFLibrary. It represents a piece of data in a dxf file. 
	/// It contains a dxf code and an information ( string, int,... )
	/// </summary>
	public struct Data
	{
		public int code;
		public object data;
		public Data(int code, object data)
		{
			this.code = code;
			this.data = data;
		}
	}
}