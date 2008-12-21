using System;

namespace DXFLibrary
{
	/// <summary>
	/// Throws when an unexpected Element ( or derived class ) is sent to a function.
	/// </summary>
	internal class UnexpectedElement : Exception
	{
		internal UnexpectedElement():base("A fost intalnit un element Dxf nerecunoscut de aplicatie. \n Va rugam contactati serviciul de relatii cu clientii.")
		{
		}
	}
}
