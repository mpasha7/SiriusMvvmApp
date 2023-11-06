using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SiriusMvvmApp.Models
{
    public class CTriangle
    {
        public int PreviousNumber { get; set; }
        public int NextNumber { get; set; }
        public PointCollection Points { get; set; }
        public CTriangle(CLine line)
        {
            PreviousNumber = line.PreviousNumber;
            NextNumber = line.NextNumber;
            Points = new PointCollection();
            InitArrowhead(line);
        }

        private void InitArrowhead(CLine line)
        {
            Points.Add(new Point(line.X2, line.Y2));

            double lineLength = Math.Sqrt((line.X1 - line.X2) * (line.X1 - line.X2) + (line.Y1 - line.Y2) * (line.Y1 - line.Y2));
            double dX = Math.Abs((line.X1 - line.X2) / lineLength);
            double dY = Math.Abs((line.Y1 - line.Y2) / lineLength);

            bool flag1 = line.X2 > line.X1;
            bool flag2 = line.Y2 > line.Y1;
            double Xtmp = flag1 ? line.X2 - 10 * dX : line.X2 + 10 * dX;
            double Ytmp = flag2 ? line.Y2 - 10 * dY : line.Y2 + 10 * dY;

            double X2 = flag2 ? Xtmp + 5 * dY : Xtmp - 5 * dY;
            double Y2 = flag1 ? Ytmp - 5 * dX : Ytmp + 5 * dX;
            double X3 = flag2 ? Xtmp - 5 * dY : Xtmp + 5 * dY;
            double Y3 = flag1 ? Ytmp + 5 * dX : Ytmp - 5 * dX;

            Points.Add(new Point(X2, Y2));
            Points.Add(new Point(X3, Y3));
        }
    }
}
