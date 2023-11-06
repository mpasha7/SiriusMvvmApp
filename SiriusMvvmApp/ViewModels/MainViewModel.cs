using SiriusMvvmApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SiriusMvvmApp.ViewModels
{
    public class MainViewModel : DependencyObject, INotifyPropertyChanged
    {
        private Rectangle? currentRectangle = null;
        private Random rnd = new Random((int)DateTime.Now.Ticks);
        public const int SHAPE_WIDTH = 150;
        public const int SHAPE_HEIGHT = 60;

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        private ObservableCollection<CShape> _shapes;
        public ObservableCollection<CShape> Shapes
        {
            get { return _shapes; }
            set
            {
                _shapes = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CLine> _lines;
        public ObservableCollection<CLine> Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CTriangle> _triangles;
        public ObservableCollection<CTriangle> Triangles
        {
            get { return _triangles; }
            set
            {
                _triangles = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            _shapes = new ObservableCollection<CShape>();
            _lines = new ObservableCollection<CLine>();
            _triangles = new ObservableCollection<CTriangle>();
        }

        public ICommand Click_AddShapeButton
        {
            get
            {
                return new DelegateCommand((obj) =>
                {
                    CShape shape = new CShape();
                    Shapes.Add(shape);

                    CShape? previousShape = Shapes?.Where(s => s.Number < shape.Number).MaxBy(s => s.Number);
                    if (previousShape is not null)
                    {
                        CLine line = new CLine(previousShape, shape);
                        Lines.Add(line);
                        CTriangle triangle = new CTriangle(line);
                        Triangles.Add(triangle);
                    }
                });
            }
        }

        public ICommand Click_DeleteButton
        {
            get
            {
                return new DelegateCommand((obj) =>
                {

                });
            }
        }

        public ICommand Click_Canvas
        {
            get
            {
                return new DelegateCommand((obj) =>
                {

                });
            }
        }

    }
}
