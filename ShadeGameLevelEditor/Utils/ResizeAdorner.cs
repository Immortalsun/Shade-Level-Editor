using System;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using ShadeGameLevelEditor.ViewModel;

namespace ShadeGameLevelEditor.Utils
{
    public class ResizeAdorner : Adorner
    {
        private Rect _elementRect;
        private EllipseGeometry _topLeft, _topRight, _bottomLeft, _bottomRight, _center;
        private VisualCollection _visual;
        private PlatformViewModel _resizePlatform;
        public ResizeAdorner(UIElement adornedElement, PlatformViewModel resizePlatform) : base(adornedElement)
        {
            _visual = new VisualCollection(this);
            var frameworkEle = adornedElement as FrameworkElement;
            if (frameworkEle != null)
            {
                _elementRect = new Rect(new Point(0, 0),new Size(resizePlatform.Width, 
                    resizePlatform.Height));
                _resizePlatform = resizePlatform;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            _elementRect = new Rect(new Point(0, 0), new Size(_resizePlatform.Width,
                    _resizePlatform.Height));

            if (_elementRect != null)
            {
                drawingContext.DrawRectangle(null, new Pen(Brushes.Black,1.0),_elementRect);
                _topLeft = new EllipseGeometry(_elementRect.TopLeft,6,6);
                _bottomLeft = new EllipseGeometry(_elementRect.BottomLeft,6,6);
                _topRight = new EllipseGeometry(_elementRect.TopRight,6,6);
                _bottomRight = new EllipseGeometry(_elementRect.BottomRight,6,6);
                _center = new EllipseGeometry(new Point(_elementRect.Width/2, _elementRect.Height/2),8,8);
                drawingContext.DrawGeometry(Brushes.LightSlateGray,null,_topLeft);
                drawingContext.DrawGeometry(Brushes.LightSlateGray, null, _topRight);
                drawingContext.DrawGeometry(Brushes.LightSlateGray, null, _bottomLeft);
                drawingContext.DrawGeometry(Brushes.LightSlateGray, null, _bottomRight);
                drawingContext.DrawGeometry(Brushes.OrangeRed,null,_center);
            }
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

                var delta = new Vector(pos.X - thumb.Center.X, pos.Y - thumb.Center.Y);
                if (thumb.Equals(_topLeft))
                {
                    var oldBottom = _resizePlatform.Height + _resizePlatform.YLocation;
                    var oldRight = _resizePlatform.Width+_resizePlatform.XLocation;
                    _resizePlatform.XLocation += delta.X;
                    _resizePlatform.YLocation += delta.Y;
                    _resizePlatform.Width = Math.Abs(_resizePlatform.XLocation - oldRight);
                    _resizePlatform.Height = Math.Abs(_resizePlatform.YLocation - oldBottom);
                }
                else if (thumb.Equals(_bottomLeft))
                {
                    var oldRight = _resizePlatform.Width + _resizePlatform.XLocation;
                    _resizePlatform.XLocation += delta.X;
                    _resizePlatform.Width = Math.Abs(_resizePlatform.XLocation - oldRight);
                    _resizePlatform.Height += delta.Y;
                }
                else if (thumb.Equals(_topRight))
                {
                    var oldBottom = _resizePlatform.Height + _resizePlatform.YLocation;
                    _resizePlatform.YLocation += delta.Y;
                    _resizePlatform.Width += delta.X;
                    _resizePlatform.Height = Math.Abs(_resizePlatform.YLocation - oldBottom);
                }
                else if (thumb.Equals(_bottomRight))
                {
                    _resizePlatform.Width += delta.X;
                    _resizePlatform.Height += delta.Y;
                }
                else
                {
                    _resizePlatform.XLocation += delta.X;
                    _resizePlatform.YLocation += delta.Y;
                }
                InvalidateVisual();
                
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

            if (_center.Bounds.Contains(point))
            {
                return _center;
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