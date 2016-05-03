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

        public Level CurrentLevel
        {
            get { return _level; }
        }

        public string LevelBackground
        {
            get { return _level.BgImage; }
            set
            {
                _level.BgImage = value;
                OnPropertyChanged();
            }
        }

        public string LevelForeground
        {
            get { return _level.FgImage; }
            set
            {
                _level.FgImage = value;
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

        public LevelViewModel(string bgImage, string fgImage)
        {
            _level = new Level();
            _level.BgImage = bgImage;
            _level.FgImage = fgImage;
            _platforms = new List<PlatformViewModel>();
        }

        public LevelViewModel(Level level)
        {
            _level = level;
            BuildPlatformViewModels();
        }

        #endregion

        #region Methods

        public void BuildNewLevelPlatform(double x, double y, double width, double height)
        {
            var platformsList = new List<PlatformViewModel>(_platforms);
            var newPlatform = new PlatformViewModel(x, y, width, height, platformsList.Count.ToString());
            platformsList.Add(newPlatform);
            _level.AddPlatformByBlock(newPlatform.Platform);
            Platforms = platformsList;
        }

        public void RemovePlatform(PlatformViewModel p)
        {
            var platformsList = new List<PlatformViewModel>(_platforms);
            platformsList.Remove(p);
            Platforms = platformsList;
        }

        private void BuildPlatformViewModels()
        {
            if (_level != null)
            {
                var platformList = new List<PlatformViewModel>();
                foreach (var platform in _level.Platforms)
                {
                    platformList.Add(new PlatformViewModel(platform));
                }
                Platforms = platformList;
            }
        }

        public void BuildLevel()
        {
            foreach (var platform in Platforms)
            {
                _level.Platforms.Add(platform.Platform);
            }
        }

        #endregion

        #region Events

        #endregion
    }
}
