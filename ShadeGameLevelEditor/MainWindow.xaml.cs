using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using ShadeGameLevelEditor.ViewModel;

namespace ShadeGameLevelEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EditorViewModel _viewModel;
        private bool _drawingRect;
        private const double _minWidth = 16.0;
        private const double _minHeight = 16.0;
        private Point? _dragOrigin, _dragStop;
        public MainWindow()
        {
            _viewModel = new EditorViewModel();
            DataContext = _viewModel;
            InitializeComponent();
        }

        private void DrawCanvas_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragOrigin = e.GetPosition(DrawCanvas);
        }

        private void DrawCanvas_OnPreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            _viewModel.Zoom(e.Delta);
        }

        private void DrawCanvas_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed && _dragOrigin != null)
            {
                var currentPos = e.GetPosition(DrawCanvas);

                if (Math.Abs(currentPos.X - _dragOrigin.Value.X) >= _minWidth &&
                    Math.Abs(currentPos.Y - _dragOrigin.Value.Y) >= _minHeight)
                {
                    _dragStop = currentPos;
                    _drawingRect = true;
                    DrawPlatformOutline();
                    e.Handled = true;
                }
            }
            else
            {
                _drawingRect = false;
                e.Handled = false;
            }
        }

        private void DrawPlatformOutline()
        {
            ClearOutline();
            DrawCanvas.Children.Add(DrawRectangle(true));
        }

        private void ClearOutline()
        {
            List<UIElement> outlines = new List<UIElement>();

            outlines.AddRange(DrawCanvas.Children.Cast<Rectangle>().Where(n => n.StrokeDashArray.Count > 0));
            foreach (var outline in outlines)
            {
                DrawCanvas.Children.Remove(outline);
            }
        }

        private void DrawCanvas_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_drawingRect && _dragOrigin != null && _dragStop != null)
            {
                ClearOutline();
                DrawCanvas.Children.Add(DrawRectangle(false));
            }

            _dragOrigin = null;
            _dragStop = null;
            _drawingRect = false;
            e.Handled = true;
        }

        private Rectangle DrawRectangle(bool isOutline)
        {
            var platformRect = new Rectangle();
            if (isOutline)
            {
                platformRect.Stroke = new SolidColorBrush(Colors.OrangeRed);
                platformRect.StrokeDashArray = new DoubleCollection(new double[]{4,3});
            }
            else
            {
                platformRect.Fill = new SolidColorBrush(Colors.LawnGreen);
            }

            platformRect.Width = Math.Abs(_dragOrigin.Value.X - _dragStop.Value.X);
            platformRect.Height = Math.Abs(_dragOrigin.Value.Y - _dragStop.Value.Y);
            Canvas.SetLeft(platformRect, Math.Min(_dragOrigin.Value.X, _dragStop.Value.X));
            Canvas.SetTop(platformRect, Math.Min(_dragOrigin.Value.Y, _dragStop.Value.Y));

            return platformRect;
        }
    }
}
