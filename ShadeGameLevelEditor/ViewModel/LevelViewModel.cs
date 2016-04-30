using System.Collections.Generic;
using ShadeGameLevelEditor.Models;

namespace ShadeGameLevelEditor.ViewModel
{
    public class LevelViewModel : ViewModelBase
    {
       #region Fields

        private Level _level;
        public List<PlatformViewModel> _platforms;
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

        public List<PlatformViewModel> Platforms
        {
            get { return _platforms; }
            set
            {
               SetAndNotify(ref _platforms,value);
            }
        }
        #endregion

        #region Constructor

        public LevelViewModel(string bgImage)
        {
            _level = new Level();
            _level.BgImage = bgImage;
            _platforms = new List<PlatformViewModel>();
        }

        #endregion

        #region Methods

        public void BuildNewLevelPlatform(double x, double y, double width, double height)
        {
            var platformsList = new List<PlatformViewModel>(_platforms);
            platformsList.Add(new PlatformViewModel(x,y,width,height,platformsList.Count.ToString()));
            Platforms = platformsList;
        }

        public void RemovePlatform(PlatformViewModel p)
        {
            var platformsList = new List<PlatformViewModel>(_platforms);
            platformsList.Remove(p);
            Platforms = platformsList;
        }

        #endregion

        #region Events

        #endregion
    }
}
