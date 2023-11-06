using SiriusMvvmApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SiriusMvvmApp.Models
{
    public class CLine
    {
        public int PreviousNumber { get; set; }
        public int NextNumber { get; set; }
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }

        public CLine(CShape previousShape, CShape nextShape)
        {
            PreviousNumber = previousShape.Number;
            NextNumber = nextShape.Number;
            InitLine(previousShape, nextShape);
        }

        private void InitLine(CShape previousShape, CShape nextShape)
        {
            double newX = nextShape.Left + MainViewModel.SHAPE_WIDTH / 2;
            double newY = nextShape.Top + MainViewModel.SHAPE_HEIGHT / 2;
            double previousX = previousShape.Left + MainViewModel.SHAPE_WIDTH / 2;
            double previousY = previousShape.Top + MainViewModel.SHAPE_HEIGHT / 2;

            bool flag1 = newY >= previousY;
            bool flag2 = newX >= previousX;
            bool flag3 = Math.Abs((newX - previousX) / (newY - previousY)) < MainViewModel.SHAPE_WIDTH / MainViewModel.SHAPE_HEIGHT;
            if (flag1 && flag3)
            {
                X1 = previousX;
                Y1 = previousShape.Top + MainViewModel.SHAPE_HEIGHT;
                X2 = newX;
                Y2 = nextShape.Top;
            }
            else if (!flag1 && flag3)
            {
                X1 = previousX;
                Y1 = previousShape.Top;
                X2 = newX;
                Y2 = nextShape.Top + MainViewModel.SHAPE_HEIGHT;
            }
            else if (flag2 && !flag3)
            {
                X1 = previousShape.Left + MainViewModel.SHAPE_WIDTH;
                Y1 = previousY;
                X2 = nextShape.Left;
                Y2 = newY;
            }
            else if (!flag2 && !flag3)
            {
                X1 = previousShape.Left;
                Y1 = previousY;
                X2 = nextShape.Left + MainViewModel.SHAPE_WIDTH;
                Y2 = newY;
            }
        }
    }
}
