using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ShadeGameLevelEditor.Utils
{
    public class ResizeAdorner : Adorner
    {
        private Rect _elementRect;
        private EllipseGeometry _topLeft, _topRight, _bottomLeft, _bottomRight;
        private VisualCollection _visual;
        public ResizeAdorner(UIElement adornedElement) : base(adornedElement)
        {
            _visual = new VisualCollection(this);
            var frameworkEle = adornedElement as FrameworkElement;
            if (frameworkEle != null)
            {
                _elementRect = new Rect(new Point(0, 0),new Size(frameworkEle.ActualWidth, 
                    frameworkEle.ActualHeight));
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (_elementRect != null)
            {
                drawingContext.DrawRectangle(null, new Pen(Brushes.Black,1.0),_elementRect);
                _topLeft = new EllipseGeometry(_elementRect.TopLeft,6,6);
                _bottomLeft = new EllipseGeometry(_elementRect.BottomLeft,6,6);
                _topRight = new EllipseGeometry(_elementRect.TopRight,6,6);
                _bottomRight = new EllipseGeometry(_elementRect.BottomRight,6,6);

                drawingContext.DrawGeometry(Brushes.LightSlateGray,null,_topLeft);
                drawingContext.DrawGeometry(Brushes.LightSlateGray, null, _topRight);
                drawingContext.DrawGeometry(Brushes.LightSlateGray, null, _bottomLeft);
                drawingContext.DrawGeometry(Brushes.LightSlateGray, null, _bottomRight);
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var pos = e.GetPosition(this);
            if (Mouse.LeftButton == MouseButtonState.Pressed)
            {
                var thumb = GetThumb(pos);
                if (thumb == null)
                {
                    e.Handled = false;
                    return;
                }

                if (thumb.Equals(_topLeft))
                {

                }
            }
        }

        private EllipseGeometry GetThumb(Point point)
        {
            if (_topLeft.Bounds.Contains(point))
            {
                return _topLeft;
            }

            if (_topRight.Bounds.Contains(point))
            {
                return _topRight;
            }

            if (_bottomLeft.Bounds.Contains(point))
            {
                return _bottomLeft;
            }

            if (_bottomRight.Bounds.Contains(point))
            {
                return _bottomRight;
            }

            return null;
        }

        protected override Visual GetVisualChild(int index)
        {
            return _visual[index];
        }

        protected override int VisualChildrenCount
        {
            get { return _visual.Count; }
        }
    }
}