using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Diagnostics.Metrics;
using System.Windows.Media;

namespace SiriusMvvmApp.Models
{
    public class CShape
    {
        private readonly Random rnd = new Random((int)DateTime.Now.Ticks);
        public const int SHAPE_WIDTH = 150;
        public const int SHAPE_HEIGHT = 60;
        public const int CANVAS_WIDTH = 1600 - SHAPE_WIDTH;
        public const int CANVAS_HEIGHT = 750 - SHAPE_HEIGHT;
        private static int counter = 1;
        public int Number { get; set; }

        public int Left { get; set; }
        public int Top { get; set; }
        public string Text { get; set; }
        public Brush BorderBrush { get; set; }

        public CShape()
        {
            Left = rnd.Next(CANVAS_WIDTH);
            Top = rnd.Next(CANVAS_HEIGHT);
            Text = $"Shape {counter}";
            Number = counter;
            counter++;
            byte[] color = new byte[] { (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255) };
            BorderBrush = new SolidColorBrush(Color.FromRgb(color[0], color[1], color[2]));
        }


    }
}
