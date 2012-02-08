using System;

namespace DXFLibrary
{
    /// <summary>
    /// The representation of LINE entity.
    /// </summary>
    public class Line3D : DXFLibrary.Entity
    {
        public Line3D(string layer, double xi, double yi, double zi, double xf, double yf, double zf)
            : base("LINE", layer)
        {
            this.dataAcceptanceList.AddRange(new int[10] { 39, 10, 20, 30, 11, 21, 31, 210, 220, 230 });
            this.AddReplace(10, xi);
            this.AddReplace(20, yi);
            this.AddReplace(30, zi);
            this.AddReplace(11, xf);
            this.AddReplace(21, yf);
            this.AddReplace(31, zf);
        }

        public void setInitialPoint(double x, double y, double z)
        {
            this.AddReplace(10, x);
            this.AddReplace(20, x);
            this.AddReplace(30, z);
        }
        public void setFinalPoint(double x, double y, double z)
        {
            this.AddReplace(11, x);
            this.AddReplace(21, x);
            this.AddReplace(31, z);
        }
    }
}
