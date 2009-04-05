using System;
using System.Collections.Generic;
using System.Text;

namespace DXFLibrary 
{
    class Arc : DXFLibrary.Entity
    {
		public Arc(double x, double y, double radius, double startAngle, double endAngle, string layer):base("ARC",layer)
		{
			this.dataAcceptanceList.AddRange(new int[] { 39, 10, 20, 30, 40, 100, 50, 51, 210, 220, 230 });
			this.AddReplace(10, x);
			this.AddReplace(20, y);
			this.AddReplace(40, radius);
            this.AddReplace(50, startAngle);
            this.AddReplace(51, endAngle);
		}
    }
}