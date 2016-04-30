using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShadeGameLevelEditor.Utils
{
    public class OutlineAdorner : Adorner
    {
        #region Fields

        private VisualCollection _visuals;
        private Canvas _canvas;
        #endregion

        #region Properties

        #endregion

        #region Constructors
        public OutlineAdorner(UIElement adornedElement, Point placement, double width, double height)
            : base(adornedElement)
        {
            _visuals = new VisualCollection(this);
            var element = adornedElement as FrameworkElement;
            
            _canvas = new Canvas();
            if (element != null)
            {
                _canvas.Height = element.ActualHeight;
                _canvas.Width = element.ActualWidth;
                LoadCanvas(placement, width, height);
            }
            _visuals.Add(_canvas);
            IsHitTestVisible = false;
        }
        #endregion

        #region Methods

        private void LoadCanvas(Point placement, double width, double height)
        {
            var rect = new Rectangle();
            rect.Height = height;
            rect.Width = width;
            rect.Stroke = Brushes.OrangeRed;
            rect.StrokeDashArray = new DoubleCollection(new double[]{4,3});
            Canvas.SetTop(rect,placement.Y);
            Canvas.SetLeft(rect, placement.X);

            _canvas.Children.Add(rect);
        }

        #endregion

        #region Events
        protected override Size ArrangeOverride(Size finalSize)
        {
            _canvas.Arrange(new Rect(0, 0, finalSize.Width, finalSize.Height));
            return _canvas.RenderSize;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            _canvas.Measure(constraint);
            return _canvas.DesiredSize;
        }

        #endregion

        protected override Visual GetVisualChild(int index)
        {
            return _visuals[index];
        }

        protected override int VisualChildrenCount
        {
            get { return _visuals.Count; }
        }
    }
}