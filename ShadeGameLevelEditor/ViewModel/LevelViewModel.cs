using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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

        #endregion

        #region Events

        #endregion
    }
}
