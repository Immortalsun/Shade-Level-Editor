using ShadeGameLevelEditor.Model;

namespace ShadeGameLevelEditor.ViewModel
{
    public class PlatformViewModel : ViewModelBase
    {
        #region Fields
        private Platform _platform;
        private double _x, _y, _width, _height;
        private string _name;
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
        #endregion

        #region Constructors

        public PlatformViewModel(Platform p)
        {
            _platform = p;
        }

        public PlatformViewModel(double x, double y, double width, double height, string name)
        {
            _x = x;
            _y = y;
            _width = width;
            _height = height;
            _name = name;
        }

        #endregion

        #region Methods

        public void BuildPlatform()
        {
            _platform = new Platform(XLocation,YLocation,Width,Height);
        }

        #endregion

        #region Events

        #endregion
    }
}