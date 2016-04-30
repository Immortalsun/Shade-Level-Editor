using ShadeGameLevelEditor.Model;

namespace ShadeGameLevelEditor.ViewModel
{
    public class PlatformViewModel : ViewModelBase
    {
        #region Fields

        private Platform _platform;

        #endregion

        #region Properties

        public double XLocation
        {
            get { return _platform.X; }
            set
            {
                _platform.X = value;
                OnPropertyChanged();
            }
        }

        public double YLocation
        {
            get { return _platform.Y; }
            set
            {
                _platform.Y = value;
                OnPropertyChanged();
            }
        }

        public double Height
        {
            get { return _platform.Height; }
            set
            {
                _platform.Height = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructors

        public PlatformViewModel(Platform p)
        {
            _platform = p;
        }

        #endregion

        #region Methods

        #endregion

        #region Events

        #endregion
    }
}