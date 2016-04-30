using System;
using Microsoft.Win32;
using ShadeGameLevelEditor.Utils;

namespace ShadeGameLevelEditor.ViewModel
{
    public class EditorViewModel : ViewModelBase
    {
        #region Fields

        private LevelViewModel _levelViewModel;
        private RelayCommand _openLevelCommand, _saveLevelCommand, _createNewCommand;
        private double _zoomLevel;
        private const double _zoomScale = .5;
        private const double _maxZoom = 10.0;
        #endregion

        #region Properties
        public string LevelImageSource
        {
            get
            {
                if (_levelViewModel != null)
                {
                   return _levelViewModel.LevelImage;
                }

                return String.Empty;
            }
            set
            {
                _levelViewModel.LevelImage = value;
                OnPropertyChanged();
            }
        }

        public double ZoomLevel
        {
            get { return _zoomLevel; }
            set
            {
                _zoomLevel = value;
                OnPropertyChanged();
            }
        }

        public LevelViewModel LevelViewModel
        {
            get { return _levelViewModel; }
            set { SetAndNotify(ref _levelViewModel, value);}
        }

        public RelayCommand OpenCommand
        {
            get { return _openLevelCommand ?? (_openLevelCommand = new RelayCommand(Open)); }
        }

        public RelayCommand SaveCommand
        {
            get { return _saveLevelCommand ?? (_saveLevelCommand = new RelayCommand(Save, CanSave)); }
        }

        public RelayCommand CreateNewLevelCommand
        {
            get { return _createNewCommand ?? (_createNewCommand = new RelayCommand(CreateNewLevel)); }
        }

        #endregion

        #region Constructor

        public EditorViewModel()
        {
            _zoomLevel = 1;
        }

        #endregion

        #region Methods

        public void Open(object obj)
        {

        }

        public void Save(object obj)
        {

        }

        public void Zoom(int direction)
        {
            if (direction > 0 && _zoomLevel < _maxZoom)
            {
                ZoomLevel += _zoomScale;
            }
            else if (_zoomLevel > 1)
            {
                ZoomLevel -= _zoomScale;
            }
        }

        public void CreateNewLevel(object obj)
        {
           OpenFileDialog fileDlg = new OpenFileDialog();
           var gotFile = fileDlg.ShowDialog();

            if (gotFile != null && gotFile.Value)
            {
                var bgImage = fileDlg.FileName;
                LevelViewModel = new LevelViewModel(bgImage);
                OnPropertyChanged("LevelImageSource");
            }
        }

        private bool CanSave(object obj)
        {
            return _levelViewModel != null;
        }

        public void AddNewPlatform(double x, double y, double width, double height)
        {
            _levelViewModel.BuildNewLevelPlatform(x,y,width,height);

        }

        #endregion

        #region Events

        #endregion
    }
}