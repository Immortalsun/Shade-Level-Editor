using ShadeGameLevelEditor.Models;

namespace ShadeGameLevelEditor.ViewModel
{
    public class LevelViewModel : ViewModelBase
    {
       #region Fields

        private Level _level;

        #endregion

        #region Properties

        public string LevelImage
        {
            get { return _level.BgImage; }
            set
            {
                _level.BgImage = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Constructor

        public LevelViewModel(string bgImage)
        {
            _level = new Level();
            _level.BgImage = bgImage;
        }

        #endregion

        #region Methods

        public void BuildNewLevelPlatform(double x, double y, double width, double height)
        {
            _level.AddPlatformByCoordinates(x,y,width,height);
        }

        #endregion

        #region Events

        #endregion
    }
}
