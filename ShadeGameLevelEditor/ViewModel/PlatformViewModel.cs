using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Documents;
using ShadeGameLevelEditor.Model;
using ShadeGameLevelEditor.Utils;

namespace ShadeGameLevelEditor.ViewModel
{
    public class PlatformViewModel : ViewModelBase
    {
        #region Fields
        private Platform _platform;
        private double _x, _y, _width, _height;
        private string _name;
        private bool _isSelected;
        private RelayCommand _selectedCommand;
        #endregion

        #region Properties

        public Platform Platform
        {
            get { return _platform; }
        }

        public double XLocation
        {
            get { return _x; }
            set
            {
                SetAndNotify(ref _x, value);
            }
        }

        public double YLocation
        {
            get { return _y; }
            set{ SetAndNotify(ref _y, value);}
        }

        public double Height
        {
            get { return _height; }
            set { SetAndNotify(ref _height, value);}
        }

        public double Width
        {
            get { return _width; }
            set { SetAndNotify(ref _width, value);}
        }

        public string Name
        {
            get { return _name; }
            set { SetAndNotify(ref _name, value);}
        }

        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetAndNotify(ref _isSelected, value); }
        }

        public RelayCommand SelectCommand
        {
            get { return _selectedCommand ?? (_selectedCommand = new RelayCommand(SelectPlatform)); }
        }
        #endregion

        #region Constructors

        public PlatformViewModel(Platform p)
        {
            _platform = p;
            _x = _platform.X;
            _y = _platform.Y;
            _height = _platform.Height;
            _width = _platform.Width;
            _name = _platform.Name;
        }

        public PlatformViewModel(double x, double y, double width, double height, string name)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _name = name;
            _platform = new Platform(x,y,width,height,name);
        }

        #endregion

        #region Methods

        public void SelectPlatform(object obj)
        {
            IsSelected = !_isSelected;

            var button = obj as Button;
            if (button == null) return;
            var layer = AdornerLayer.GetAdornerLayer(button);
            if (layer == null) return;

            if (IsSelected)
            {
                layer.Add(new ResizeAdorner(button,this));
            }
            else
            {
                var adorners = layer.GetAdorners(button);
                if (adorners != null && adorners.Any())
                {
                    foreach (var adorner in adorners)
                    {
                        layer.Remove(adorner);
                    }
                }
                UpdatePlatform();
            }
        }

        private void UpdatePlatform()
        {
            _platform.X = XLocation;
            _platform.Y = YLocation;
            _platform.Height = Height;
            _platform.Width = Width;
        }

        #endregion

        #region Events

        #endregion
    }
}